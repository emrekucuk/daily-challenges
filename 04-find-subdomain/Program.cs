string url = "https://web.emrekucuk.com.tr";

var parts = url.Split('/');
var domain = parts[2];
var domainParts = domain.Split('.');

System.Console.WriteLine($"subdomain: {domainParts[0]}");