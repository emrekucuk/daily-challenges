using System.Text;
using System.Net;
using System.IO;


static string GetSourceCode(string url)
{
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

    using (StreamReader sRead = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
    {
        return sRead.ReadToEnd();
    }
}

string url = "https://bigpara.hurriyet.com.tr/doviz/";

string document = GetSourceCode(url);
System.Console.WriteLine(document);