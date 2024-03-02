using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Data;
using CreatorCoreAPI.Dtos.Creator;
using CreatorCoreAPI.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CreatorCoreAPI.Controllers
{
    [Route("creatorCoreAPI/creator")]
    [ApiController]
    public class CreatorController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CreatorController(ApplicationDBContext context) => _context = context;

        [HttpGet]
        public IActionResult GetAll()
        {
            var creators = _context.Creators.ToList().Select(c => c.ToCreatorDto()); 
            return Ok(creators);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var creator = _context.Creators.Find(id);

           if(creator == null){
            return NotFound();
           }
           else
            return Ok(creator.ToCreatorDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCreatorRequestDto creatorDto)
        {
            var creatorModel = creatorDto.ToCreatorFromCreateDto();
            _context.Creators.Add(creatorModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = creatorModel.creatorID }, creatorModel.ToCreatorDto());
        }
    }
}