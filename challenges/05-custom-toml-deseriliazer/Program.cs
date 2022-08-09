TomlFileModel tomlFile = new TomlFileModel()
{
    Database = new TomlFileModel.DatabaseModel(),
    Ftp = new TomlFileModel.FtpModel()
};

ReadTomlFileDeseriliaze();

void ReadTomlFileDeseriliaze()
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "toml-file.toml");
    using (StreamReader streamReader = new StreamReader(filePath))
    {
        object referenceObject = tomlFile;
        while (streamReader.Peek() >= 0)
        {
            string line = streamReader.ReadLine();
            if (line.StartsWith('[') && line.EndsWith(']'))
            {
                var childObject = line.Replace('[', ' ').Replace(']', ' ').Trim();
                if (childObject == "database")
                    referenceObject = tomlFile.Database;
                else if (childObject == "ftp")
                {
                    referenceObject = tomlFile.Ftp;
                }
            }
            else if (line.Contains('='))
            {
                MapStringToObjectProperty(referenceObject, line);
            }
        }
    }
}

void MapStringToObjectProperty(object tomlFileModel, string line)
{

    var keyValueParts = line.Split('=');
    var key = keyValueParts[0];
    var value = keyValueParts[1];
    System.Console.WriteLine(key.ToLower().Trim());
    System.Console.WriteLine(value);
    tomlFileModel.GetType().GetProperties().ToList().ForEach(t =>
    {
        System.Console.WriteLine(t.Name.ToLower().Trim());
        if (t.Name.ToLower().Trim() == key.ToLower().Trim())
            t.SetValue(tomlFileModel, value);
    });

}

System.Console.WriteLine(tomlFile.Title);
System.Console.WriteLine(tomlFile.Content);
System.Console.WriteLine(tomlFile.Database.Server);
System.Console.WriteLine(tomlFile.Ftp.Server);