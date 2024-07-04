namespace EgyBest.Presentaion.Setting
{
    public static class DocumentSetting
    {
        public static string UplouadFile(IFormFile file, string folderName)
        {

            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
            var filePath = GetFilePath(folderName, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }

        public static string DeleteFile(string fileName, string folderName)
        {

            var filePath = GetFilePath(folderName, fileName);
            File.Delete(filePath);
            return filePath;

        }

        public static string UpdateFile(IFormFile file, string fileName, string folderName)
        {

            DeleteFile(fileName, folderName);
            var UpdatedfileName = UplouadFile(file, folderName);
            return UpdatedfileName;

        }

        private static string GetFilePath(string folderName, string fileName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);
            var filePath = Path.Combine(folderPath, fileName);
            return filePath;
        }
    }
}
