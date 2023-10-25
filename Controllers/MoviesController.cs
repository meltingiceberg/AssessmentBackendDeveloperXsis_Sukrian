using AssessmentBackendDeveloperXsis_Sukrian.DTO;
using AssessmentBackendDeveloperXsis_Sukrian.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentBackendDeveloperXsis_Sukrian.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly MoviesdbContext _dbContext;
        public MoviesController(ILogger<MoviesController> logger, MoviesdbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var movies = _dbContext.Movies;
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var movie = _dbContext.Movies.Where(c => c.Id == id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(MovieDTO movieDTO) 
        {
            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
