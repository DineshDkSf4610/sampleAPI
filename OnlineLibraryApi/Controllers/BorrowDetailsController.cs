using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryApi.Data;

namespace OnlineLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowDetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public BorrowDetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        //GET: api/OrderDetails
        [HttpGet]
        public IActionResult GetBorrow()
        {
            return Ok(_dbContext.borrowList.ToList());
        }

        // GET: api/OrderDetails/1
        [HttpGet("{id}")]
        public IActionResult GetBorrowList(int id)
        {
            var medicine = _dbContext.borrowList.FirstOrDefault(m => m.BorrowID == id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }



        //POST: api/OrderDetails

        [HttpPost]
        public IActionResult PostBorrow([FromBody] BorrowDetails travels)
        {
            _dbContext.borrowList.Add(travels);
            _dbContext.SaveChanges();
            //You might want to return CreateAtAction or another apporpriate response
            return Ok();
        }

        //PUT : api/OrderDetails/1
        [HttpPut("{id}")]
        public IActionResult PutBorrow(int id, [FromBody] BorrowDetails borrow)
        {
            var index = _dbContext.borrowList.FirstOrDefault(m => m.BorrowID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.BorrowBookCount = borrow.BorrowBookCount;
            index.BorrowedDate = borrow.BorrowedDate;
            index.Status = borrow.Status;
            index.PaidFineAmount = borrow.PaidFineAmount;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }

        // DELETE: api/Contacts/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBorrow(int id)
        {
            var order = _dbContext.borrowList.FirstOrDefault(m => m.BorrowID == id);
            if (order == null)
            {
                return NotFound();
            }
            _dbContext.borrowList.Remove(order);
            _dbContext.SaveChanges();
            //you might want to return NoContent or another appropriate response
            return Ok();
        }
    }
}