using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.Toplogy.Application.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public async Task<T> GetByJsonFileName(string filePath)
        {
            try
            {
                //open the file and read it's content as string
                var jsonString = await File.ReadAllTextAsync(filePath);
                //desrilize the string to the entity
                var entity = JsonConvert.DeserializeObject<T>(jsonString);
                return entity;
            }catch(Exception )
            {

                return null;
            }
        }

        public async Task<T> SaveToJsonFile(T entity, string filePath)
        {
            try
            {
                //serialize the entity object to json
                var serializedEntity = JsonConvert.SerializeObject(entity, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                //save the serialized entity to the file
                await File.WriteAllTextAsync(filePath, serializedEntity);
                return entity;
            }
            catch (Exception )
            {

                return null;
            }
        }
    }
}
