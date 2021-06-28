using BookDetailS.Core.IBookrepositery;
using BookDetailS.Core.IBookService;
using BookDetailS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetailS.Service.Service
{
    public class BookService : IBookService
    {
        readonly IBookRepositery _iBookRepositery;

        public BookService(IBookRepositery iBookRepositery)
        {
            _iBookRepositery = iBookRepositery;
        }


        #region LoginDetails
        public bool LoginDetails(BookManagementLogin loginDetailS)
        {
            return _iBookRepositery.LoginDetails(loginDetailS);

        }

        #endregion

        #region SelectAuthor
        public List<BookManagementAuthor> SelectAuthor()
        {
            return _iBookRepositery.SelectAuthor();
        }
        #endregion

        #region AddnewBook

        public void AddnewBook(BookManagementDetails bookDetails)
        {
            _iBookRepositery.AddnewBook(bookDetails);
        }
        #endregion

        #region ViewBookDetails

        public List<BookManagementDetails> ViewBookDetails()
        {
            return _iBookRepositery.ViewBookDetails();
        }
        #endregion

        #region EditBookDetails
        public BookManagementDetails EditDetails(int id)
        {
            return _iBookRepositery.EditDetails(id);
        }

        #endregion

        #region DeleteBookDetails

        public void DeleteBookDetails(int id)
        {
            _iBookRepositery.DeleteBookDetails(id);
        }
        #endregion
    }
}
