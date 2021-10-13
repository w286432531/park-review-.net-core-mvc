using ReviewsSite.Models;
using System;
using Xunit;

namespace ReviewsSite.Tests
{
    public class ParkTests
    {
        Park sut;

        [Fact]
        public void Park_Should_Set_Id()
        {
            // Arrange

            // Act
            sut = new Park();
            sut.Id = 5;

            //Assert
            Assert.Equal("5", sut.Id.ToString());
        }
    }
}
