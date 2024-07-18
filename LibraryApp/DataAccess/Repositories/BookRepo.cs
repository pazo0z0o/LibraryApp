using DataAccess.Interfaces;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookRepo : IBookRepo<Book>
    { //TODO: make them async-await when calling to the db
        public Task<Book> Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
