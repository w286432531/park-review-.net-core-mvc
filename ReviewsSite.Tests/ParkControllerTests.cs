using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ReviewsSite.Controllers;
using ReviewsSite.Models;
using ReviewsSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReviewsSite.Tests
{
    public class ParkControllerTests
    {
        ParkController sut;
        IRepository<Park> parkRepo;

        public ParkControllerTests()
        {
           
            parkRepo = Substitute.For<IRepository<Park>>();
            sut = new ParkController(parkRepo);
        }

        [Fact]
        public void Create_Should_Create_A_Park()
        {
            var create = sut.Create();

            Assert.IsType<ViewResult>(create);
        }
    }
}
