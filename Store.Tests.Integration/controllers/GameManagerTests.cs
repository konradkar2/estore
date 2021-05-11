using FluentAssertions;
using System.Threading.Tasks;
using Store.Infrastructure.Queries;
using Store.Infrastructure.DTO;
using Store.Tests.Integration.controllers.Utilities;
using System.Collections.Generic;
using Store.Api;
using Xunit;
using System.Linq;
using Store.Infrastructure.Commands.Game;
using System;
using System.Net;

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
            var response = await Client.GetAsync("/games/all/0");            
            var responseString = await response.Content.ReadAsStringAsync();
            var games = responseString.DeserializeAs<List<GameDto>>();
            games.Any().Should().BeTrue();
        }
        [Fact]
        public async Task game_not_digital_should_be_created_properly()
        {
            var createGameCommand = new CreateGame
            {
                Name = "COD II",
                AgeCategory = "18+",
                Description = "Game added via tests",
                IsDigital = false,
                platformName = "pc",
                Categories = new List<string>{"shooter","action"},
                Price = 299.99m,
                Quantity = 123,
                ReleaseDate = DateTime.UtcNow            
                
            };
            var response = await Client.PostAsync("/games/manage",createGameCommand.GetPayload());           

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var uri = response.Headers.Location.ToString();
            var resp = await Client.GetAsync(uri);            
            var responseString = await resp.Content.ReadAsStringAsync();
            var gameDto = responseString.DeserializeAs<GameDto>();
            gameDto.Should().BeEquivalentTo(createGameCommand,opt => opt
                    .Including(cgc => cgc.Price)
                    .Including(cgc => cgc.Name)                    
                    .Including(cgc => cgc.IsDigital)
                    .Including(cgc => cgc.ReleaseDate)
                );

        }
    }
}