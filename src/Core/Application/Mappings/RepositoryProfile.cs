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
    public class RepositoryProfile : Profile
    {
        public RepositoryProfile()
        {
            DestinationMemberNamingConvention =new PascalCaseNamingConvention();
            SourceMemberNamingConvention =  new LowerUnderscoreNamingConvention();

            CreateMap<RepositoryDto, RepositoryDb>().ForMember(x=> x.Parent, opt => opt.Ignore());
            CreateMap<RepositoryDb, Repository>().ReverseMap().ForMember(x=> x.Parent, opt => opt.Ignore());
        }
    }
}
