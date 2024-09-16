namespace RapidNRIMs.Services
{
    public class Base64Image
    {
        public async Task<byte[]> GetImageBytesAsync(string base64Data)
        {
            try
            {
                string[] parts = base64Data.Split(',');
                if (parts.Length != 2)
                {
                    throw new ArgumentException("Invalid base64 data format.");
                }

                string mimeType = parts[0].Split(':')[1].Split(';')[0];
                string base64String = parts[1];

                byte[] imageBytes = Convert.FromBase64String(base64String);
                return imageBytes;
            }
            catch
            {
                throw new ArgumentException("Invalid base64 data.");
            }
        }

        public async Task SaveImageAsync(byte[] imageBytes, string fileName)
        {
            try
            {
                File.WriteAllBytes(fileName, imageBytes);
            }
            catch
            {
                throw new Exception("Failed to save the image.");
            }
        }
    }
}
