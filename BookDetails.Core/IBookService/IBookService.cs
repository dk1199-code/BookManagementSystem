using BookDetailS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetailS.Core.IBookService
{
    public interface IBookService
    {
        #region LoginDetails
        bool LoginDetails(BookManagementLogin loginDetailS);

        #endregion

        #region SelectAuthor
        public List<BookManagementAuthor> SelectAuthor();
        #endregion

        #region AddnewBook

        public void AddnewBook(BookManagementDetails bookDetails);
        #endregion

        #region ViewBookDetails

        public List<BookManagementDetails> ViewBookDetails();
        #endregion

        #region EditBookDetails
        public BookManagementDetails EditDetails(int id);

        #endregion

        #region DeleteBookDetails

        public void DeleteBookDetails(int id);
        #endregion
    }
}
