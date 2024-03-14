using CreatorCoreAPI.Data;
using CreatorCoreAPI.Dtos.Creator;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using CreatorCoreAPI.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace CreatorCoreAPI.Controllers
{
    [Route("creatorCoreAPI/creator")]
    [ApiController]
    public class CreatorController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICreatorRepository _creatorRepo;

        public CreatorController(ApplicationDBContext context, ICreatorRepository creatorRepository) 
        {
            _creatorRepo = creatorRepository;
            _context = context;

        } 

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var creators = await _creatorRepo.GetAllAsync(query); 
            
            var creatorDto = creators.Select(c => c.ToCreatorDto());

            return Ok(creators);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var creator = await _creatorRepo.GetByIdAsync(id);
            
            if(creator == null)
                return NotFound();
           else
                return Ok(creator.ToCreatorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreatorRequestDto creatorDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var creatorModel = creatorDto.ToCreatorFromCreateDto();
            await _creatorRepo.CreateAsync(creatorModel);
            return CreatedAtAction(nameof(GetById), new { id = creatorModel.creatorID }, creatorModel.ToCreatorDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCreatorRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var creatorModel = await _creatorRepo.UpdateAsync(id, updateDto);

            if(creatorModel == null)
                return NotFound();
                
            return Ok(creatorModel.ToCreatorDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var creatorMode = await _creatorRepo.DeleteAsync(id);

            if(creatorMode == null)
                return NotFound();
            else
            {
                return NoContent();
            }
        }
    }
}