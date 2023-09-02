using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Book.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _book;
        public BookController(IBookService book)
        {
            _book = book;
        }

        [HttpGet]
        [Route("getBookListOrderbyPAT")]
        public IActionResult getBookListOrderbyPAT()
        {
            var List = _book.getBookListOrderbyPAT();
            return Ok(List);
        }

        [HttpGet]
        [Route("getBookListOrderbyAT")]
        public IActionResult getBookListOrderbyAT()
        {
            var List = _book.getBookListOrderbyAT();
            return Ok(List);
        }

        [HttpGet]
        [Route("getTotalPriceofAllBooks")]
        public IActionResult getTotalPriceofAllBooks()
        {
            var List = _book.getTotalPriceofAllBooks();
            return Ok(List);
        }
    }
}