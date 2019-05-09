using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrdModel.Model
{
    public class CrdImportInitializer : PackageInitializerBase<ICrd>
    {
        public CrdImportInitializer(CancellationToken token)
            : base(token)
        {
        }

        public override void InitializePackage(ICrd package)
        {
            base.InitializePackage(package);
        }
    }
}
