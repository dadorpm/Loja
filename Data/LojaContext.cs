using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;

namespace Loja.Data
{
    public class LojaContext : DbContext
    {
        public LojaContext (DbContextOptions<LojaContext> options)
            : base(options)
        {
        }

        public DbSet<Loja.Models.Pedido> Pedido { get; set; }

        public DbSet<Loja.Models.Roupa> Roupa { get; set; }
    }
}
