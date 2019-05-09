using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrdModel.Model.Mission
{
    public class Mission : PackageBase<IMission>, IMission
    {
        public Mission(IPackageInitializer<IMission> packageInitializer)
            : base(packageInitializer)
        {
            PackageInitializer.InitializePackage(this);
        }
        public string MissionName { get; set; }
    }
}
