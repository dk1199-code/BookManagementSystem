using BookDetailS.Core.IBookService;
using BookDetailS.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookApiController : Controller
    {
        readonly IBookService _ibookService;

        public BookApiController (IBookService bookService)
        {
            _ibookService = bookService;
        }
        #region loginDetails

        [HttpPost]
        public IActionResult LoginDetails(BookManagementLogin adminUseR)
        {
            var checK = _ibookService.LoginDetails(adminUseR);
            if (checK == true)
            {
                return Ok("Success");
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region AddBookDetails
        [HttpPost]
        public IActionResult AddBookDetails(BookManagementDetails bookDetails)
        {
            _ibookService.AddnewBook(bookDetails);
            return Ok();
        }

        #endregion

        #region BookViewDetails

        [HttpGet]
        public IActionResult Bookview()
        {
           var list = _ibookService.ViewBookDetails();
            return Ok(list);
        }
        #endregion

        #region EditBookDetails
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            if(id != 0)
            {
                var editDetailS = _ibookService.EditDetails(id);
                return Ok(editDetailS);
            }
            return Ok();
        }
        #endregion

        #region DeleteBook
        [HttpDelete]
        public IActionResult DeleteBook (int id)
        {
            _ibookService.DeleteBookDetails(id);
            return Ok();
        }
        #endregion

        #region Author

        [HttpGet]
        public IActionResult AuthorList()
        {
            var Author = _ibookService.SelectAuthor();
            return Ok(Author);
        }
        #endregion
    }
}

