using Company.Product.Adapters.Rest.Attributes;
using Company.Product.Adapters.Rest.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Threading;
using Company.Product.Domain.UseCases.Bus;
using Company.Product.Domain.UseCases.Queries;

namespace Company.Product.Adapters.Rest.Controllers
{
    [ApiController]
    public abstract class AbstractAnimalsApi : ControllerBase
    {
        private readonly IBus bus;

        public AbstractAnimalsApi(IBus bus)
        {
            this.bus = bus ?? throw new NullReferenceException(nameof(bus));
        }

        [HttpGet]
        [Route("/animals")]
        [ValidateModelState]
        public async virtual Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery][Required]string filter, [FromQuery]int limit, [FromQuery]int offset, CancellationToken cancellationToken) 
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