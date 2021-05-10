using FluentAssertions;
using System.Threading.Tasks;
using Store.Infrastructure.Queries;
using Store.Infrastructure.DTO;
using Store.Tests.Integration.controllers.Utilities;
using System.Collections.Generic;
using Store.Api;
using Xunit;
using System.Linq;

namespace Store.Tests.Integration.controllers
{
    
    public class GameManagerControllerTests : ControllerTestsBase
    {
        public GameManagerControllerTests(CustomWebApplicationFactory<Startup> factory) 
        : base(factory) {}
        [Fact]
        public void asser_test_are_working()
        {
            1.Should().Be(1);
        }
        [Fact]
        public async Task make_sure_data_was_initialized_by_getting_any_games() 
        {
            var response = await Client.GetAsync("/games/0");            
            var responseString = await response.Content.ReadAsStringAsync();
            var games = responseString.DeserializeAs<List<GameDto>>();
            games.Any().Should().BeTrue();

        }
    }
}