using CrdModel.Model;
using System;
using System.Threading;
using System.Xml.Linq;

namespace CrdModel
{
    public class CrdDataManager
    {
        public static ICrd Import(CancellationToken token, string crdFilePath)
        {
            XDocument crdXmlDocument;

            try
            {
                crdXmlDocument = XDocument.Load(crdFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            XElement element = crdXmlDocument.Element("CRD");

            CrdImportInitializer crdImportInitializer = new CrdImportInitializer(token);

            CrdImporter crdImporter = new CrdImporter(crdImportInitializer);

            return crdImporter.Import(element);
        }
    }
}
