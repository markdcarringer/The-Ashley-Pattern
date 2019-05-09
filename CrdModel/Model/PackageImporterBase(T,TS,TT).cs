using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrdModel.Model
{
    public abstract class PackageImporterBase<T, TS, TT> : PackageIoBase, IPackageImporter<T>
        where T : IPackage
        where TS : T
        where TT : IPackageInitializer<T>
    {
        // Only package importers for a CRD package (the root package)
        // should utilize this constructor.
        protected PackageImporterBase(IPackageInitializer<T> packageInitializer)
            : base(true)
        {
            ResolveProperties(packageInitializer);
        }

        // This constructor should ONLY be utilized by non-root importer
        // instances (e.g., MissionImporter, VehicleImporter,
        // RouteImporter, etc.)
        protected PackageImporterBase(IPackageImporter parentImporter)
            : base(false)
        {
            ResolveProperties(parentImporter);
        }

        public IPackageInitializer PackageInitializer { get; private set; }

        public virtual T Import(XElement element)
        {
            Token.ThrowIfCancellationRequested();

            // If able to prepare the importer for work,
            // import element and return result;
            // otherwise return default instance
            return InitializeImport(element) ? ImportPackage(element) : default(TS);
        }

        public List<T> ImportList(XElement element, string listElementName = null)
        {
            Token.ThrowIfCancellationRequested();

            if (!InitializeImport(element))
            {
                return new List<T>();
            }

            var name = listElementName ??
                       typeof(TS).Name.ToCrdFriendlyName();

            return element.Elements(name)
                          .Select(Import)
                          .ToList();
        }

        private T ImportPackage(XElement element)
        {
            Token.ThrowIfCancellationRequested();
            return (T)Activator.CreateInstance(typeof(TS), PackageInitializer);
        }

        private static bool InitializeImport(XElement element)
        {
            if (element == null)
            {
                return false;
            }

            return true;
        }

        private void ResolveProperties(IPackageInitializer<T> packageInitializer)
        {
            ResolveProperties(packageInitializer.Token);
            PackageInitializer = packageInitializer;
        }

        private void ResolveProperties(IPackageImporter parentImporter)
        {
            ResolveProperties(parentImporter.Token);

            PackageInitializer =
                (IPackageInitializer<T>)Activator.CreateInstance(
                    typeof(TT),
                    parentImporter.PackageInitializer);
        }
    }
}
