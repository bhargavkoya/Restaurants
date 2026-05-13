using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand,bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling {CommandName} with id: {Id}", nameof(DeleteRestaurantCommand), request.Id);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id, cancellationToken);
            if (restaurant == null)
            {
                logger.LogWarning("Restaurant with id {Id} not found", request.Id);
                return false;
            }

            await restaurantsRepository.Delete(restaurant);
            return true;
        }
    }
}
