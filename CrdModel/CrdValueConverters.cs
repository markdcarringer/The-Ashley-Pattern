using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrdModel
{
    public static class CrdValueConverters
    {
        public static string ToCrdFriendlyName(this string source,
            bool useAttributes = true)
        {
            switch (source)
            {
                case "ClassificationLabel":
                    return "CLASSIFICATION";
                case "Crd":
                    return "CRD";
                case "MissionList":
                    return "MISSION_LIST";
                case "Mission":
                    return "MISSION";
                case "MissionName":
                    return "MISSION_NAME";
                case "RouteList":
                    return "ROUTE_LIST";
                case "Route":
                    return "ROUTE";
                case "Name":
                    return "NAME";
                default:
                    return "";
            }
        }
    }
}
