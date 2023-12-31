﻿using AssessmentBackendDeveloperXsis_Sukrian.DTO;
using AssessmentBackendDeveloperXsis_Sukrian.Entities;
using AssessmentBackendDeveloperXsis_Sukrian.Request;
using AssessmentBackendDeveloperXsis_Sukrian.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentBackendDeveloperXsis_Sukrian.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly MovieService _service;
        private readonly IMapper _mapper;
        public MoviesController(ILogger<MoviesController> logger, MovieService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<MovieDTO> movies = _service.SelectAll();
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
                MovieDTO? movie = _service.Select(id);
                if(movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]AddMovieRequest request) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MovieDTO movieDTO = _service.Add(_mapper.Map<MovieDTO>(request));
                    return Ok(movieDTO);
                }
                else 
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]AddMovieRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MovieDTO movieDTO = _mapper.Map<MovieDTO>(request);
                    movieDTO.Id = id;
                    MovieDTO? res = _service.Update(movieDTO);
                    if(res == null)
                    {
                        return NotFound();
                    }
                    return Ok(res);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                MovieDTO? movie = _service.Delete(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("search_by_title")]
        public IActionResult SearchByTitle([FromBody]SearchByTitleRequest req)
        {
            try
            {
                IEnumerable<MovieDTO> movies = _service.SearchByTitle(req);
                if (movies.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
