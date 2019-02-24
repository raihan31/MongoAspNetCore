using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using newApp.Context;
using newApp.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace newApp.Repository {
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(string name);
        Task Create(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(string name);
    }
 }