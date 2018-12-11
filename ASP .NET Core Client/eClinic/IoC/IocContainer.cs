using eClinic.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic
{
    public static class Ioc
    {
        public static ApplicationDbContext ApplicationDbContext => IocContainer.Provider.GetService<ApplicationDbContext>();
    }
    public static class IocContainer
    {
        public static ServiceProvider Provider { get; set; }
    }
}
