using AutoMapper;
using AutoMapper.Configuration.Annotations;
using GitHubTools.CoreApplication.Dto;
using GitHubTools.CoreApplication.Models;
using GitHubTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubTools.CoreApplication.Mappings
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            DestinationMemberNamingConvention =new PascalCaseNamingConvention();
            SourceMemberNamingConvention =  new LowerUnderscoreNamingConvention();

            CreateMap<OwnerDto, OwnerDb>();//.ForMember(x=> x.Parent, opt => opt.Ignore());
            CreateMap<OwnerDb, Owner>();//.ReverseMap().ForMember(x=> x.Parent, opt => opt.Ignore());
        }
    }
}
