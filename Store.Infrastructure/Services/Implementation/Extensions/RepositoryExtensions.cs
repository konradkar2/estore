using System;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Core.Repositories;

namespace Store.Infrastructure.Services.Implementation.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Game> GetOrFailAsync(this IGameRepository gameRepository, Guid gameId)
        {
            var game = await gameRepository.GetAsync(gameId);
            if(game == null)
            {
                throw new Exception($"Game of id '{gameId}' does not exists ");
            }
            return game;
        }    
        public static async Task<User> GetOrFailAsync(this IUserRepository userRepository, Guid userId)
        {
            var user = await userRepository.GetAsync(userId);
            if(user == null)
            {
                throw new Exception($"User with id '{userId}' does not exists ");
            }
            return user;
        }      
    }
}