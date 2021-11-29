using Models;
using Xunit;

namespace Tests.ModelsTest
{
    public class RecommendationTest
    {
        [Fact]
        public void UserIdShouldSetValidData()
        {
            Recommendation _recom = new Recommendation();
            int _testId = 1;

            _recom.UserId = _testId;

            Assert.Equal(_testId, _recom.UserId);
        }

        [Fact]
        public void GenreShouldSetValidData()
        {
            Recommendation _recom = new Recommendation();
            string _testGenre = "Horror";

            _recom.Genre = _testGenre;

            Assert.NotNull(_recom.Genre);
            Assert.Equal(_testGenre, _recom.Genre);
        }
    }
}