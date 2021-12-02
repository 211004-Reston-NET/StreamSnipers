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

        /// <summary>
        /// Email should follow standard email format 'letter' + '@' + 'letter' + '.' + 'letters'
        /// </summary>
        [Theory]
        [InlineData("testemail")]
        [InlineData("123134")]
        [InlineData("")]

        public void EmailShouldFailIfSetWithInvalidData(string p_input)
        {
            User _user = new User();
            Assert.Throws<Exception>(() => _user.Email = p_input);
        }

        [Fact]
        public void UsernameShouldSetValidData()
        {
            //Arrange
            User _user = new User();
            string _username = "xXTesterXx";

            //Act
            _user.Username = _username;

            //Assert
            Assert.NotNull(_user.Username);
            Assert.Equal(_username, _user.Username);
        }

        /// <summary>
        /// tests that a username cannot be empty string and must contain at least 4 characters.
        /// </summary>
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData("abc")]

        public void UsernameShouldFailIfSetWithInvalidData(string p_input)
        {
            User _user = new User();
            Assert.Throws<Exception>(() => _user.Username = p_input);
        }
    }
}