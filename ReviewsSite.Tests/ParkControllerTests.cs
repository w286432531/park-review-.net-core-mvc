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
        [Fact]
        public void Delete_Should_Remove_Park_From_Index()
        {
            var park = new Park();

            var delete = sut.Delete(park.Id);

            Assert.IsType<ViewResult>(delete);
        }

        [Fact]
        public void Detail_Shows_Detail_Of_Park()
        {
            var park = new Park();
           
            parkRepo.Create(park);
            var detail = sut.Detail(park.Id);

            Assert.IsType<ViewResult>(detail);
        }

        [Fact]
        public void Edit_Should_Edit_Park_Details()
        {
            var park = new Park();
            var edit = sut.Edit(park.Id);

            Assert.IsType<ViewResult>(edit);
        }
    }

}


