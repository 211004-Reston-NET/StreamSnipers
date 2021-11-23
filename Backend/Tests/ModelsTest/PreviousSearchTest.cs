using Models;
using Xunit;

namespace Tests.ModelsTest
{
    public class PreviousSearchTest
    {
        [Fact]
        public void UserIdShouldSetValidData()
        {
            PreviousSearch _prevSearch = new PreviousSearch();
            int _testId = 1;

            _prevSearch.UserId = _testId;

            Assert.Equal(_testId, _prevSearch.UserId);
        }

        [Fact]
        public void SearchShouldSetValidData()
        {
            PreviousSearch _prevSearch = new PreviousSearch();
            string _testSearch = "Scary Movie 2";

            _prevSearch.Search = _testSearch;

            Assert.NotNull(_prevSearch.Search);
            Assert.Equal(_testSearch, _prevSearch.Search);
        }
    }
}