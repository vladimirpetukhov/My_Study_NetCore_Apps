using SIS.MvcFramework;
using SIS.MvcFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA
{
    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
        }
    }
}
