using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace OnlineAkademi.Utils.Loggers
{
    public class XmlLogger : IExceptionLogger
    {
        public void LogException(ErrorDto error)
        {
            if(!File.Exists("ExceptionLog.xml"))
            {
                new XDocument(new XElement("root")).Save("ExceptionLog.xml");
            }

            //Xml dosyasına hatayı loglayan kodlar
            XDocument docXml = XDocument.Load("ExceptionLog.xml");
            docXml.Element("root").Add(
                new XElement("error",
                    new XElement("url",error.Url),
                    new XElement("type",error.RequestType),
                    new XElement("error",error.Exception)
                )
            );
            docXml.Save("ExceptionLog.xml");
        }
    }
}
