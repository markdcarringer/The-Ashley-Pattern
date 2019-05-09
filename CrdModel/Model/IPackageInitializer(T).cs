using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrdModel.Model
{
    public interface IPackageInitializer<in T> : IPackageInitializer
        where T : IPackage
    {
        void InitializePackage(T package);
    }
}
