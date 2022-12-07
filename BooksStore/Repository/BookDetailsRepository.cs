using BooksStore.Context;
using BooksStore.Contracts;
using BooksStore.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Repository
{
    public class BookDetailsRepository: IBookDetailsRepository
    {
        private readonly DapperContext _context;
        public BookDetailsRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDetail>> GetAllBooks()
        {
            try
            {
                string proc = "GetBookDetails";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<BookDetail>(proc, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SaveBookDetails(BookDetail bookDetail)
        {
            try
            {
                bool result = false;
                string proc = "SaveBookDetails";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@BookName", bookDetail.BookName, DbType.String);
                    parameters.Add("@AuthorName", bookDetail.AuthorName, DbType.String);
                    int rowsEffected = await connection.ExecuteAsync(proc, parameters, commandType: CommandType.StoredProcedure);
                    if (rowsEffected >= 1) { result = true; }
                    else { result = false; }
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditBookDetails(BookDetail bookDetail)
        {
            try
            {
                bool result = false;
                string proc = "UpdateBookDetails";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", bookDetail.Id, DbType.Int32);
                    parameters.Add("@BookName", bookDetail.BookName, DbType.String);
                    parameters.Add("@AuthorName", bookDetail.AuthorName, DbType.String);
                    int rowsEffected = await connection.ExecuteAsync(proc, parameters, commandType: CommandType.StoredProcedure);
                    if (rowsEffected >= 1) { result = true; }
                    else { result = false; }
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteBookDetails(int id)
        {
            try
            {
                bool result = false;
                string proc = "DeleteBookDetailsById";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id, DbType.Int32);
                    int rowsEffected = await connection.ExecuteAsync(proc, parameters, commandType: CommandType.StoredProcedure);
                    if (rowsEffected >= 1) { result = true; }
                    else { result = false; }
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<BookDetail> GetBookById(int id)
        {
            try
            {
                string proc = "GetBookDetailsById";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id, DbType.Int32);
                    return await connection.QuerySingleAsync<BookDetail>(proc, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
