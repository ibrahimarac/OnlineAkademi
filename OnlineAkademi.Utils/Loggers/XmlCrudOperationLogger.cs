using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace OnlineAkademi.Utils.Loggers
{
    public class XmlCrudOperationLogger : ICrudOperationLogger
    {
        public void LogCrudOperation(IEnumerable<LogDto> logs)
        {
            if (!File.Exists("CrudLog.xml"))
            {
                new XDocument(new XElement("root")).Save("CrudLog.xml");
            }

            //Xml dosyasına hatayı loglayan kodlar
            XDocument docXml = XDocument.Load("CrudLog.xml");
            foreach (var log in logs)
            {
                docXml.Element("root").Add(
                new XElement("log",
                    new XElement("entity", log.EntityName),
                    new XElement("old", log.Old),
                    new XElement("new", log.New),
                    new XElement("user", log.Username),
                    new XElement("date", log.LogDate)
                )
            );
            }

            docXml.Save("CrudLog.xml");
        }
    }
}
