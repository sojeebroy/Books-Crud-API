using BooksCRUDAPI.DataAccess;
using BooksCRUDAPI.Entity;
using BooksCRUDAPI.Repository.Interfaces;

namespace BooksCRUDAPI.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {

        public BookRepository(AppDbContext context) : base(context)
        {

        }

    }


}
