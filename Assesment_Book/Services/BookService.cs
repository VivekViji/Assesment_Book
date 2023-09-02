using Assesment_Book.Helper;
using Assesment_Book.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Book.Services
{

    public interface IBookService
    {
        List<Book> getBookListOrderbyPAT();
        List<Book> getBookListOrderbyAT();
        Book getTotalPriceofAllBooks();
    }
    public class BookService : IBookService
    {
        private readonly DbContext _context;
        public BookService(DbContext context)
        {
            _context = context;
        }


        public List<Book> getBookListOrderbyPAT()
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    con.Open();
                    var CommonParam = new DynamicParameters();
                    CommonParam.Add("@Operation", 1);
                    List<Book> BookList;
                    BookList = con.Query<Book>("SpGetBookList", CommonParam, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return BookList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);                
                throw;
            }
        }

        public List<Book> getBookListOrderbyAT()
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    con.Open();
                    var CommonParam = new DynamicParameters();
                    CommonParam.Add("@Operation", 2);
                    List<Book> BookList;
                    BookList = con.Query<Book>("SpGetBookList", CommonParam, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return BookList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public Book getTotalPriceofAllBooks()
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    con.Open();
                    var CommonParam = new DynamicParameters();
                    CommonParam.Add("@Operation", 3);
                    Book BookList;
                    BookList = con.Query<Book>("SpGetBookList", CommonParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    con.Close();
                    return BookList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
