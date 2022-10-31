using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIRestful_Clientes.Models;

namespace APIRestful_Clientes.Data
{
    public class APIRestful_ClientesContext : DbContext
    {
        public APIRestful_ClientesContext (DbContextOptions<APIRestful_ClientesContext> options)
            : base(options)
        {
        }

        public DbSet<APIRestful_Clientes.Models.Clientes> Clientes { get; set; }
    }
}
