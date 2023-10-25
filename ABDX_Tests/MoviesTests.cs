using AssessmentBackendDeveloperXsis_Sukrian.Controllers;
using AssessmentBackendDeveloperXsis_Sukrian.DTO;
using AssessmentBackendDeveloperXsis_Sukrian.Entities;
using AssessmentBackendDeveloperXsis_Sukrian.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ABDX_Tests
{
    public class MoviesTests
    {
        private readonly Mock<ILogger<MoviesController>> _logger;
        private readonly Mock<MovieService> _movieService;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<MoviesdbContext> _dbContext;
        public MoviesTests()
        {
            _logger = new Mock<ILogger<MoviesController>>();
            _mapper = new Mock<IMapper>();
            _dbContext = new Mock<MoviesdbContext>();
            _movieService = new Mock<MovieService>();
        }

        [Fact]
        public void Movies_Get()
        {
            // Arrange
            var movies = SelectMovies();
            _movieService.Setup(x => x.SelectAll())
                .Returns(movies);
            var moviesController = new MoviesController(_logger.Object, _movieService.Object, _mapper.Object);

            // Act
            var actionResult = moviesController.Get();

            // Assert
            //Assert.NotNull(actionResult);
            //actionResult.
            //Assert.Equal(SelectMovies().Count(), moviesResult.);
            //Assert.Equal(SelectMovies().ToString(), moviesResult.ToString());
            //Assert.True(movies.Equals(moviesResult));
        }

        private List<MovieDTO> SelectMovies()
        {
            List<MovieDTO> movieData = new()
            {
                new MovieDTO
                {
                    Id = 1,
                    Title = "John Wick",
                    Description = "John Wick",
                    Rating = (float)8.0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new MovieDTO
                {
                    Id = 2,
                    Title = "John Wick 2",
                    Description = "John Wick 2",
                    Rating = (float)8.3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new MovieDTO
                {
                    Id = 1,
                    Title = "John Wick 3",
                    Description = "John Wick 3",
                    Rating = (float)8.7,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
            return movieData;
        }
    }
}