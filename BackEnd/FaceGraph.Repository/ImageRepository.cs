using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FaceGraphEnities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

namespace FaceGraph.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly CloudBlobContainer container;
        public ImageRepository()
        {
            
            StorageCredentials storageCredentials = new StorageCredentials("fgtest3", "ePycbjNKmeHKeBvK2T5F9AuUPRAj2d0s9irsMXGaoUYEElbL9yw91uElEZW2yrJp/t5tUCRcFc5Sqs/a / fUtGw == ");

            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            container = blobClient.GetContainerReference("images");
        }

        public async Task DeleteAsync(Image entity)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(entity.Name);
            await blob.DeleteAsync();
        }

        public async Task DeleteAllAsync()
        {
            BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(null);
            foreach (IListBlobItem item in resultSegment.Results)
            {
                CloudBlockBlob blob = (CloudBlockBlob)item;
                await blob.DeleteAsync();
            }

        }

        public Image Get(string Name)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Name);
            Image image = new Image()
            {
                Name = blockBlob.Name,
                FilePath = blockBlob.Uri.ToString()
            };
            return image;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            List<Image> blobs = new List<Image>();
            BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(null);
            foreach (IListBlobItem item in resultSegment.Results)
            {
                CloudBlockBlob blob = (CloudBlockBlob)item;
                blobs.Add(new Image()
                {
                    Name = blob.Name,
                    FilePath = blob.Uri.ToString()
                });
            }
            return blobs;
        }

        public async Task<Image> InsertAsync(IFormFile entity)
        {
           
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(entity.FileName);

            await blockBlob.UploadFromStreamAsync(entity.OpenReadStream());
            return new Image
            {
                Name = blockBlob.Name,
                FilePath = blockBlob.Uri.ToString()
            };
        }

        public CloudBlockBlob GetCloudBlob(string Name)
        {
            CloudBlockBlob file = container.GetBlockBlobReference(Name);
            return file;

        }

    }
}
