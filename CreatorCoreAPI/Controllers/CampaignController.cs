using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Dtos.Transaction;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CreatorCoreAPI.Controllers
{
    [Route("creatorCoreAPI/[Controller]")]
    [ApiController]
    public class CampaignController: Controller
    {
        private readonly ICampaignRepository _campaignRepo;
        private readonly ICreatorRepository _creatorRepo;
        
        public CampaignController(ICampaignRepository rep, ICreatorRepository creatorRepo)
        {
            _campaignRepo = rep;
            _creatorRepo = creatorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactions = await _campaignRepo.GetAllAsync();

            var transactionDto = transactions.Select(t => t.ToCampaignDto());

            return Ok(transactionDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await _campaignRepo.GetByIdAsync(id);

            if(transaction == null)
                return NotFound();
            else
                return Ok(transaction.ToCampaignDto());
        }


        [HttpPost("{creatorId:int}")]
        public async Task<IActionResult> Create([FromRoute] int creatorId, CreateCampaignDto transactionDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _creatorRepo.CreatorExists(creatorId))
                return BadRequest("Creator Doesnt exist bro !!!");
            else
            {
                var transactionMode = transactionDto.ToCampaignFromCreate(creatorId);

                await _campaignRepo.CreateAsyn(transactionMode);

                return CreatedAtAction(nameof(GetById), new{id = transactionMode.creatorID}, transactionMode.ToCampaignDto());
            }

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCampaignRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await _campaignRepo.UpdateAsync(id, updateDto.ToTransactionFromUpdate());

            if(transaction == null)
                return NotFound("TRANSACTION NOT FOUND DUMMY !!!");           
            else{
                Debug.WriteLine("Updated");
                return Ok(transaction.ToCampaignDto());
            }
               
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionModel = await _campaignRepo.DeleteAsync(id);

            if(transactionModel == null)
            return NotFound("NO TRANSACTION FOUND DUMMY !");
            else{
                return Ok(transactionModel);
            }

        }
    }   
}