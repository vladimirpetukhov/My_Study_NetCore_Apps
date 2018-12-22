using SIS.MvcFramework;
using System;

namespace MUSACA
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
