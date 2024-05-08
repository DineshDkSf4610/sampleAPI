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
    public class BookDetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public BookDetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        //GET: api/OrderDetailsa
        [HttpGet]
        public IActionResult GetBookLists()
        {
            return Ok(_dbContext.bookList.ToList());
        }

        // GET: api/OrderDetails/1
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var medicine = _dbContext.bookList.FirstOrDefault(m => m.BookID == id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }



        //POST: api/OrderDetails

        [HttpPost]
        public IActionResult PostBook([FromBody] BookDetails books)
        {
            _dbContext.bookList.Add(books);
            _dbContext.SaveChanges();
            //You might want to return CreateAtAction or another apporpriate response
            return Ok();
        }

        //PUT : api/OrderDetails/1
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, [FromBody] BookDetails book)
        {
            var index = _dbContext.bookList.FirstOrDefault(m => m.BookID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.BookName = book.BookName;
            index.BookCount = book.BookCount;
            index.AuthorName = book.AuthorName;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }

        // DELETE: api/Contacts/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _dbContext.bookList.FirstOrDefault(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            _dbContext.bookList.Remove(book);
            _dbContext.SaveChanges();
            //you might want to return NoContent or another appropriate response
            return Ok();
        }
    }
}