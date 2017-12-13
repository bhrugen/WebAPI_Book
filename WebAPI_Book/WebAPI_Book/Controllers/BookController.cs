using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Book.Models;

namespace WebAPI_Book.Controllers
{
    public class BookController : ApiController
    {

        Book[] books = new Book[]
            {
                new Book(){ Id=1,Author="Billy Goat",Price=100,Title="Spider without Duty"},
                new Book(){ Id=2,Author="Happy Sheep",Price=200,Title="Giant and Theives"},
                new Book(){ Id=3,Author="Jimmy Bear",Price=300,Title="Fortune of Time"},
            };

        // GET: api/Book
        public IHttpActionResult Get()
        {
            return Ok(books);
        }

        // GET: api/Book/5
        public IHttpActionResult Get(int id)
        {
            Book book = books.FirstOrDefault<Book>(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Book
        public IHttpActionResult Post([FromBody]Book newBook)
        {
            List<Book> bookList = books.ToList<Book>();
            newBook.Id = bookList.Count + 1;
            bookList.Add(newBook);
            return Ok(bookList.ToList());
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
    }
}
