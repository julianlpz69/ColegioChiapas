using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ColegioController : BaseApiController
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public ColegioController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<ColegioDto>>> Get()
         {
            var clientes = await unitOfWork.Colegios.GetAllAsync();
            return mapper.Map<List<ColegioDto>>(clientes);

         }


          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Colegio>> Post(ColegioDto colegioDto)
          {
            var Colegio = this.mapper.Map<Colegio>(colegioDto);
             unitOfWork.Colegios.Add(Colegio);
            await unitOfWork.SaveAsync();
         
            if (Colegio == null){
                return BadRequest();
            }
            colegioDto.Id = Colegio.Id;
            return CreatedAtAction(nameof(Post), new {id = colegioDto.Id}, colegioDto); 
          }
    }
}

    