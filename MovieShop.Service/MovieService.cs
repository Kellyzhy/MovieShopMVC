using MovieShop.Data;
using MovieShop.Data.Repositories;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
     {
            _movieRepository = movieRepository;
        }

        public void CreateMovie(Movie movie)
        {
             _movieRepository.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
        }

        public Movie GetMovieById(int movieId)
        {
            return _movieRepository.GetById(movieId);
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }

        public List<Movie> GetTop20RevenueMovies()
        {
            return _movieRepository.GetTop20RevenueMovies();
        }

        public List<Movie> GetMoviesByPagination(int pagesize, int pagenumber, int skip, int take)
        {
            return _movieRepository.GetMoviesByPagination(pagesize, pagenumber, skip, take);
        }   
    }

    public class MovieServicesTest : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieServicesTest(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int movieId)
        {
            return _movieRepository.GetById(movieId);
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }

        public List<Movie> GetMoviesByPagination(int pagesize, int pagenumber, int skip, int take)
        {
            return _movieRepository.GetMoviesByPagination(pagesize, pagenumber, skip, take);
        }

        public List<Movie> GetTop20RevenueMovies()
        {
            return _movieRepository.GetTop20RevenueMovies();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMovieService
    {
        //IRepository
        Movie GetMovieById(int movieId);
        //movierepository
        List<Movie> GetTop20RevenueMovies();
        //movierepository
        List<Movie> GetMoviesByGenre(int genreId);
        //IRepository add
        void CreateMovie(Movie movie);
        //IRepository update
        void UpdateMovie(Movie movie);

        List<Movie> GetMoviesByPagination(int pagesize, int pagenumber, int skip, int take);

    }
}
