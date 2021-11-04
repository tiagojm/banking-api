using APIContaBanco.Context;
using APIContaBanco.Models;
using APIContaBanco.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace APIContaBancoxUnit.Tests
{
    public class ClienteRepositoryUnitTest
    {
        private readonly AppDbContext _context;
        //private readonly IRepository<Cliente> _repository;

        public static string connectionString = "Server=localhost;DataBase=BancoDB_1;Uid=root;Pwd=''";
        public static DbContextOptions<AppDbContext> options { get; }


        static ClienteRepositoryUnitTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            options = optionsBuilder.Options;
        }

        public ClienteRepositoryUnitTest()
        {
            _context = new AppDbContext(options);
            //_repository = new ClienteRepository(_context);
        }

        [Fact]
        public void GetCliente()
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);

            var clientes = repository.Get();
            
            clientes.Should().HaveCountGreaterThanOrEqualTo(1);
            Assert.IsType<List<Cliente>>(clientes);
        }

        [Fact]
        public void GetCliente_EmptySet()
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);

            var clientes = repository.Get();

            clientes.Should().HaveCount(0);
            Assert.IsType<List<Cliente>>(clientes);
        }

        [Fact]
        public void GetClienteAsync()
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);

            var clientes = repository.GetAsync().Result;

            clientes.Should().HaveCountGreaterThanOrEqualTo(1);
            Assert.IsType<List<Cliente>>(clientes);
            Assert.NotEmpty(clientes);
        }

        [Fact]
        public void GetClienteAsync_EmptySet()
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);

            var clientes = repository.GetAsync().Result;

            clientes.Should().HaveCount(0);
            Assert.IsType<List<Cliente>>(clientes);
            Assert.Empty(clientes);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetCliente_ById(long id)
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);

            var cliente = repository.GetById(p => p.Id == id);

            if (id <= 2)
            {
                Assert.Null(cliente);
            }
            else
            {
                Assert.IsType<Cliente>(cliente);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetCliente_ByIdAsync(long id)
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);

            var cliente = repository.GetByIdAsync(id).Result;

            if (id <= 2)
            {
                Assert.Null(cliente);
            }
            else
            {
                Assert.IsType<Cliente>(cliente);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TryGetCliente_ById(long id)
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);
            Cliente cliente;

            var founded = repository.TryGetById(id, out cliente);

            if (id <= 2)
            {
                Assert.Null(cliente);
                Assert.False(founded);
            }
            else 
            {
                Assert.IsType<Cliente>(cliente);
                Assert.True(founded);
            }
        }

        [Fact]
        public void InsertCliente()
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);
            var cliente = new Cliente { Nome = "Tiago Medeiros", NomePreferencia = "Salim", Email = "medeiros.tiago20@gmail.com", FotoPath = "images/tiago-2.png" };

            repository.Insert(cliente);
        }

        [Fact]
        public void InsertCliente_NotNullValidation()
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);
            var cliente = new Cliente { Nome = "Tiago Medeiros", NomePreferencia = "Salim", FotoPath = "images/tiago-2.png" };

            Assert.Throws<Exception>(() => { repository.Insert(cliente); });
        }

        [Fact]
        public void InsertCliente_MaxLengthExceded()
        {
            IRepository<Cliente> repository = new ClienteRepository(_context);
            var cliente = new Cliente 
            { 
                Nome = "Tiago Medeiros", 
                NomePreferencia = "Salim", 
                Email = "medeiros.tiago20tiago20tiago20tiago20tiago20tiago20tiago20tiago20@gmail.com", 
                FotoPath = "images/tiago-2.png" 
            };

            Assert.Throws<Exception>(() => { repository.Insert(cliente); });
        }
    }
}
