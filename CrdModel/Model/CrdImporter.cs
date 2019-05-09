using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CrdModel.Model.Mission;
using CrdModel.Utility;

namespace CrdModel.Model
{
    public class CrdImporter : PackageImporterBase<ICrd, Crd, CrdImportInitializer>
    {
        public CrdImporter(IPackageInitializer<ICrd> packageInitializer)
            : base(packageInitializer)
        {
        }

        public override ICrd Import(XElement element)
        {
            var crd = base.Import(element);

            if (crd == null)
            {
                return null;
            }

            var classificationLabelElement =
                element.Elements(
                    PropertyHelpers.GetPropertyNameAsCrdProperty(
                        () => crd.ClassificationLabel))
                        .FirstOrDefault();

            crd.ClassificationLabel = classificationLabelElement?.Value;

            var missionListElement =
                element.Elements(
                    PropertyHelpers.GetPropertyNameAsCrdProperty(
                        () => crd.MissionList))
                        .FirstOrDefault();

            var missionImporter = new MissionImporter(this);

            crd.MissionList =
                missionImporter.ImportList(missionListElement);

            return crd;
        }
    }
}
