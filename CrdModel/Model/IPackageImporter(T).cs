using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrdModel.Model
{
    public interface IPackageImporter<out T> : IPackageImporter
    {
        T Import(XElement element);
    }
}
