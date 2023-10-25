using AssessmentBackendDeveloperXsis_Sukrian.DTO;
using AssessmentBackendDeveloperXsis_Sukrian.Entities;
using AutoMapper;

namespace AssessmentBackendDeveloperXsis_Sukrian.Services
{
    public class MovieService : IService<MovieDTO>
    {
        private readonly MoviesdbContext _dbContext;
        private readonly IMapper _mapper;
        
        public MovieService(MoviesdbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MovieDTO Add(MovieDTO entity)
        {
            Movie movie = _dbContext.Add(_mapper.Map<Movie>(entity)).Entity;
            _dbContext.SaveChanges();

            return _mapper.Map<MovieDTO>(movie);
        }

        public MovieDTO? Delete(int Id)
        {
            MovieDTO? movieDTO = null;
            Movie? movie = _dbContext.Movies.FirstOrDefault(o => o.Id == Id);
            if (movie != null)
            {
                movieDTO = _mapper.Map<MovieDTO>(movie);
                _dbContext.Remove(movie);
                _dbContext.SaveChanges();
            }

            return movieDTO;
        }

        public MovieDTO? Select(int Id)
        {
            MovieDTO? dto = null;
            Movie? movie = _dbContext.Movies.FirstOrDefault(o => o.Id == Id);
            if(movie != null)
            {
                dto = _mapper.Map<MovieDTO>(movie);
            }
            return dto;
        }

        public IEnumerable<MovieDTO> SelectAll()
        {
            List<MovieDTO> dto = new();
            List<Movie> movies = _dbContext.Movies.ToList();
            foreach (var movie in movies)
            {
                dto.Add(_mapper.Map<MovieDTO>(movie));
            }

            return dto;
        }

        public MovieDTO? Update(MovieDTO entity)
        {
            Movie? movie = _dbContext.Movies.FirstOrDefault(o => o.Id == entity.Id);
            if (movie != null)
            {
                movie.Title = entity.Title;
                movie.Description = entity.Description;
                movie.Rating = entity.Rating;
                movie.Image = entity.Image;
                _dbContext.SaveChanges();
                return _mapper.Map<MovieDTO>(movie);
            }
            else
            {
                return null;
            }
        }
    }
}
