using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CrdModel.Utility;

namespace CrdModel.Model.Mission
{
    public class MissionImporter : PackageImporterBase<IMission, Mission, MissionImportInitializer>
    {
        public MissionImporter(IPackageImporter parentImporter)
            : base(parentImporter)
        {
        }

        public override IMission Import(XElement element)
        {
            var mission = base.Import(element);

            if (mission == null)
            {
                return null;
            }

            XElement missionNameElement =
                element.Elements(
                    PropertyHelpers.GetPropertyNameAsCrdProperty(
                        () => mission.MissionName))
                        .FirstOrDefault();

            mission.MissionName = missionNameElement?.Value;

            return mission;
        }
    }
}
