using BooksStore.Contracts;
using BooksStore.Models;
using BooksStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookDetailsRepository _bookrepo;
        public BooksController(IBookDetailsRepository bookrepo)
        {
            _bookrepo = bookrepo;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _bookrepo.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var bookDetails = new BookDetail();
                if (id > 0)
                {
                    bookDetails = await _bookrepo.GetBookById(id);
                }
                else
                {
                    return null;
                }
                return Ok(bookDetails);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("SaveUpdateBook")]
        public async Task<IActionResult> SaveOrUpdateBook(BookDetail bookDetail)
        {
            try
            {
                bool result = false;
                if (bookDetail != null && bookDetail.Id == 0)
                {
                    result = await _bookrepo.SaveBookDetails(bookDetail);
                }
                else
                {
                    result = await _bookrepo.EditBookDetails(bookDetail);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var result = false;
                if (id > 0)
                {
                    result = await _bookrepo.DeleteBookDetails(id);
                }
                else
                {
                    result = false;
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
