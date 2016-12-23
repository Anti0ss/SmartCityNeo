using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using SmartCityApi.Models;

[assembly: OwinStartup(typeof(SmartCityApi.Startup))]

namespace SmartCityApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            Database.SetInitializer(new DbInitializer());
        }
    }
}
