using CreatorCoreAPI.Data;
using CreatorCoreAPI.Dtos.Creator;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var creators = await _creatorRepo.GetAllAsync(); 
            
            var creatorDto = creators.Select(c => c.ToCreatorDto());

            return Ok(creators);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var creator = await _creatorRepo.GetByIdAsync(id);
            
            if(creator == null)
                return NotFound();
           else
                return Ok(creator.ToCreatorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreatorRequestDto creatorDto)
        {
            var creatorModel = creatorDto.ToCreatorFromCreateDto();
            await _creatorRepo.CreateAsync(creatorModel);
            return CreatedAtAction(nameof(GetById), new { id = creatorModel.creatorID }, creatorModel.ToCreatorDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCreatorRequestDto updateDto)
        {
            var creatorModel = await _creatorRepo.UpdateAsync(id, updateDto);

            if(creatorModel == null)
                return NotFound();
                
            return Ok(creatorModel.ToCreatorDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
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