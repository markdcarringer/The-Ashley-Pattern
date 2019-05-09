using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrdModel
{
    public abstract class StateReporterBase
    {
        public CancellationToken Token { get; protected set; }

        protected void ResolveProperties(CancellationToken token)
        {
            Token = token;
        }
    }
}
