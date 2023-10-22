using Company.Product.Domain.UseCases;
using Company.Product.Adapters.Rest.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Adapters.Rest.Controllers
{
    public abstract class AbstractAnimalsApi : ControllerBase
    {
        private readonly IGetAnimalsUseCase getAnimalsUseCase;

        public AbstractAnimalsApi(IGetAnimalsUseCase getAnimalsUseCase)
        {
            this.getAnimalsUseCase = getAnimalsUseCase ?? throw new ArgumentNullException(nameof(getAnimalsUseCase));
        }

        [HttpGet]
        [Route("/animals")]
        public async virtual Task<ActionResult<GetAnimalsResponse>> GetAnimals(
            [FromQuery][Required]string filter, 
            [FromQuery]int limit, 
            [FromQuery]int offset,
             CancellationToken cancellationToken) 
        {
            var animals = await getAnimalsUseCase.GetAnimals(filter: filter, limit: limit, offset: offset, cancellationToken: cancellationToken);

            return new GetAnimalsResponse()
            {
                Animals = animals
            };
        }
    }
}