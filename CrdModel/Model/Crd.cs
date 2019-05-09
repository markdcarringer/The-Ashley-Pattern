using CrdModel.Model.Mission;
using System.Collections.Generic;

namespace CrdModel.Model
{
    public class Crd : PackageBase<ICrd>, ICrd
    {
        public Crd(IPackageInitializer<ICrd> packageInitializer)
            : base(packageInitializer)
        {
            PackageInitializer.InitializePackage(this);
        }

        public string ClassificationLabel { get; set; }

        public List<IMission> MissionList { get; set; }
    }
}
