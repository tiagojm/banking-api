using APIContaBanco.Context;
using APIContaBanco.Controllers;
using APIContaBanco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace APIContaBancoxUnit.Tests
{
    public class ClienteControllerUnitTest
    {
        private AppDbContext _context;
        
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=localhost;DataBase=BancoDB_1;Uid=root;Pwd=''";


        static ClienteControllerUnitTest()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextOptions = dbContextOptionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options;
        }

        public ClienteControllerUnitTest()
        {
            _context = new AppDbContext(dbContextOptions);
        }

        [Fact]
        public void GetCliente_Return_OkResult()
        {
            //Arrange -> Preparação
            var controller = new ClienteController(_context);

            //Act -> Execução
            var data = controller.Get().Result;
            var result = data.Result as OkObjectResult;

            //Assert -> Verificação
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Cliente>>(result.Value);
        }

        [Fact]
        public void GetClienteById_Return_OkResult()
        {
            var controller = new ClienteController(_context);

            var data = controller.Get(2).Result;
            var result = data.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Cliente>(result.Value);
        }

        [Fact]
        public void GetClienteById_Return_NotFoundResult()
        {
            var controller = new ClienteController(_context);

            var data = controller.Get(1).Result;

            Assert.IsType<NotFoundResult>(data.Result);
            Assert.IsNotType<Cliente>(data.Value);
        }

        [Fact]
        public void PostCliente_Return_CreatedResult()
        {
            var controller = new ClienteController(_context);
            var cliente = new Cliente { Nome = "Tiago Medeiros", NomePreferencia = "TiTo", Email = "medeiros.tiago20@gmail.com", FotoPath = "images/clientes/tiago.png" };

            var data = controller.Post(cliente).Result;

            Assert.IsType<CreatedAtRouteResult>(data);
        }

        [Fact]
        public void PutCliente_Return_BadRequestResult()
        {
            var controller = new ClienteController(_context);
            var cliente = new Cliente { Id = 2, Nome = "Tiago Medeiros", NomePreferencia = "TiTo", Email = "medeiros.tiago25@gmail.com", FotoPath = "images/clientes/tiago.png" };
            var id = 3;

            var data = controller.Put(id, cliente).Result;
            var result = data as BadRequestResult;

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void PutCliente_Return_OkResult()
        {
            var controller = new ClienteController(_context);
            var cliente = new Cliente { Id = 2, Nome = "Tiago Medeiros", NomePreferencia = "TiTo", Email = "medeiros.tiago25@gmail.com", FotoPath = "images/clientes/tiago.png" };
            var id = 2L;

            var data = controller.Put(id, cliente).Result;
            var result = data as NoContentResult;

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteCliente_Return_NotFound()
        {
            var controller = new ClienteController(_context);
            var id = 1L;

            var data = controller.Delete(id).Result;
            var result = data.Result as NotFoundResult;

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteCliente_Return_OkResult()
        {
            var controller = new ClienteController(_context);
            var id = 3L;

            var data = controller.Delete(id).Result;
            var result = data.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Cliente>(result.Value);
        }
    }
}
