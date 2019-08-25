using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using FaceGraph.Service;
using FaceGraphEnities;
using FaceGraphProject.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;

namespace FaceGraphProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly IImageService _imageService;
        private readonly IMapper _mapper;


        public ImageController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet("GetAllImages")]
        public async Task<IEnumerable<ImageDTO>> Get()
        {
            IEnumerable<Image> Images = await _imageService.GetAllImagesAsync();

            return _mapper.Map<IEnumerable<ImageDTO>>(Images);
        }

        [HttpGet("DownloadFile/{fileName}")]
        public async Task<FileStreamResult> DownloadFile(string fileName)
        {
            MemoryStream ms = new MemoryStream();

            CloudBlockBlob blockBlob = _imageService.GetImageBlob(fileName);

            await blockBlob.DownloadToStreamAsync(ms);
            Stream blobStream = await blockBlob.OpenReadAsync();

            return File(blobStream, blockBlob.Properties.ContentType, fileName);
        }

        [HttpPost("UploadImage")]
        public async Task<ImageDTO> Post(IFormFile Image)
        {
            Image image = await _imageService.InsertImageAsync(Image);
            return _mapper.Map<ImageDTO>(image);

        }


        [Route("Delete")]
        [HttpDelete]
        public async Task Delete(ImageDTO imageDTO)
        {
            Image image = _mapper.Map<Image>(imageDTO);
           await _imageService.DeleteImageAsync(image);
        }

        [Authorize]
        [HttpDelete(Name = "DeleteAll")]
        public async Task DeleteAll()
        {
            await _imageService.DeleteAllImageAsync();
        }
    }
}
