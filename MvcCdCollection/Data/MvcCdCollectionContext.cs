#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCdCollection.Models;

namespace MvcCdCollection.Data
{
    public class MvcCdCollectionContext : DbContext
    {
        public MvcCdCollectionContext (DbContextOptions<MvcCdCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCdCollection.Models.PreachingCDs> PreachingCDs { get; set; }
    }
}
