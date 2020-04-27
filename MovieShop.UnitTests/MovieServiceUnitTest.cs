using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieShop.Data.Repositories;
using MovieShop.Entities;
using MovieShop.Service;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        //sut: System Under Test
        private MovieService _sut;
        private List<Movie> _fakemovies;
        
        //create mock object
        private readonly Mock<IMovieRepository> _mockMovieRepository;

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
        }

        [TestInitialize]
        //it will be trigerred before every test case
        public void TestInitialize()
        {
            _fakemovies = new List<Movie>
                      {
                          new Movie {Id = 1, Title = "Avengers: Infinity War",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 2, Title = "Avatar",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 3, Title = "Star Wars: The Force Awakens",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now,  Budget = 1200000},
                          new Movie {Id = 4, Title = "Titanic",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 5, Title = "Inception",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 6, Title = "Avengers: Age of Ultron",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 7, Title = "Interstellar", PosterUrl ="asdfghj", ReleaseDate = DateTime.Now,  Budget = 1200000},
                          new Movie {Id = 8, Title = "Fight Club", PosterUrl ="asdfghj", ReleaseDate = DateTime.Now,  Budget = 1200000},
                          new Movie
                          {
                              Id = 9, Title = "The Lord of the Rings: The Fellowship of the Ring",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000
                          },
                          new Movie {Id = 10, Title = "The Dark Knight",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 11, Title = "The Hunger Games",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 12, Title = "Django Unchained",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie
                          {
                              Id = 13, Title = "The Lord of the Rings: The Return of the King",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000
                          },
                          new Movie {Id = 14, Title = "Harry Potter and the Philosopher's Stone", PosterUrl ="asdfghj", ReleaseDate = DateTime.Now,  Budget = 1200000},
                          new Movie {Id = 15, Title = "Iron Man",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000},
                          new Movie {Id = 16, Title = "Furious 7",  PosterUrl ="asdfghj", ReleaseDate = DateTime.Now, Budget = 1200000}
                      };

            //using MOQ we are going to setup mock methods for IMovieRepository
            
            //go to ImovieRepository to get GetHighestGrossingMovie, every time call it , return fake movies
            _mockMovieRepository.Setup(m => m.GetTop20RevenueMovies()).Returns(_fakemovies);

            //expect any int & return single movie in fakemovie list by id = id
            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => _fakemovies.First(m => m.Id == id));
        }


        [TestMethod]
        public void Test_For_Top20RevenueMovies_From_FakeData()
        {
            //Arrange
            //_sut = new MovieService(new FakeMovieRepository());

            //use MOQ inside constructor
            

            //Act
            var fakemovies = _sut.GetTop20RevenueMovies();

            //Assert
            //you can do multiple asserts in one unit test method
            //one assert fail the whole assert fail
            
            //checking fakemovies have value or not
            Assert.IsNotNull(fakemovies); 
            
            //check total number of movies equal to 16
            Assert.AreEqual(16, fakemovies.Count());
            
            //check all items in the collection are particular type/check return type 
            CollectionAssert.AllItemsAreInstancesOfType(fakemovies.ToList(), typeof(Movie)); 
            
        }
    }

    //public class FakeMovieRepository : IMovieRepository
    //{
    //    public void Add(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Movie Get(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Movie GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetMany(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Movie> GetMoviesByGenre(int genreId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Movie> GetMoviesByPagination(int pagenum, int skipRecords, int takerecords, int pagesize = 20)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Movie> GetTop20RevenueMovies()
    //    {
    //        //Instead of using Dayabase we need to return fake movies from memory
    //        var fakemovies = new List<Movie>
    //                  {
    //                      new Movie {Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
    //                      new Movie {Id = 2, Title = "Avatar", Budget = 1200000},
    //                      new Movie {Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
    //                      new Movie {Id = 4, Title = "Titanic", Budget = 1200000},
    //                      new Movie {Id = 5, Title = "Inception", Budget = 1200000},
    //                      new Movie {Id = 6, Title = "Avengers: Age of Ultron", Budget = 1200000},
    //                      new Movie {Id = 7, Title = "Interstellar", Budget = 1200000},
    //                      new Movie {Id = 8, Title = "Fight Club", Budget = 1200000},
    //                      new Movie
    //                      {
    //                          Id = 9, Title = "The Lord of the Rings: The Fellowship of the Ring", Budget = 1200000
    //                      },
    //                      new Movie {Id = 10, Title = "The Dark Knight", Budget = 1200000},
    //                      new Movie {Id = 11, Title = "The Hunger Games", Budget = 1200000},
    //                      new Movie {Id = 12, Title = "Django Unchained", Budget = 1200000},
    //                      new Movie
    //                      {
    //                          Id = 13, Title = "The Lord of the Rings: The Return of the King", Budget = 1200000
    //                      },
    //                      new Movie {Id = 14, Title = "Harry Potter and the Philosopher's Stone", Budget = 1200000},
    //                      new Movie {Id = 15, Title = "Iron Man", Budget = 1200000},
    //                      new Movie {Id = 16, Title = "Furious 7", Budget = 1200000}
    //                  };
    //        return fakemovies;
    //    }

    //    public void Update(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
