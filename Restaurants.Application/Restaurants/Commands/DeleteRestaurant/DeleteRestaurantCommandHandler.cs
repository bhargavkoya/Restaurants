using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling {CommandName} with id: {Id}", nameof(DeleteRestaurantCommand), request.Id);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
            {
                logger.LogWarning("Restaurant with id {Id} not found", request.Id);
                throw new NotFoundException(nameof(request),request.Id.ToString());
            }

            await restaurantsRepository.Delete(restaurant);
        }
    }
}
