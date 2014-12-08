using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Arma2Net.AddInProxy;

namespace StatusPage
{
    [AddIn("StatusPageIO", Version = "1.0.0.0", Publisher = "[TF47] funkrusha", Description = "Post the current server fps to statuspage.io")]
    public class StatusPageIO : AddIn
    {

        private String configPath;
        private StatusPageIOConfigurationList ConfigurationItemList;

        public StatusPageIO()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            configPath = Path.GetDirectoryName(path);
            string absPath = Path.Combine(configPath, "StatusPage.xml");

            // load configuration
            ConfigurationItemList = StatusPageIOConfigurationList.Load(absPath);

            if (ConfigurationItemList == null)
            {
                // create a new configuration
                ConfigurationItemList = new StatusPageIOConfigurationList();
                ConfigurationItemList.Configurations.Add(new StatusPageIOConfiguration());
                ConfigurationItemList.Save(absPath);
            }
        }

        public override string Invoke(string args, int maxResultSize)
        {
            IList<object> objs;
            if( !Format.TrySqfAsCollection(args, out objs) || objs.Count < 2 )
            {
                throw new FormatException("Unable to parse the arguments");
            }

            string serverFps = objs[0] as string;
            if( serverFps == null )
            {
                throw new FormatException("Unable to parse the fps source");
            }

            string configurationIdentifier = objs[1] as string;
            if( configurationIdentifier == null )
            {
                throw new FormatException("Unable to parse the configuration identifier");
            }

            StatusPageIOConfiguration configurationItem = ConfigurationItemList.Configurations.Where(item => item.Identifier == configurationIdentifier).FirstOrDefault();
            if( configurationItem == null )
            {
                throw new FormatException(String.Format("Can't find a Configuration with identifier '{0}'", configurationIdentifier));
            }

            if (configurationItem.ApiKey == "" || configurationItem.BaseUri == "" || configurationItem.PageId == "" || configurationItem.MetricId == "")
            {
                return "[\"NOK\", \"please configure the module first\"]";
            }

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("data[timestamp]", unixTimestamp + ""),
                new KeyValuePair<string,string>("data[value]", serverFps)
            });

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("OAuth {0}", configurationItem.ApiKey));
            new Action(async () => {
                var response = await httpClient.PostAsync(String.Format("{0}/pages/{1}/metrics/{2}/data.json", configurationItem.BaseUri, configurationItem.PageId, configurationItem.MetricId), formContent);
            }).Invoke();

            return "[\"OK\"]";
        }
    }
}
