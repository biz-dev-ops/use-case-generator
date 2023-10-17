using Company.Product.Adapters.Rest.Attributes;
using Company.Product.Adapters.Rest.Models;
using Company.Product.Domain.UseCases;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Company.Product.Adapters.Rest.Controllers
{
    [ApiController]
    public abstract class AbstractAnimalsApi : ControllerBase
    {
        private readonly GetAnimalsUseCase getAnimalsUseCase;

        public AbstractAnimalsApi(GetAnimalsUseCase getAnimalsUseCase)
        {
            this.getAnimalsUseCase = getAnimalsUseCase ?? throw new NullReferenceException(nameof(getAnimalsUseCase));
        }

        [HttpGet]
        [Route("/animals")]
        [ValidateModelState]
        public async virtual Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery][Required]string filter, [FromQuery]int limit, [FromQuery]int offset) 
        {
            var animals = await getAnimalsUseCase.GetAnimals(filter, limit, offset);

            return new GetAnimalsResponse()
            {
                Animals = animals
            };
        }
    }
}