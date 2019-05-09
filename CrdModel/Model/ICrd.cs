using CrdModel.Model.Mission;
using System.Collections.Generic;

namespace CrdModel.Model
{
    public interface ICrd : IPackage
    {
        string ClassificationLabel { get; set; }
        List<IMission> MissionList { get; set; }
    }
}
