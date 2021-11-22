using System;
using System.Collections.Generic;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace Tests
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<SSDBContext> _options;

        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<SSDBContext>()
                                .UseSqlite("Filename = Test.db").Options;
            Seed();
        }

        [Fact]
        public void GetAllUsersShouldReturnAllUsers()
        {
            using (var context = new SSDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);

                //Act
                var test = repo.GetAllUsers();

                //Assert
                Assert.NotNull(test);
                Assert.Equal(2, test.Count);
                Assert.Equal("Admin1", test[0].Username);
                    //test User also contains Review
                Assert.Equal("Admin's 1st Review", test[0].Review[0].Text);
                    //test User also contains PreviousSearch
                Assert.Equal("Shrek", test[0].PreviousSearch[0].Search);
                    //test User also contains Recommendation
                Assert.Equal("Action", test[0].Recommendation[0].Genre);
                    //test User also contains FavoriteList
                Assert.Equal("testImdbID1", test[0].FavoriteList[0].ImdbId);
            }
        }

        [Fact]
        public void GetUsersByIdShouldReturnAllInformationWithTheUserMatchingTheCorrectId()
        {
            using (var context = new SSDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);

                //Act
                var test = repo.GetUserById(1);

                //Assert
                Assert.NotNull(test);
                Assert.Equal("Admin1", test.Username);
                Assert.Equal("Admin's 1st Review", test.Review[0].Text);
                Assert.Equal("Shrek", test.PreviousSearch[0].Search);
                Assert.Equal("Action", test.Recommendation[0].Genre);
                Assert.Equal("testImdbID1", test.FavoriteList[0].ImdbId);
            }
        }

        [Fact]
        public void GetAllFavoriteListsByUserIdShouldReturnAllFavoriteListsWithAMatchingUserId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);

                var test = repo.GetAllFavoriteListByUserId(1);

                Assert.NotNull(test);
                Assert.Equal(2, test.Count);
                Assert.Equal("testImdbID1", test[0].ImdbId);
            }
        }

        [Fact]
        public void GetFavoriteListByIdShouldReturnSingleFavoriteListWithCorrectFavoriteListId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);

                var test = repo.GetFavoriteListById(2);

                Assert.NotNull(test);
                Assert.Equal(1, test.UserId);
                Assert.Equal("testImdbID2", test.ImdbId);
            }
        }

        ////////////////////////////// Seed Test Database //////////////////////////////
        private void Seed()
        {
            using (var context = new SSDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Users.AddRange
                (
                    new User
                    {
                        UserId = 1,
                        Email = "user1@admin.com",
                        Password = "admin123",
                        Username = "Admin1",
                        Admin = true,
                        Review = new List<Review>
                        {
                            new Review
                            {
                                ReviewId = 1,
                                UserId = 1,
                                Text = "Admin's 1st Review",
                                Rating = 5
                            },
                            new Review
                            {
                                ReviewId = 2,
                                UserId = 1,
                                Text = "Admin's 2nd Review",
                                Rating = 10
                            }
                        },
                        PreviousSearch = new List<PreviousSearch>
                        {
                            new PreviousSearch
                            {
                                PreviousSearchId = 1,
                                UserId = 1,
                                Search = "Shrek"
                            },
                            new PreviousSearch
                            {
                                PreviousSearchId = 2,
                                UserId = 1,
                                Search = "Shrek 2"
                            },
                        },
                        Recommendation = new List<Recommendation>
                        {
                            new Recommendation
                            {
                                RecommendationId = 1,
                                UserId = 1,
                                Genre = "Action"
                            },
                            new Recommendation
                            {
                                RecommendationId = 2,
                                UserId = 1,
                                Genre = "Horror"
                            },
                        },
                        FavoriteList = new List<FavoriteList>
                        {
                            new FavoriteList
                            {
                                FavoriteListId = 1,
                                UserId = 1,
                                ImdbId = "testImdbID1"
                            },
                            new FavoriteList
                            {
                                FavoriteListId = 2,
                                UserId = 1,
                                ImdbId = "testImdbID2"
                            },
                        }
                    },
                    new User
                    {
                        UserId = 2,
                        Email = "user2@test.com",
                        Password = "user123",
                        Username = "User2",
                        Admin = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
