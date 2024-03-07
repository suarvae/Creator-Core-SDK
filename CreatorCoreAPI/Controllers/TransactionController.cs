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
    public class TransactionController: Controller
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly ICreatorRepository _creatorRepo;
        
        public TransactionController(ITransactionRepository rep, ICreatorRepository creatorRepo)
        {
            _transactionRepo = rep;
            _creatorRepo = creatorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactions = await _transactionRepo.GetAllAsync();

            var transactionDto = transactions.Select(t => t.ToTransactionDto());

            return Ok(transactionDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await _transactionRepo.GetByIdAsync(id);

            if(transaction == null)
                return NotFound();
            else
                return Ok(transaction.ToTransactionDto());
        }


        [HttpPost("{creatorId:int}")]
        public async Task<IActionResult> Create([FromRoute] int creatorId, CreateTransactionDto transactionDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _creatorRepo.CreatorExists(creatorId))
                return BadRequest("Creator Doesnt exist bro !!!");
            else
            {
                var transactionMode = transactionDto.ToTransactionFromCreate(creatorId);

                await _transactionRepo.CreateAsyn(transactionMode);

                return CreatedAtAction(nameof(GetById), new{id = transactionMode}, transactionMode.ToTransactionDto());
            }

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateTransactionRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await _transactionRepo.UpdateAsync(id, updateDto.ToTransactionFromUpdate());

            if(transaction == null)
                return NotFound("TRANSACTION NOT FOUND DUMMY !!!");           
            else{
                Debug.WriteLine("Updated");
                return Ok(transaction.ToTransactionDto());
            }
               
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionModel = await _transactionRepo.DeleteAsync(id);

            if(transactionModel == null)
            return NotFound("NO TRANSACTION FOUND DUMMY !");
            else{
                return Ok(transactionModel);
            }

        }
    }   
}