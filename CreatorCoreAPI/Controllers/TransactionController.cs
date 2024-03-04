using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CreatorCoreAPI.Controllers
{
    [Route("creatorCoreAPI/transaction")]
    [ApiController]
    public class TransactionController: Controller
    {
        private readonly ITransactionRepository _transactionRepo;

        public TransactionController(ITransactionRepository rep)
        {
            _transactionRepo = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionRepo.GetAllAsync();

            var transactionDto = transactions.Select(t => t.ToTransactionDto());

            return Ok(transactionDto);

        }
    }
}