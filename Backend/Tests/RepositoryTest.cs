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

        //////////////////// USER ////////////////////

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
        public void LoginUserShouldReturnAUserWithAMatchingEmail()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                string _email = "user1@admin.com";

                var test = repo.LoginUser(_email);

                Assert.NotNull(test);
                Assert.Equal("Admin1", test.Username);
                Assert.Equal("Admin's 1st Review", test.Review[0].Text);
                Assert.Equal("Shrek", test.PreviousSearch[0].Search);
                Assert.Equal("Action", test.Recommendation[0].Genre);
                Assert.Equal("testImdbID1", test.FavoriteList[0].ImdbId);
            }
        }

        [Fact]
        public void AddUserShouldAddANewUserToUserTable()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                User _user = new User()
                {
                    Email = "user3@test.com",
                    Username = "User3",
                    Review = new List<Review>
                    {
                        new Review
                        {
                            UserId = 3,
                            Text = "User3's 1st Review",
                            Rating = 10
                        }
                    },
                    PreviousSearch = new List<PreviousSearch>
                    {
                        new PreviousSearch
                        {
                            UserId = 3,
                            Search = "Men In Black II"
                        }
                    },
                    Recommendation = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            UserId = 3,
                            Genre = "Action"
                        }
                    },
                    FavoriteList = new List<FavoriteList>
                    {
                        new FavoriteList
                        {
                            UserId = 3,
                            ImdbId = "3ImdbID"
                        }
                    }
                };
                repo.AddUser(_user);
                using (var _context = new SSDBContext(_options))
                {
                    List<User> result = repo.GetAllUsers();
                    Assert.NotNull(result);
                    Assert.Equal(3, result.Count);
                    Assert.Equal(3, result[2].Review[0].ReviewId);
                    Assert.Equal("User3's 1st Review", result[2].Review[0].Text);
                    Assert.Equal("Men In Black II", result[2].PreviousSearch[0].Search);
                    Assert.Equal("Action", result[2].Recommendation[0].Genre);
                    Assert.Equal("3ImdbID", result[2].FavoriteList[0].ImdbId);
                }
            }
        }

        [Fact]
        public void DeleteUserByIdShouldRemoveTheSpecificUserFromTheDatabaseAsWellAsTheTablesItReferences()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                int _userId = 1;
                repo.DeleteUserById(_userId);
                using (var resultContext = new SSDBContext(_options))
                {
                    List<User> userResult = repo.GetAllUsers();
                    List<FavoriteList> favoriteResult = repo.GetFavoriteListByUserId(_userId);
                    List<PreviousSearch> searchResult = repo.GetPreviousSearchByUserId(_userId);
                    List<Recommendation> recommendationResult = repo.GetRecommendationByUserId(_userId);
                    List<Review> reviewResult = repo.GetReviewByUserId(_userId);
                    Assert.Single(userResult);
                    Assert.Empty(favoriteResult);
                    Assert.Empty(searchResult);
                    Assert.Empty(recommendationResult);
                    Assert.Empty(reviewResult);
                }   
            }
        }

        [Fact]
        public void UpdateUserShouldEditUserProperties()
        {

            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                User _user = new User()
                {
                    UserId = 2,
                    Email = "user3@test.com",
                    Username = "User3"
                };
                repo.UpdateUser(_user);
                using (var _context = new SSDBContext(_options))
                {
                    User result = repo.GetUserById(2);
                    Assert.NotNull(result);
                    Assert.Equal("user3@test.com", result.Email);
                    Assert.Equal("User3", result.Username);
                }

            }
        }

        //////////////////// FavoriteList ////////////////////

        [Fact]
        public void GetAllFavoriteListShouldReturnAListOfAllFavoriteList()
        {
            using (var context = new SSDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                //Act
                var test = repo.GetAllFavoriteList();
                //Assert
                Assert.NotNull(test);
                Assert.Equal(2, test.Count);
                Assert.Equal(1, test[0].UserId);
            }
        }

        [Fact]
        public void GetAllFavoriteListsByUserIdShouldReturnAllFavoriteListsWithAMatchingUserId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                var test = repo.GetFavoriteListByUserId(1);
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

        [Fact]
        public void AddFavoriteListShouldBeAddedToAUserFoundById()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                FavoriteList _favoriteToAdd = new FavoriteList
                {
                    UserId = 2,
                    ImdbId = "2Imbd4Imbd"
                };
                repo.AddFavoriteList(_favoriteToAdd);
                using (var _context = new SSDBContext(_options))
                {
                    List<User> result = repo.GetAllUsers();
                    
                    Assert.NotNull(result);
                    Assert.Single(result[1].FavoriteList);
                    Assert.Equal("2Imbd4Imbd", result[1].FavoriteList[0].ImdbId);
                }
            }
        }

        [Fact]
        public void DeleteFavoriteListByIdShouldRemoveOnlyTheFavoriteListWithMatchingIdFromDb()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                int _favoriteListId = 1;
                repo.DeleteFavoriteListById(_favoriteListId);
                using (var contextResult = new SSDBContext(_options))
                {
                    FavoriteList result = repo.GetFavoriteListById(_favoriteListId);
                    List<FavoriteList> listOfRemainingFavList = repo.GetFavoriteListByUserId(1);
                    Assert.Null(result);
                    Assert.Single(listOfRemainingFavList);
                }
            }
        }

        [Fact]
        public void UpdateFavoriteListShouldEditFavoriteListProperties()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                FavoriteList _favoriteToUpdate = new FavoriteList
                {
                    UserId = 2,
                    FavoriteListId = 1,
                    ImdbId = "2Imbd4Imbd"
                };
                repo.UpdateFavoriteList(_favoriteToUpdate);
                using (var _context = new SSDBContext(_options))
                {
                  FavoriteList result = repo.GetFavoriteListById(1);

                  Assert.NotNull(result);

                  Assert.Equal("2Imbd4Imbd", result.ImdbId);
                }
            }
        }

        //////////////////// PreviousSearch ////////////////////

        [Fact]
        public void GetPreviousSearchByUserIdShouldReturnAllPreviousSearchesWithMatchingUserId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                var test = repo.GetPreviousSearchByUserId(1);
                Assert.NotNull(test);
                Assert.Equal(2, test.Count);
                Assert.Equal("Shrek 2", test[1].Search);
                Assert.Equal(1, test[0].UserId);
            }
        }

        [Fact]
        public void GetPreviousSearchByIdShouldReturnSinglePreviousSearchWithCorrectPreviousSearchId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                var test = repo.GetPreviousSearchById(2);
                Assert.NotNull(test);
                Assert.Equal(1, test.UserId);
                Assert.Equal("Shrek 2", test.Search);
            }
        }

        [Fact]
        public void AddPreviousSearchShouldBeAddedToAUserFoundById()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                PreviousSearch _previousSearchToAdd = new PreviousSearch
                {
                    UserId = 2,
                    Search = "Dune"
                };
                repo.AddPreviousSearch(_previousSearchToAdd);
                using (var _context = new SSDBContext(_options))
                {
                    List<User> result = repo.GetAllUsers();
                    Assert.NotNull(result);
                    Assert.Single(result[1].PreviousSearch);
                    Assert.Equal("Dune", result[1].PreviousSearch[0].Search);
                }
            }
        }

        [Fact]
        public void DeletePreviousSearchByIdShouldRemovePreviousSearchItFoundById()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                int _searchId = 1;
                repo.DeletePreviousSearchById(_searchId);
                using (var contextResult = new SSDBContext(_options))
                {
                    PreviousSearch result = repo.GetPreviousSearchById(_searchId);
                    List<PreviousSearch> remainingPreviousSearch = repo.GetPreviousSearchByUserId(1);
                    Assert.Null(result);
                    Assert.Single(remainingPreviousSearch);
                }
            }
        }

        //////////////////// Recommendation ////////////////////

        [Fact]
        public void GetRecommendationByUserIdShouldReturnAllRecommendationesWithMatchingUserId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);

                var test = repo.GetRecommendationByUserId(1);

                Assert.NotNull(test);
                Assert.Equal(2, test.Count);
                Assert.Equal("Horror", test[1].Genre);
                Assert.Equal(1, test[0].UserId);
            }
        }

        [Fact]
        public void GetRecommendationByIdShouldReturnSingleRecommendationWithCorrectRecommendationId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);

                var test = repo.GetRecommendationById(2);

                Assert.NotNull(test);
                Assert.Equal(1, test.UserId);
                Assert.Equal("Horror", test.Genre);
            }
        }

        [Fact]
        public void AddRecommendationShouldBeAddedToAUserFoundById()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Recommendation _recommendationToAdd = new Recommendation
                {
                    UserId = 2,
                    Genre = "SciFi"
                };

                repo.AddRecommendation(_recommendationToAdd);

                using (var _context = new SSDBContext(_options))
                {
                    List<User> result = repo.GetAllUsers();

                    Assert.NotNull(result);
                    Assert.Single(result[1].Recommendation);
                    Assert.Equal("SciFi", result[1].Recommendation[0].Genre);
                }
            }
        }

        [Fact]
        public void UpdateRecommendationShouldEditRecommendationProperties()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Recommendation _recommendationToUpdate = new Recommendation
                {
                    UserId = 1,
                    RecommendationId = 1,
                    Genre = "SciFi"
                };

                repo.UpdateRecommendation(_recommendationToUpdate);

                using (var _context = new SSDBContext(_options))
                {
                    Recommendation result = repo.GetRecommendationById(1);

                    Assert.NotNull(result);
                    Assert.Equal("SciFi", result.Genre);

                }
            }
        }
        [Fact]
        public void DeleteRecommendationByIdShouldRemoveRecommendationItFoundById()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                int _searchId = 1;
                repo.DeleteRecommendationById(_searchId);
                using (var contextResult = new SSDBContext(_options))
                {
                    Recommendation result = repo.GetRecommendationById(_searchId);
                    List<Recommendation> remainingRecommendation = repo.GetRecommendationByUserId(1);
                    Assert.Null(result);
                    Assert.Single(remainingRecommendation);
                }
            }
        }

        //////////////////// Review ////////////////////

        [Fact]
        public void GetReviewByUserIdShouldReturnAllReviewesWithMatchingUserId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);

                var test = repo.GetReviewByUserId(1);

                Assert.NotNull(test);
                Assert.Equal(2, test.Count);
                Assert.Equal("Admin's 1st Review", test[0].Text);
                Assert.Equal(5, test[0].Rating);
                Assert.Equal(1, test[0].UserId);
            }
        }

        [Fact]
        public void GetReviewByIdShouldReturnSingleReviewWithCorrectReviewId()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);

                var test = repo.GetReviewById(2);

                Assert.NotNull(test);
                Assert.Equal(1, test.UserId);
                Assert.Equal("Admin's 2nd Review", test.Text);
                Assert.Equal(10, test.Rating);
            }
        }

        [Fact]
        public void AddReviewShouldBeAddedToAUserFoundById()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Review _reviewToAdd = new Review
                {
                    UserId = 2,
                    Text = "Movie Sucked",
                    Rating = 1
                };

                repo.AddReview(_reviewToAdd);

                using (var _context = new SSDBContext(_options))
                {
                    List<User> result = repo.GetAllUsers();

                    Assert.NotNull(result);
                    Assert.Single(result[1].Review);
                    Assert.Equal("Movie Sucked", result[1].Review[0].Text);
                    Assert.Equal(1, result[1].Review[0].Rating);
                }
            }
        }

        [Fact]
        public void UpdateReviewShouldEditReviewProperties()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Review _reviewToUpdate = new Review
                {
                    UserId = 2,
                    ReviewId = 1,
                    Text = "Movie Sucked",
                    Rating = 1
                };

                repo.UpdateReview(_reviewToUpdate);

                using (var _context = new SSDBContext(_options))
                {
                    Review result = repo.GetReviewById(1);

                    Assert.NotNull(result);
                    Assert.Equal("Movie Sucked", result.Text);
                    Assert.Equal(1, result.Rating);
                }
            }
        }

        [Fact]
        public void DeleteReviewByIdShouldRemoveReviewItFoundById()
        {
            using (var context = new SSDBContext(_options))
            {
                IRepository repo = new Repository(context);
                int _searchId = 1;
                repo.DeleteReviewById(_searchId);
                using (var contextResult = new SSDBContext(_options))
                {
                    Review result = repo.GetReviewById(_searchId);
                    List<Review> remainingReview = repo.GetReviewByUserId(1);
                    Assert.Null(result);
                    Assert.Single(remainingReview);
                }
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
                        Username = "User2",
                        Admin = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
