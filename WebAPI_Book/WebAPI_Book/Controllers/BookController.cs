using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Book.Models;

namespace WebAPI_Book.Controllers
{
    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {

        Book[] books = new Book[]
            {
                new Book(){ Id=1,Author="Billy Goat",Price=100,Title="Spider without Duty"},
                new Book(){ Id=2,Author="Happy Sheep",Price=200,Title="Giant and Theives"},
                new Book(){ Id=3,Author="Jimmy Bear",Price=300,Title="Fortune of Time"},
                new Book(){ Id=4,Author="Sammy Goat",Price=300,Title="Sun and Moon"}
            };

        // GET: api/Book
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(books);
        }

        //GET : api/book/{author}
        [Route("Author/{author:alpha}")]
        public IHttpActionResult GetBooksByAuthor(string author)
        {
            Book[] bookArray = books.Where<Book>(b => b.Author.ToLower().Contains(author.ToLower())).ToArray();
            return Ok(bookArray);
        }

        //GET : api/book/{title}
        [Route("Title/{title:alpha}")]
        public IHttpActionResult GetBooksByTitle(string title)
        {
            Book[] bookArray = books.Where<Book>(b => b.Title.ToLower().Contains(title.ToLower())).ToArray();
            return Ok(bookArray);
        }

        // GET: api/Book/5
        [Route("{id:int}")]
        public IHttpActionResult RetrieveBookById(int id)
        {
            Book book = books.FirstOrDefault<Book>(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Book
        [Route("")]
        public IHttpActionResult Post([FromBody]Book newBook)
        {
            List<Book> bookList = books.ToList<Book>();
            newBook.Id = bookList.Count + 1;
            bookList.Add(newBook);
            return Ok(bookList.ToList());
        }

        // PUT: api/Book/5
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody]Book updatedBook)
        {
            Book book = books.FirstOrDefault<Book>(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Price = updatedBook.Price;
            book.Author = updatedBook.Author;
            book.Title = updatedBook.Title;

            return Ok(books);

        }

        // DELETE: api/Book/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            List<Book> bookList = books.ToList<Book>();
            Book bookToRemove = books.FirstOrDefault<Book>(b => b.Id == id);
            if (bookToRemove == null)
            {
                return NotFound();
            }
            bookList.Remove(bookToRemove);
            return Ok(bookList.ToList());

        }
    }
}
