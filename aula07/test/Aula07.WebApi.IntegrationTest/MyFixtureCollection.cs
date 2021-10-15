using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula07.WebApi.IntegrationTest
{
    [CollectionDefinition(MyFixtureCollectionName.MyFixture)]
    public class MyFixtureCollection : ICollectionFixture<TesteDbContext>
    {

    }

    public static class MyFixtureCollectionName
    {
        public const string MyFixture = "MyFixtureCollection";
    }
}
