using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using iPipeMR.Dtos;
using iPipeMR.Models;
using iPipeMR.ViewModel;

namespace iPipeMR.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            //Mapper.CreateMap<Movie, MovieDto>();




            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}