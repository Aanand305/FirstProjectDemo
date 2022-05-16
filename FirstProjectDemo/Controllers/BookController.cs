using FirstProjectDemo.Models.Repository.Interface;
using FirstProjectDemo.Models.Repository.Services;
using FirstProjectDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectDemo.Controllers
{
    public class BookController : Controller
    {
        public GenericInterface<BookWithAuthorViewModel> bookService;
        public IBooks book;
        public BookController(GenericInterface<BookWithAuthorViewModel> bookService,IBooks book)
        {
            this.bookService = bookService;
            this.book = book;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetBooks()
        {
            var books = bookService.GetData();
            return Json(books);
        }

        [HttpPost]
        public JsonResult DeleteBooks( int id)
        {
            var result=book.DeleteBook(id);
            if(result)
            {
                return Json(new { message = "Book Deleted Successfully", ok = true });

            }
            return Json(new { message = "Book Not Deleted Successfully", ok = false });
        }

    }
}
