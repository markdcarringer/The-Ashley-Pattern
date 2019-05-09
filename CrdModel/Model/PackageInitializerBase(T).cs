using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrdModel.Model
{
    public abstract class PackageInitializerBase<T> : PackageIoBase, IPackageInitializer<T>
        where T : IPackage
    {
        // Only package initializers for a CRD package (the root package)
        // should utilize this constructor.
        protected PackageInitializerBase(CancellationToken token)
            : base(true)
        {
            ResolveProperties(token);
        }

        // This constructor should ONLY be utilized by package initializer
        // instances for non-root packages (e.g., IMission, IVehicle,
        // IRoute, etc.)
        protected PackageInitializerBase(IPackage parentPackage = null)
            : base(false)
        {
            ResolveProperties(parentPackage);
        }

        // This constructor should ONLY be utilized by package initializer
        // instances for non-root packages (e.g., IMission, IVehicle,
        // IRoute, etc.)
        protected PackageInitializerBase(IPackageInitializer parentInitializer,
                                         IPackage parentPackage = null)
            : base(false)
        {
            ResolveProperties(parentInitializer, parentPackage);
        }

        public IPackage ParentPackage
        {
            get; protected set;
        }

        private void FinalizeInit()
        {
            if (ParentPackage != null || HandlesRootPackage)
            {
                return;
            }

            var typeName = GetType().Name;
        }

        public virtual void InitializePackage(T package)
        {
            package.ParentPackage = ParentPackage;
        }

        private void ResolveProperties(IPackage package)
        {
            ResolveProperties(package.Token, package);
            FinalizeInit();
        }

        private void ResolveProperties(IPackageInitializer parentInitializer,
                                       IPackage parentPackage = null)
        {
            var parent = parentPackage ?? parentInitializer?.ParentPackage;
            var token = parent?.Token ?? Token;

            ResolveProperties(token, parent);
        }

        private void ResolveProperties(CancellationToken token,
                                       IPackage parentPackage = null)
        {
            base.ResolveProperties(token);
            ParentPackage = parentPackage;
            FinalizeInit();
        }
    }
}
