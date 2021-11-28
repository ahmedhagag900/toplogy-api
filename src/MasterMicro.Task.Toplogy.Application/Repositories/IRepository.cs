using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.Toplogy.Application.Repositories
{
    /// <summary>
    /// responsible for accessing the data persitant layer
    /// saving and reading data  from files
    /// </summary>
    /// <typeparam name="T">the entity type to read or write</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// read the entity form json file
        /// </summary>
        /// <param name="filePath">the filepath to read</param>
        /// <returns>entity read from json</returns>
        Task<T> GetByJsonFileName(string filePath);
        /// <summary>
        /// write entity to json file
        /// </summary>
        /// <param name="entity">entity to save</param>
        /// <param name="filePath">file path to save to</param>
        /// <returns>saved entity</returns>
        Task<T> SaveToJsonFile(T entity, string filePath);
    }
}
