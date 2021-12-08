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
         
            sut = new Park();
            sut.Id = 5;

           
            Assert.Equal("5", sut.Id.ToString());
        }

        [Fact]
        public void Park_Should_Have_Name()
        {
            sut = new Park();
            sut.Name = "Park Name";

            Assert.Equal("Park Name", sut.Name);
        }

        [Fact]
        public void Park_Should_Set_Handicap_Accsess()
        {
           
            sut = new Park();
            sut.HasHandicapAccess = true;

            Assert.True(sut.HasHandicapAccess);

        }

        [Fact]
        public void Park_Should_Set_Park_Is_Not_Dog_Friendly()
        {
            sut = new Park();
            sut.IsDogFriendly = false;

            Assert.False(sut.HasHandicapAccess);
        }

        [Fact]
        public void Park_Should_Set_Park_Type()
        {
            sut = new Park();
            sut.ParkType = "Dog Park";

            Assert.Equal("Dog Park", sut.ParkType);
        }
    }
}
