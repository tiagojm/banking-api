using APIContaBanco.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<TelefoneContato> TelefonesContato { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<TipoConta> TiposConta { get; set; }
        //public DbSet<Operacao> Operacoes { get; set; }
    }
}
