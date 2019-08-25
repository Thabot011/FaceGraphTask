using FaceGraphEnities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaceGraph.Service
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetAllImagesAsync();
        Task<Image> InsertImageAsync(IFormFile entity);
        Task DeleteImageAsync(Image entity);
        Task DeleteAllImageAsync();
        Image GetImage(string Name);
        CloudBlockBlob GetImageBlob(string Name);
    }
}
