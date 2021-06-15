using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAppWithLatestAuth.DTOs;
using VidlyAppWithLatestAuth.Models;

namespace VidlyAppWithLatestAuth.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //Mapper.CreateMap<Customer, CustomerDTO>();
            //Mapper.CreateMap<CustomerDTO, Customer>();
            //Mapper.CreateMap<Movie, MoviesDTO>();
            //Mapper.CreateMap<MoviesDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            //Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MoviesDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MoviesDTO, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}