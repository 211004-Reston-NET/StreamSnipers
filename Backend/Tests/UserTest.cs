using System;
using Models;
using Xunit;

namespace Tests
{
    public class UserTest
    {
        [Fact]
        public void EmailShouldSetValidData()
        {
            //Arrange
            User _user = new User();
            string _email = "test@example.com";

            //Act
            _user.Email = _email;

            //Assert
            Assert.NotNull(_user.Email);
            Assert.Equal(_email, _user.Email);
        }

        [Theory]
        [InlineData("testemail")]
        [InlineData("123134")]
        [InlineData("")]

        public void EmailShouldFailIfSetWithInvalidData(string p_input)
        {
            User _user = new User();
            Assert.Throws<Exception>(() => _user.Email = p_input);
        }
    }
}