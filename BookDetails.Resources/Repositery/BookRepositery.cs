using BookDetailS.Core.IBookrepositery;
using BookDetailS.Core.IBookService;
using BookDetailS.Core.Model;
using BookDetailS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetailS.Resources.Repositery
{
    public class BookRepositery : IBookRepositery
    {

        #region LoginDetails
        public bool LoginDetails(BookManagementLogin loginDetailS)
        {
            if(loginDetailS != null)
            {
                BookmanagementsystemEntity entity = new BookmanagementsystemEntity();
                var logiN = entity.LoginDetails.Where(x => x.Username == loginDetailS.AdminUsernamE && x.Password == loginDetailS.AdminPassworD).Count();
                if(logiN>0)
                {
                    return true;
                }
            }
            return false;

        }

        #endregion

        #region SelectAuthor
        public List<BookManagementAuthor> SelectAuthor()
        {
            List<BookManagementAuthor> authotList = new List<BookManagementAuthor>();
            using (var entity = new BookmanagementsystemEntity())
            {
                var authorDetail = entity.AuthorDetails.Where(x => x.Is_Deleted == false).ToList();
                if(authorDetail != null)
                {
                    foreach(var auther in authorDetail)
                    {
                        BookManagementAuthor authoR = new BookManagementAuthor();
                        authoR.Author_Id = auther.Author_Id;
                        authoR.UserAuthoR = auther.Author_name;
                        authotList.Add(authoR);
                    }
                }
            }
            return authotList;
        }
        #endregion

        #region AddnewBook
        public void AddnewBook(BookManagementDetails bookDetails)
        {
            if (bookDetails != null)
            {
                BookDetails Book = new BookDetails();
                if (bookDetails.userBookiD == 0)
                {
                    using (var entity = new BookmanagementsystemEntity())
                    {
                        Book.Title = bookDetails.userTitlE;
                        Book.Author = bookDetails.userAuthoR;
                        Book.Price = bookDetails.userPricE;
                        entity.BookDetails.Add(Book);
                        entity.SaveChanges();
                    }
                }
                else
                {
                    using (var entity = new BookmanagementsystemEntity())
                    {
                        var BookData = entity.BookDetails.Where(x => x.Book_Id == bookDetails.userBookiD && x.Is_Deleted == false).SingleOrDefault();
                        if (BookData != null)
                        {
                            BookData.Title = bookDetails.userTitlE;
                            BookData.Author = bookDetails.userAuthoR;
                            BookData.Price = bookDetails.userPricE;
                            BookData.Updated_Time_Stamp = DateTime.Now;
                            entity.SaveChanges();
                        }

                    }
                }
            }
        }
        #endregion

        #region ViewBookDetails

        public List<BookManagementDetails> ViewBookDetails()
        {
            List<BookManagementDetails> bookList = new List<BookManagementDetails>();
            using(var entity = new BookmanagementsystemEntity())
            {
                bookList = (from author in entity.BookDetails
                            join autherName in entity.AuthorDetails
                            on author.Author equals autherName.Author_Id
                            where author.Is_Deleted == false && autherName.Is_Deleted == false
                            select new BookManagementDetails
                            {
                                userBookiD = author.Book_Id,
                                userTitlE = author.Title,
                                autherName = autherName.Author_name,
                                userPricE = author.Price 
                            }).ToList();
            }
            return bookList;
        }
        #endregion

        #region EditBookDetails
        public BookManagementDetails EditDetails(int id)
        {
            BookManagementDetails editDetails = new BookManagementDetails();
            using (var entity = new BookmanagementsystemEntity())
            {
                editDetails = (from author in entity.BookDetails
                               join autherName in entity.AuthorDetails
                               on author.Author equals autherName.Author_Id
                               where author.Is_Deleted == false && autherName.Is_Deleted == false && author.Book_Id == id
                               select new BookManagementDetails
                               {
                                   userBookiD = author.Book_Id,
                                   userTitlE = author.Title,
                                   userAuthoR = author.Author,
                                   userPricE = author.Price
                               }).SingleOrDefault();
            }
            return editDetails;

        }

        #endregion

        #region DeleteBookDetails

        public void DeleteBookDetails(int id)
        {
            if(id != 0)
            {
                using (var entity = new BookmanagementsystemEntity())
                {
                    var book = entity.BookDetails.Where(x => x.Book_Id == id && x.Is_Deleted == false).SingleOrDefault();
                    if(book != null)
                    {
                        book.Is_Deleted = true;
                        book.Updated_Time_Stamp = DateTime.Now;
                        entity.SaveChanges();
                    }
                }
            }
        }
        #endregion

    }
}
