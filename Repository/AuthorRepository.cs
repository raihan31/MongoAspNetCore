using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using newApp.Context;
using newApp.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace newApp.Repository { 
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IBookContext _context;
        public AuthorRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _context.Authors.Find(_ => true).ToListAsync();
        }
        public Task<Author> GetAuthor(string Id)
        {
            FilterDefinition<Author> filter = Builders<Author>.Filter.Eq(m => m.Id, Id);
            return _context
                    .Authors
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        
        public async Task Create(Author author)
        {
            await _context.Authors.InsertOneAsync(author);
        }
        public async Task<bool> Update(Author author)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Authors
                        .ReplaceOneAsync(
                            filter: g => g.Id == author.Id,
                            replacement: author);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string Id)
        {
            FilterDefinition<Author> filter = Builders<Author>.Filter.Eq(m => m.Id, Id);
            DeleteResult deleteResult = await _context
                                                .Authors
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }   
}
