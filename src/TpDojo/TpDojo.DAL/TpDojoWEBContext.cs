using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpDojo.DAL.Models;

namespace TpDojo.DAL
{
    public class TpDojoWEBContext : DbContext
    {
        public TpDojoWEBContext(DbContextOptions<TpDojoWEBContext> options)
            : base(options)
        {
        }

        public DbSet<ArmeEntity> Arme { get; set; } = default!;

        public DbSet<SamouraiEntity>? Samourai { get; set; }
    }
}
