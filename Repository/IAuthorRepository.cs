using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using newApp.Context;
using newApp.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace newApp.Repository {
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthor(string Id);
        Task Create(Author author);
        Task<bool> Update(Author author);
        Task<bool> Delete(string Id);
    }
 }