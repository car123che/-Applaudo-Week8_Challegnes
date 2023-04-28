using AutoMapper;
using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.MovieTag;
using MovieRental.Application.DTOs.Rent;
using MovieRental.Application.DTOs.Sell;
using MovieRental.Application.DTOs.Tag;
using MovieRental.Application.DTOs.User;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Tag
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();

            //Movie
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ReverseMap();

            //User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();

            //MovieTag
            CreateMap<MovieTag, MovieTagDto>().ReverseMap();

            //Rent
            CreateMap<Rent, RentDto>().ReverseMap();
            CreateMap<Rent, RentDetailDto>().ReverseMap();

            //Sell
            CreateMap<Sell, SellDto>().ReverseMap();
            CreateMap<Sell, SellDetailDto>().ReverseMap();
        }
    }
}
