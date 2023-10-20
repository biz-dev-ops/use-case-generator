using Company.Product.Adapters.Rest.Models;
using Company.Product.Domain.UseCases.Bus;
using Company.Product.Domain.UseCases.Queries;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Company.Product.Adapters.Rest.Controllers
{
    public abstract class AbstractAnimalsApi : ControllerBase
    {
        private readonly IBus bus;

        public AbstractAnimalsApi(IBus bus)
        {
            this.bus = bus ?? throw new NullReferenceException(nameof(bus));
        }

        [HttpGet]
        [Route("/animals")]
        public async virtual Task<ActionResult<GetAnimalsResponse>> GetAnimals(
            [FromQuery][Required]string filter, 
            [FromQuery]int limit, 
            [FromQuery]int offset,
             CancellationToken cancellationToken) 
        {
            var animals = await bus.Handle
            (
                new GetAnimals() { Filter = filter, Limit = limit, Offset = offset }, 
                cancellationToken
            );

            return new GetAnimalsResponse()
            {
                Animals = animals
            };
        }
    }
}