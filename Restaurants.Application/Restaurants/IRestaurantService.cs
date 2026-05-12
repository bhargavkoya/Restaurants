using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync();
        Task<RestaurantDto?> GetRestaurantByIdAsync(int id);

        Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto);
    }
}