using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlpacaFinanceApp.Data;
using AlpacaFinanceApp.Entities;
using AlpacaFinanceApp.Web.Models.Operation;

namespace AlpacaFinanceApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly AlpacaDbContext _context;

        public OperationController(AlpacaDbContext context)
        {
            _context = context;
        }

        // GET: api/Operation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationModel>>> GetHistory()
        {
            var operationList = await _context.History.ToListAsync();

            return operationList.Select(u => new OperationModel
            {
                OperationId = u.OperationId,
                UserId = u.UserId,
                Currency = u.Currency,
                Amount = u.Amount,
                RateType = u.RateType,
                InterestRate = u.InterestRate,
                OperationDate = u.OperationDate
            }).ToList();
        }

        // GET: api/Operations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperationById([FromRoute] int id)
        {
            var operation = await _context.History.FindAsync(id);

            if (operation == null)
            {
                return NotFound();
            }

            return Ok(new OperationModel
            {
                OperationId = operation.OperationId,
                UserId = operation.UserId,
                Currency = operation.Currency,
                Amount = operation.Amount,
                RateType = operation.RateType,
                InterestRate = operation.InterestRate,
                OperationDate = operation.OperationDate
            });
        }

        // POST: api/Operations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOperation([FromBody] OperationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Operation operation = new Operation
            {
                OperationId = model.OperationId,
                UserId = model.UserId,
                Currency = model.Currency,
                Amount = model.Amount,
                RateType = model.RateType,
                InterestRate = model.InterestRate,
                OperationDate = DateTime.Now
            };

            _context.History.Add(operation);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/Operations/5
        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteOperation([FromRoute] int id)
        {
            var operation = await _context.History.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            _context.History.Remove(operation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}
