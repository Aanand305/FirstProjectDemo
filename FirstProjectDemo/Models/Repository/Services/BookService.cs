using FirstProjectDemo.Models.Repository.Interface;
using FirstProjectDemo.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace FirstProjectDemo.Models.Repository.Services
{
    public class BookService: GenericInterface<BookWithAuthorViewModel>,IBooks
    {
        private ProjectDbContext dbContext;
        public BookService()
        {
            dbContext =new ProjectDbContext();
        }

        public bool DeleteBook(int id)
        {
            var books=dbContext.Books.SingleOrDefault(e=>e.Id==id);
            if(books!=null)
            {
                dbContext.Books.Remove(books);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<BookWithAuthorViewModel> GetData()
        {
            var books = (from book in dbContext.Books
                         join
                         author in dbContext.Author
                         on book.Author_id equals author.Id
                         select new BookWithAuthorViewModel()
                         {
                             Id = book.Id,
                             Title= book.Title,
                             Price= book.Price,
                             Quantity= book.Quantity,
                             Published_On= book.Published_On,
                             AuthorName=author.Author_Name,
                             AuthorMobile=author.Author_Mobile,
                             AuthorEmail=author.Author_Email,
                         }).ToList();
            return books;
        }
    }
}
