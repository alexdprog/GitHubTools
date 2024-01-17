using System.Runtime.Serialization;
using AutoMapper;
using GitHubTools.CoreApplication.Dto;
using GitHubTools.CoreApplication.Mappings;
using GitHubTools.CoreApplication.Models;
using GitHubTools.Domain.Entities;
using NUnit.Framework;

namespace MauiCleanTodos.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
        {
            var mapperAssembly = typeof(RepositoryProfile).Assembly;
            config.AddMaps(mapperAssembly);
        });

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(RepositoryDb), typeof(RepositoryDb))]
    [TestCase(typeof(RepositoryDb), typeof(Repository))]
    [TestCase(typeof(OwnerDto), typeof(OwnerDb))]
    [TestCase(typeof(OwnerDb), typeof(Owner))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}
