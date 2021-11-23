using Models;
using Xunit;

namespace Tests.ModelsTest
{
    public class FavoriteListTest
    {
        [Fact]
        public void UserIdShouldSetValidData()
        {
            FavoriteList _fav = new FavoriteList();
            int _testId = 1;

            _fav.UserId = _testId;

            Assert.Equal(_testId, _fav.UserId);
        }

        [Fact]
        public void ImdbIdShouldSetValidData()
        {
            FavoriteList _fav = new FavoriteList();
            string _testId = "tt0368226";

            _fav.ImdbId = _testId;

            Assert.NotNull(_fav.ImdbId);
            Assert.Equal(_testId, _fav.ImdbId);
        }
    }
}