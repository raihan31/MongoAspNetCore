using System.Collections.Generic;
using newApp.Models;
using newApp.Services;
using Microsoft.AspNetCore.Mvc;
using newApp.Repository;
using System.Threading.Tasks;

namespace newApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET: api/book
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _bookRepository.GetAllBooks());
        }
        // GET: api/book/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string Id)
        {
            var book = await _bookRepository.GetBook(Id);
            if (book == null)
                return new NotFoundResult();
            return new ObjectResult(book);
        }
        // POST: api/book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Book book)
        {
            await _bookRepository.Create(book);
            return new OkObjectResult(book);
        }
        // PUT: api/book/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string Id, [FromBody]Book book)
        {
            var bookFromDb = await _bookRepository.GetBook(Id);
            if (bookFromDb == null)
                return new NotFoundResult();
            book.Id = bookFromDb.Id;
            await _bookRepository.Update(book);
            return new OkObjectResult(book);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var bookFromDb = await _bookRepository.GetBook(Id);
            if (bookFromDb == null)
                return new NotFoundResult();
            await _bookRepository.Delete(Id);
            return new OkResult();
        }
    }
}