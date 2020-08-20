
using Microsoft.Extensions.DependencyInjection;
using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<POSDbContext>();
            context.Database.EnsureCreated();
            
        }
    }
}
