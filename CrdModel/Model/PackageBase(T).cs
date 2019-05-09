using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrdModel.Model
{
    public abstract class PackageBase<T> : StateReporterBase, IPackage
        where T : IPackage
    {
        protected PackageBase(IPackageInitializer<T> packageInitializer,
                              string xname = "")
        {
            ResolveProperties(packageInitializer, xname);
        }

        private void ResolveProperties(IPackageInitializer<T> packageInitializer,
                                       string xname = "")
        {
            PackageInitializer = packageInitializer;
            Token = packageInitializer.Token;
            Token.ThrowIfCancellationRequested();
        }

        public string Id { get; set; }

        protected IPackageInitializer<T> PackageInitializer { get; private set; }

        public IPackage ParentPackage { get; set; }
    }
}
