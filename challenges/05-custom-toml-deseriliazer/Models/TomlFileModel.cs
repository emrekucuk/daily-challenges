public class TomlFileModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DatabaseModel Database { get; set; }
    public FtpModel Ftp { get; set; }
    public class DatabaseModel
    {
        public string Server { get; set; }
    }
    public class FtpModel
    {
        public string Server { get; set; }
    }
}