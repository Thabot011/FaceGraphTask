using FaceGraphEnities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaceGraph.Repository
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> InsertAsync(IFormFile entity);

        Task DeleteAsync(Image entity);
        Task DeleteAllAsync();
        Image Get(string Name);
        CloudBlockBlob GetCloudBlob(string Name);

    }
}
