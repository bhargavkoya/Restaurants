using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers
{

    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantService restaurantService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var restaurant = await restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);

        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantDto createRestaurantDto)
        {
            int createdRestaurantId = await restaurantService.CreateRestaurantAsync(createRestaurantDto);
            return CreatedAtAction(nameof(GetById), new { id = createdRestaurantId },null);
        }
    }
}
