using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Dtos.Transaction;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CreatorCoreAPI.Controllers
{
    [Route("creatorCoreAPI/transaction")]
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
            var transactions = await _transactionRepo.GetAllAsync();

            var transactionDto = transactions.Select(t => t.ToTransactionDto());

            return Ok(transactionDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var transaction = await _transactionRepo.GetByIdAsync(id);

            if(transaction == null)
                return NotFound();
            else
                return Ok(transaction.ToTransactionDto());
        }


        [HttpPost("{creatorID}")]
        public async Task<IActionResult> Create([FromRoute] int creatorID, CreateTransactionDto transactionDto)
        {
            if(!await _creatorRepo.CreatorExists(creatorID))
                return BadRequest("Creator Doesnt exist bro !!!");
            else
            {
                var transactionMode = transactionDto.ToTransactionFromCreate(creatorID);

                await _transactionRepo.CreateAsyn(transactionMode);

                return CreatedAtAction(nameof(GetById), new{id = transactionMode}, transactionMode.ToTransactionDto());
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateTransactionRequestDto updateDto)
        {
            var transaction = await _transactionRepo.UpdateAsync(id, updateDto.ToTransactionFromUpdate());

            if(transaction == null)
                return NotFound("TRANSACTION NOT FOUND DUMMY !!!");           
            else
               return Ok(transaction.ToTransactionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var transactionModel = await _transactionRepo.DeleteAsync(id);

            if(transactionModel == null)
            return NotFound("NO TRANSACTION FOUND DUMMY !");
            else{
                return Ok(transactionModel);
            }

        }
    }   
}