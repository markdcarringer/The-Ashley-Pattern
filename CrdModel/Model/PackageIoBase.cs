using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrdModel.Model
{
    public abstract class PackageIoBase : StateReporterBase
    {
        protected PackageIoBase(bool handlesRootPackage)
        {
            HandlesRootPackage = handlesRootPackage;
        }

        protected bool HandlesRootPackage { get; }
    }
}
