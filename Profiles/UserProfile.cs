using AssessmentBackendDeveloperXsis_Sukrian.DTO;
using AssessmentBackendDeveloperXsis_Sukrian.Entities;
using AssessmentBackendDeveloperXsis_Sukrian.Request;
using AutoMapper;

namespace AssessmentBackendDeveloperXsis_Sukrian.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<AddMovieRequest, MovieDTO>();
        }
    }
}
