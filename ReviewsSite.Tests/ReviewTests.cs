using ReviewsSite.Models;
using System;
using Xunit;

namespace ReviewsSite.Tests
{
    public class ReviewTests
    {
        Review sut;

        [Fact]
        public void Review_Should_Set_Id()
        {

            sut = new Review();
            sut.Id = 1;


            Assert.Equal("1", sut.Id.ToString());
        }
        [Fact]
        public void Review_Should_Set_Park_Id()
        {
            sut = new Review();
            sut.ParkId = 5;

            Assert.Equal(5, sut.ParkId);

        }
        [Fact]
        public void Review_Should_Have_A_Reviewer()
        {
            sut = new Review();
            sut.ReviewerName = "Crys";

            Assert.Equal("Crys", sut.ReviewerName);
        }
        [Fact]
        public void Comments_Can_Be_Added_To_Review()
        {
            sut = new Review();
            sut.Comment = "This Park is Nice";

            Assert.Equal("This Park is Nice", sut.Comment);
        }
        [Fact]
        public void Star_Rating_Should_Be_Placed()
        {
            sut = new Review();
            sut.StarRating = 2;

            Assert.Equal(2, sut.StarRating);
        }
    }
}
