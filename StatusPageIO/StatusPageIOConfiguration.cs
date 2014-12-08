using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StatusPage
{
    [Serializable()]
    public class StatusPageIOConfiguration
    {
        public String ApiKey { get; set; }
        public string PageId { get; set; }
        public string MetricId { get; set; }
        public string BaseUri { get; set; }
        public string Identifier { get; set; }

        public StatusPageIOConfiguration()
        {
            ApiKey = PageId = MetricId = BaseUri = Identifier = "";
        }
    }
}
