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
            if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
                continue;

            if (line.StartsWith('[') && line.EndsWith(']'))
            {
                var childObject = line.Replace('[', ' ').Replace(']', ' ').Trim();
                if (childObject == "database")
                    referenceObject = tomlFile.Database;
                else if (childObject == "ftp")
                    referenceObject = tomlFile.Ftp;
                else
                {
                    System.Console.WriteLine($"Eslesen bir Child Object yok.");
                    Environment.Exit(0);
                }
            }
            else if (line.Contains('='))
            {
                MapStringToObjectProperty(referenceObject, line);
            }
        }
    }
}

void MapStringToObjectProperty(object referenceObject, string line)
{
    var keyValueParts = line.Split('=');
    var key = keyValueParts[0];
    var value = keyValueParts[1];
    value = value.Trim();

    var valueType = CheckValueType(value);
    object typeModifiedValue = null;

    switch (valueType)
    {
        case ValueTypes.Int:
            typeModifiedValue = Convert.ToInt32(value);
            break;
        case ValueTypes.Double:
            typeModifiedValue = Convert.ToDouble(value);
            break;
        case ValueTypes.Datetime:
            typeModifiedValue = Convert.ToDateTime(value);
            break;
        case ValueTypes.String:
            typeModifiedValue = value.Replace("\"", "");
            break;
        default:
            break;
    }

    // if (valueType == ValueTypes.Int)
    //     typeModifiedValue = Convert.ToInt32(value);
    // else if (valueType == ValueTypes.Datetime)
    //     typeModifiedValue = Convert.ToDateTime(value);
    // else if (valueType == ValueTypes.Double)
    //     typeModifiedValue = Convert.ToDouble(value);
    // else if (valueType == ValueTypes.String)
    //     typeModifiedValue = value.Replace("\"", "");

    var isMatched = false;
    referenceObject.GetType().GetProperties().ToList().ForEach(t =>
    {
        if (t.Name.ToLower().Trim() == key.ToLower().Trim())
        {
            t.SetValue(referenceObject, typeModifiedValue);
            isMatched = true;
        }
    });
    if (!isMatched)
        System.Console.WriteLine($"{key} bir alanla eslesmedi.");
}

ValueTypes CheckValueType(string value)
{
    var isNumber = CheckValue(value, "0123456789");
    if (isNumber)
        return ValueTypes.Int;

    var isDouble = CheckValue(value, "0123456789,");
    if (isDouble)
        return ValueTypes.Double;

    var isDateTime = CheckValue(":+T", value);
    if (isDateTime)
        return ValueTypes.Datetime;

    return ValueTypes.String;
}

bool CheckValue(string value, string valueList)
{
    bool isCheck = true;

    for (int i = 0; i < value.Length; i++)
    {
        var character = value[i];
        if (!valueList.Contains(character))
        {
            isCheck = false;
            break;
        }
    }

    return isCheck;
}

System.Console.WriteLine($"Title: {tomlFile.Title}");
System.Console.WriteLine($"Content: {tomlFile.Content}");
System.Console.WriteLine($"Count: {tomlFile.Count}");
System.Console.WriteLine($"Amount: {tomlFile.Amount}");
System.Console.WriteLine($"Date: {tomlFile.Date}");
System.Console.WriteLine($"Database Server:{tomlFile.Database.Server}");
System.Console.WriteLine($"FTP Server: {tomlFile.Ftp.Server}");

public enum ValueTypes
{
    String = 0,
    Int = 1,
    Double = 2,
    Datetime = 3
}