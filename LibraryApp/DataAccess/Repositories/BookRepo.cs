using DataAccess.Interfaces;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Serilog;

namespace DataAccess.Repositories
{
    public class BookRepo : IBookRepo<Book>
    { //TODO: make them async-await when calling to the db

        private readonly string _connectionString;
        private readonly Serilog.ILogger _logger;

        public BookRepo(string connectionString, ILogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<Book> GetById(int id)
        { 
            var book = new Book(); 
            using (var connection = CreateConnection())
            {
                try
                {
                   book =  await connection.QueryFirstOrDefaultAsync<Book>(
                   Procedures.GetById,
                   new { id = id },
                   commandType: CommandType.StoredProcedure);

                    _logger.Information("GetById operation completed successfully");

                }
                catch (Exception ex)
                {

                _logger.Error("Error at call GetById.", ex.Message);
                
                }
            }
            return book;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            IEnumerable<Book> allBooks = new List<Book>();
            using (var connection = CreateConnection())
            {
                try
                {
                        allBooks = await connection.QueryAsync<Book>(
                        Procedures.GetAll,
                        commandType: CommandType.StoredProcedure);

                    if (allBooks.Any())
                    {
                        _logger.Information($"BookRepo.GetAll call has been successfull");
                    }
                }
                catch (Exception ex) { _logger.Error("Error during BookRepo.GetAll call", ex.Message); }
            }
            return allBooks; 
        }

        public async Task<Book> Add(Book entity)
        {
            var newBook = new Book();
            using (var connection = CreateConnection())
            {
                try
                {
                   await connection.ExecuteAsync(
                   Procedures.CreateBook,
                   new { title = entity.Title, author = entity.Author, isbn = entity.Isbn, publishedDate = entity.PublishedDate, price = entity.Price, quantity = entity.Quantity },
                   commandType: CommandType.StoredProcedure);
                    _logger.Information($"Book with title:  {newBook.Title} has been created");
                }
                catch (Exception ex)
                {
                    _logger.Error("Error during BookRepo.Add call", ex.Message);

                }

            }
            return newBook;
        }

        public async Task<Book> Update(Book entity)
        {
            var updatedBook = new Book();
            using (var connection = CreateConnection())
            {   
                try
                {
                    await connection.ExecuteAsync(
                    Procedures.UpdateBook,
                    new { id = entity.Id, title = entity.Title, author = entity.Author, isbn = entity.Isbn, publishedDate = entity.PublishedDate, price = entity.Price, quantity = entity.Quantity },
                    commandType: CommandType.StoredProcedure);
                    _logger.Information($"Book with {entity.Id} successfully updated: ");

                }
                catch (Exception ex )
                {
                    _logger.Error("Error during BookRepo.Update call", ex.Message);

                }
                return updatedBook;
            }
        }

        public async Task Delete(int id)
        {   
            using (var connection = CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(
                                       Procedures.DeleteBook,
                                       new { id = id },
                                       commandType: CommandType.StoredProcedure);
                    _logger.Information($"Book with {id} successfully deleted");

                }
                catch (Exception ex)
                {
                    _logger.Error("Error during BookRepo.Delete call", ex.Message);
                }
               
            }
        }
    }
}
//GetAll = "sp_Book_Get";
//CreateBook = "sp_Book_Create";
//GetById = "sp_Book_GetById";
//UpdateBook = "sp_Book_Update";
//DeleteBook = "sp_Book_Delete";