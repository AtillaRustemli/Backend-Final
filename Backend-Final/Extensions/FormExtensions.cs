namespace Backend_Final.Extensions
{
    public static class FormExtensions
    {
        public static bool CheckImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool CheckSize(this IFormFile file,int size)
        {
            return file.Length / size > 1024;
        }
        public static string SaveImage(this IFormFile file, string folder, IWebHostEnvironment webHostEnvironment)
        {
            string fileName = Guid.NewGuid() + file.FileName;
            string path = Path.Combine(webHostEnvironment.WebRootPath, folder, fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
    }
}
