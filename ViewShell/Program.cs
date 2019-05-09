using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CrdModel;
using CrdModel.Model;

namespace ViewShell
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICrd crd = CrdDataManager.Import(new System.Threading.CancellationToken(), @"2019-03-27-09-26-14-426.crd");
        }
    }
}
