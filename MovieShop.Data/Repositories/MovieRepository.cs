using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieShop.Data.Repositories
{
    //Repository<Movie> has already has implementaions so only implement method of IMovieRepository
    //but if only put IMovieRepository, need to implements all method of Repository and IMovieRepository
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext context) : base(context)
        {
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _context.Genres.Where(g => g.Id == genreId).SelectMany(m => m.Movies).ToList();
        }

        public List<Movie> GetMoviesByPagination(int pagenum, int skipRecords, int takerecords, int pagesize = 20)
        {
            return _context.Movies.OrderBy(m => m.Title).Skip((pagenum - 1) * pagesize).Take(pagesize).ToList();
        }

        public List<Movie> GetTop20RevenueMovies()
        {
            return _context.Movies.OrderByDescending(m => m.Revenue).Include(m => m.Genres).Take(20).ToList();
        }
        public override Movie GetById(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieCasts.Select(c => c.Cast)).Include(m => m.Genres)
                                .FirstOrDefault(m => m.Id == id);
            if (movie == null) return null;
            var movieRating = _context.Reviews.Where(r => r.MovieId == id).Average(r => r.Rating);
            if (movieRating > 0) movie.Rating = Math.Ceiling(movieRating * 100) / 100;
            return movie;
        }

    }
    public interface IMovieRepository: IRepository<Movie> 
    {
        List<Movie> GetMoviesByGenre(int genreId);
        List<Movie> GetTop20RevenueMovies();
        List<Movie> GetMoviesByPagination(int pagenum, int skipRecords, int takerecords, int pagesize = 20);//default value 
    }
}
