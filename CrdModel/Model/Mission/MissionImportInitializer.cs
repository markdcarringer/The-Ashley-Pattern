using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrdModel.Model.Mission
{
    public class MissionImportInitializer : PackageInitializerBase<IMission>
    {
        public MissionImportInitializer(IPackageInitializer parentInitializer)
            : base(parentInitializer)
        {
        }

        public override void InitializePackage(IMission package)
        {
            base.InitializePackage(package);
            package.MissionName = string.Empty;
        }
    }
}
