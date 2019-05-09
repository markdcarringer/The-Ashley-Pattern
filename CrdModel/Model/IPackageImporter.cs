using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrdModel.Model
{
    public interface IPackageImporter
    {
        CancellationToken Token { get; }
        IPackageInitializer PackageInitializer { get; }
    }
}
