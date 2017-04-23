using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Models
{
    public class ConsultingContextSingleton
    {
        private static ConsultingContext context;
        private static object fred = new object();
        public static ConsultingContext Context()
        {
            if (context == null)
            {
                lock(fred)
                {
                    if (context == null)
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<ConsultingContext>();
                        optionsBuilder.UseSqlServer(
                            @"Server=.\sqlexpress;database=Consulting;trusted_connection=true");
                        context = new ConsultingContext(optionsBuilder.Options);
                    }
                }
            }
            return context;
        }
    }
}
