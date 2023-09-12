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



            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            
            public async Task<ActionResult<ColegioDto>> Put(int id, [FromBody]ColegioDto colegioDto){
                if(colegioDto == null)
                    return NotFound();
            
                var cliente = this.mapper.Map<Colegio>(colegioDto);
                unitOfWork.Colegios.Update(cliente);
                await unitOfWork.SaveAsync();
                return colegioDto;
            }



            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            
            public async Task<IActionResult> Delete (int id){
            var cliente = await unitOfWork.Colegios.GetByIdAsync(id);
            if(cliente == null)
            return NotFound();
            
            unitOfWork.Colegios.Remove(cliente);
            await unitOfWork.SaveAsync();
            return NoContent();    }

    }
}







    