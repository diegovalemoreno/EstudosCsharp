using System;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Xml;
using Linx.NFCE.Services.Util.Util;

namespace Linx.NFCE.Services.Util.DAL
{
    public class ConvertData
    {
        public DataSet ConvertXmlToDataSet(string sXml)
        {
            DataSet ds = new DataSet();
            try
            {
                StringReader reader = new StringReader(sXml);
                ds.ReadXml(reader);

                return ds;
            }
            catch (Exception ex)
            {
                LogUtil.GravarLogErro("ConvertData: ConvertXmlToDataSet", ex.Message.ToString());
                LogUtil.GravarlogEventosWindows(VariaveisGlobais.GlobalString, "ConvertData: ConvertXmlToDataSet", ex.Message.ToString());
            }
            return ds;
        }

        public NameValueCollection ConvertXmlToCollection(string sXml, string sNode)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(sXml); //Carrega o xml de retorno no xmlDocument
                XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(sNode); // Cria um nodelist e carrega uma lista xml do nó passado no parametro
                NameValueCollection Collection = new NameValueCollection(); // cria uma NameValueCollection para o retorno

                foreach (XmlElement xmlElement in xmlNodeList)
                {
                    foreach (XmlNode xmlNode in xmlElement)
                    {
                        Collection.Add(xmlNode.LocalName.ToString(), xmlNode.InnerText.ToString());//Alimenta a collection dinamicamente
                    }
                }
                return Collection;
            }
            catch (Exception ex)
            {
                LogUtil.GravarLogErro("ConvertData: ConvertXmlToCollection", ex.Message.ToString());
                LogUtil.GravarlogEventosWindows(VariaveisGlobais.GlobalString, "ConvertData: ConvertXmlToCollection", ex.Message.ToString());
                return null;
            }
        }


    }
}
