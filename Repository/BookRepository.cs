using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using newApp.Context;
using newApp.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace newApp.Repository { 
    public class BookRepository : IBookRepository
    {
        private readonly IBookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context
                            .Books
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<Book> GetBook(string Id)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(m => m.Id, Id);
            return _context
                    .Books
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        
        public async Task Create(Book book)
        {
            await _context.Books.InsertOneAsync(book);
        }
        public async Task<bool> Update(Book book)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Books
                        .ReplaceOneAsync(
                            filter: g => g.Id == book.Id,
                            replacement: book);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string Id)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(m => m.Id, Id);
            DeleteResult deleteResult = await _context
                                                .Books
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }   
}
