using BookDetailS.Core.IBookService;
using BookDetailS.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace BookManagementSystem.Web.Controllers
{
    public class BookController : Controller
    {

        #region LoginDetails

        public IActionResult LoginView()
        {
            return View();
        }

        public IActionResult LoginDetails(BookManagementLogin adminUseR)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60484/BookApi/LoginDetails");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<BookManagementLogin>(client.BaseAddress, adminUseR);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Alert Maeesage"] = "Login Successs";
                    return RedirectToAction("ViewBook");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            TempData["Alert Maeesage"] = "Invalid Username or Password";
            return RedirectToAction("LoginView");

        }

        #endregion

        #region BookDetailsView

        public IActionResult ViewBook()
        {
            IEnumerable<BookManagementDetails> Book = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60484/BookApi/Bookview");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookManagementDetails>>();
                    readTask.Wait();

                    Book = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Book = Enumerable.Empty<BookManagementDetails>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Book);
        }

        #endregion

        #region Add and Edit BookDetails
        public IActionResult AddBookDetails(int id)
        {
            IEnumerable<BookManagementAuthor> Author = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60484/BookApi/AuthorList");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookManagementAuthor>>();
                    readTask.Wait();

                    Author = readTask.Result;
                }
            }
                ViewBag.Author = new SelectList(Author, "Author_Id", "UserAuthoR");

            if (id != 0)
            {
                BookManagementDetails Book = null;

                using (var client = new HttpClient())
                {
                   
                    client.BaseAddress = new Uri("http://localhost:60484/BookApi/");
                    //HTTP GET
                    var responseTask = client.GetAsync("EditBook?id=" + id);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<BookManagementDetails>();
                        readTask.Wait();

                        Book = readTask.Result;

                    }
                }

                return View(Book);
            }
            else
            {
                return View();
            }

        }
        public IActionResult BookDetails(BookManagementDetails bookDetails)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60484/BookApi/AddBookDetails");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<BookManagementDetails>(client.BaseAddress, bookDetails);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ViewBook");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction("AddBookDetails");
        }

        #endregion

        #region DeleteBook

        public IActionResult DeleteBook (int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:60484/BookApi/ ");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteBook?id=" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ViewBook");
                }
            }

            return RedirectToAction("ViewBook");
        }
        #endregion


    }
}
