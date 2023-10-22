using Company.Product.Domain.UseCases;
using Company.Product.Adapters.Rest.Models;
using Company.Product.Domain.UseCases.Types;

using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Product.Adapters.Rest.Controllers
{
    public abstract class AbstractAnimalsApi : ControllerBase
    {
        private readonly ICreateAnimalUseCase createAnimalUseCase;
        private readonly IGetAnimalUseCase getAnimalUseCase;
        private readonly IGetAnimalsUseCase getAnimalsUseCase;
        
        protected AbstractAnimalsApi(ICreateAnimalUseCase createAnimalUseCase, IGetAnimalUseCase getAnimalUseCase, IGetAnimalsUseCase getAnimalsUseCase)
        {
            this.createAnimalUseCase = createAnimalUseCase ?? throw new ArgumentNullException(nameof(createAnimalUseCase));
            this.getAnimalUseCase = getAnimalUseCase ?? throw new ArgumentNullException(nameof(getAnimalUseCase));
            this.getAnimalsUseCase = getAnimalsUseCase ?? throw new ArgumentNullException(nameof(getAnimalsUseCase));
        }

        [HttpPost]
        [Route("/animals")]
        public async virtual Task<ActionResult> CreateAnimal([FromBody][Required]Animal animal, CancellationToken cancellationToken) 
        {
            await createAnimalUseCase.Execute(animal: animal, cancellationToken: cancellationToken);
            return Empty;
        }
        
        [HttpGet]
        [Route("/animals")]
        public async virtual Task<ActionResult<GetAnimalsResponse>> GetAnimals([FromQuery]int limit, [FromQuery]int offset, CancellationToken cancellationToken) 
        {
            var animals = await getAnimalsUseCase.Execute(limit: limit, offset: offset, cancellationToken: cancellationToken);

            return new GetAnimalsResponse()
            {
                Animals = animals
            };
        }

        [HttpGet]
        [Route("/animals/{animalId}")]
        public async virtual Task<ActionResult<Animal>> GetAnimal(Guid animalId, CancellationToken cancellationToken) 
        {
            return await getAnimalUseCase.Execute(animalId: animalId, cancellationToken: cancellationToken);
        }
    }
}