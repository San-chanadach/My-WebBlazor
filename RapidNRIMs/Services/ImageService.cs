using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace RapidNRIMs.Services
{
    public class ImageService
    {
        public byte[]CompressBase64Image(string base64Image, int maxWidth, int maxHeight, int quality)
        {
            byte[] imageBytes = Convert.FromBase64String(base64Image);

            using (var image = Image.Load(imageBytes))
            {
                var options = new JpegEncoder
                {
                    Quality = quality,
                };

                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(maxWidth, maxHeight),
                    Mode = ResizeMode.Max
                }));
                using (var outputStream = new MemoryStream())
                {
                    image.Save(outputStream, options);
                    return outputStream.ToArray();
                }
            }
        }
    }
}
