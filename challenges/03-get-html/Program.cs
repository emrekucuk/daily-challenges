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

var dolarIndex = document.IndexOf($"{"USDTRY"}");
var dolarBuyingAndSelling = document.Substring(dolarIndex + 8, 30);
System.Console.WriteLine($"Dolar: {dolarBuyingAndSelling}");

var euroIndex = document.IndexOf($"{"EURTRY"}");
var euroBuyingAndSelling = document.Substring(euroIndex + 8, 30);
System.Console.WriteLine($"Euro: {euroBuyingAndSelling}");
