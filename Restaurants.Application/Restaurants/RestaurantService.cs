using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantService> logger, IMapper mapper) : IRestaurantService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync()
        {
            try
            {
                logger.LogInformation("Retrieving all restaurants from the repository.");
                var restaurants = await restaurantsRepository.GetAllAsync();
                var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
                return restaurantDtos!;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving restaurants.");
                throw;
            }
        }

        public async Task<RestaurantDto?> GetRestaurantByIdAsync(int id)
        {
            try
            {
                logger.LogInformation("Retrieving restaurant with ID {RestaurantId} from the repository.", id);
                var restaurant = await restaurantsRepository.GetByIdAsync(id);
                if (restaurant == null)
                {
                    logger.LogWarning("Restaurant with ID {RestaurantId} not found.", id);
                }
                return mapper.Map<RestaurantDto?>(restaurant);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving restaurant with ID {RestaurantId}.", id);
                throw;
            }
        }


        public async Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto)
        {
            try
            {
                logger.LogInformation("Creating a new restaurant with name {RestaurantName}.", createRestaurantDto.Name);
                var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
                await restaurantsRepository.Create(restaurant);
                logger.LogInformation("Restaurant with name {RestaurantName} created successfully with ID {RestaurantId}.", restaurant.Name, restaurant.Id);
                return restaurant.Id;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating a new restaurant with name {RestaurantName}.", createRestaurantDto.Name);
                throw;
            }
        }
    }
}
