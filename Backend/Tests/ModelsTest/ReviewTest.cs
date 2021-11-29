using Models;
using Xunit;

namespace Tests.ModelsTest
{
    public class ReviewTest
    {
        [Fact]
        public void UserIdShouldSetValidData()
        {
            Review _rev = new Review();
            int _testId = 1;

            _rev.UserId = _testId;

            Assert.Equal(_testId, _rev.UserId);
        }

        [Fact]
        public void TextShouldSetValidData()
        {
            Review _rev = new Review();
            string _testText = "test text";

            _rev.Text = _testText;

            Assert.NotNull(_rev.Text);
            Assert.Equal(_testText, _rev.Text);
        }

        [Fact]
        public void RatingShouldSetValidData()
        {
            Review _rev = new Review();
            int _testRating = 10;

            _rev.Rating = _testRating;

            Assert.Equal(_testRating, _rev.Rating);
        }
    }
}