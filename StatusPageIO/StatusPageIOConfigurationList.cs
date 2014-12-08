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
    public class StatusPageIOConfigurationList
    {
        public List<StatusPageIOConfiguration> Configurations;

        public StatusPageIOConfigurationList()
        {
            Configurations = new List<StatusPageIOConfiguration>();
        }

        public void Save(String filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (StreamWriter newVariable = new StreamWriter(filename))
                {
                    serializer.Serialize(newVariable, this);
                    newVariable.Close();
                }
            }
            catch (Exception ex)
            {
                // later write down the exception
                throw ex;
            }
        }

        public static StatusPageIOConfigurationList Load(String filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StatusPageIOConfigurationList));
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    StatusPageIOConfigurationList loadedItem = (StatusPageIOConfigurationList)serializer.Deserialize(streamReader);
                    return loadedItem;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
