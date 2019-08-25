using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FaceGraph.Repository;
using FaceGraphEnities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;

namespace FaceGraph.Service
{
    public class ImageService : IImageService
    {

        private readonly IImageRepository _imageRepository;


        public ImageService(IImageRepository imageRepository) {
            _imageRepository = imageRepository;
        }

        public Task DeleteAllImages(Image entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteImageAsync(Image entity)
        {
            await _imageRepository.DeleteAsync(entity);
        }

        public async Task DeleteAllImageAsync()
        {
            await _imageRepository.DeleteAllAsync();
        }


        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
          return await _imageRepository.GetAllAsync();
        }

        public Image GetImage(string Name)
        {
            return _imageRepository.Get(Name);
        }

        public async Task<Image> InsertImageAsync(IFormFile entity)
        {
        return  await  _imageRepository.InsertAsync(entity);
        }

        public CloudBlockBlob GetImageBlob(string Name)
        {
            return _imageRepository.GetCloudBlob(Name);
        }



    }
}
