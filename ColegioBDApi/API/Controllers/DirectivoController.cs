// using API.Dtos;
// using AutoMapper;
// using Dominio.Entities;
// using Dominio.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace API.Controllers
// {
//     public class DirectivoController : BaseApiController
//     {
//         private IUnitOfWork unitOfWork;
//         private readonly IMapper mapper;


//         public DirectivoController(IUnitOfWork UnitOfWork, IMapper Mapper)
//         {
//             unitOfWork = UnitOfWork;
//             mapper = Mapper;
//         }


//          [HttpGet]
//          [ProducesResponseType(StatusCodes.Status200OK)]
//          [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
//          public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
//          {
//             var directivos = await unitOfWork.Directivos.GetAllAsync();
//             return mapper.Map<List<PersonaDto>>(directivos);

//          }


//           [HttpPost]
//           [ProducesResponseType(StatusCodes.Status201Created)]
//           [ProducesResponseType(StatusCodes.Status400BadRequest)]
//           public async Task<ActionResult<Directivo>> Post(PersonaDto directivoDto)
//           {
//             var Directivo = this.mapper.Map<Directivo>(directivoDto);
//              unitOfWork.Directivos.Add(Directivo);
//             await unitOfWork.SaveAsync();
         
//             if (Directivo == null){
//                 return BadRequest();
//             }
//             directivoDto.Id = Directivo.Id;
//             return CreatedAtAction(nameof(Post), new {id = directivoDto.Id}, directivoDto); 
//           }



//             [HttpPut("{id}")]
//             [ProducesResponseType(StatusCodes.Status200OK)]
//             [ProducesResponseType(StatusCodes.Status404NotFound)]
//             [ProducesResponseType(StatusCodes.Status400BadRequest)]
            
//             public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto directivoDto){
//                 if(directivoDto == null)
//                     return NotFound();
            
//                 var directivo = this.mapper.Map<Directivo>(directivoDto);
//                 unitOfWork.Directivos.Update(directivo);
//                 await unitOfWork.SaveAsync();
//                 return directivoDto;
//             }



//             [HttpDelete("{id}")]
//             [ProducesResponseType(StatusCodes.Status204NoContent)]
//             [ProducesResponseType(StatusCodes.Status404NotFound)]
            
//             public async Task<IActionResult> Delete (int id){
//             var directivo = await unitOfWork.Directivos.GetByIdAsync(id);
//             if(directivo == null)
//             return NotFound();
            
//             unitOfWork.Directivos.Remove(directivo);
//             await unitOfWork.SaveAsync();
//             return NoContent();    }

//     }
// }