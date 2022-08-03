using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Web.Mvc;
using Parser;


string html = "https://en.wikipedia.org/wiki/Tea";
HtmlDocument document = new HtmlDocument();
HtmlWeb web = new HtmlWeb();
document = web.Load(html);

HtmlNodeCollection TeaElements = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul[1]/li");
List<Tea> teaList = new List<Tea>();
// Проверяем наличие узлов

if (TeaElements != null)
{
    foreach (HtmlNode teaString in TeaElements)
    {
        Tea tea = new Tea();
        string outputText = teaString.InnerText;
        string[] parseTeaString = outputText.Split(':');
        tea.Name = parseTeaString[0];
        tea.Description = parseTeaString[1];
        teaList.Add(tea);
    }
}

/*string html = "https://en.wikipedia.org/wiki/Tea";
HtmlDocument document = new HtmlDocument();
HtmlWeb web = new HtmlWeb();
*//*{
    AutoDetectEncoding = false,
    OverrideEncoding = Encoding.UTF8,
};*//*
document = web.Load(html);

// Собственно, здесь и производится выборка интересующих нам нодов
// В данном случае выбираем блочные элементы с классом eTitle
HtmlNodeCollection NoAltElements = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul[1]/li/a");
HtmlNodeCollection NoAltElements1 = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul[1]/li/text()");
HtmlNodeCollection NoAltElements2 = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul[1]/li");
List<Tea> teaList=new List<Tea>();
// Проверяем наличие узлов
if (NoAltElements != null && NoAltElements1 != null)
{
    foreach (HtmlNode HN in NoAltElements)
    {
        // Получаем строчки
        string outputText = HN.InnerText;
        Console.WriteLine(outputText);
    }
}
Console.WriteLine("\n");
if (NoAltElements1 != null)
{
    foreach (HtmlNode HN in NoAltElements1)
    {
        // Получаем строчки
        string outputText = HN.InnerText;
        Console.WriteLine(outputText);
    }
}
Console.WriteLine("\n");
if (NoAltElements2 != null)
{
    foreach (HtmlNode HN in NoAltElements2)
    {
        Tea tea = new Tea();
        // Получаем строчки
        string outputText = HN.InnerText;
        //Console.WriteLine(outputText);
        string[] words = outputText.Split(':');
        tea.Name=words[0];
        tea.Description=words[1];
       // tea.toStr();
        teaList.Add(tea);

    }
}

foreach (Tea tea in teaList)
{
    Console.WriteLine(tea.toStr());
}*/
/*string html = "https://en.wikipedia.org/wiki/Computer";
HtmlDocument document = new HtmlDocument();
var web = new HtmlWeb
{
    AutoDetectEncoding = false,
    OverrideEncoding = Encoding.UTF8,
};
document = web.Load(html);

// Собственно, здесь и производится выборка интересующих нам нодов
// В данном случае выбираем блочные элементы с классом eTitle
HtmlNodeCollection NoAltElements = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul[2]/li/a");
HtmlNodeCollection NoAltElements1 = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul[1]/li[4]");

// Проверяем наличие узлов
if (NoAltElements != null)
{
    foreach (HtmlNode HN in NoAltElements)
    {
        // Получаем строчки
        string outputText = HN.InnerText;
        Console.WriteLine(outputText);
    }
}
Console.WriteLine("\n");
if (NoAltElements1 != null)
{
    foreach (HtmlNode HN in NoAltElements1)
    {
        // Получаем строчки
        string outputText = HN.InnerText;
        Console.WriteLine(outputText);
    }
}
*/


//*[@id="mw-content-text"]/div[1]/ul[1]/li[1]/a[1]
/*HtmlWeb web = new HtmlWeb();
var htmlDoc = web.Load(@"https://en.wikipedia.org/wiki/Tea");

string name = htmlDoc.DocumentNode
    .SelectSingleNode("//*[@id=\"mw - content - text\"]/div[1]/p[1]")

Console.WriteLine(name);*/

/*var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"mw - content - text\"]/div[1]/p[1]");

List<string> info = new List<string>();

if (nodes is not null)
{
    foreach (HtmlNode item in nodes)
    {
        info.Add(item.InnerText);
        Console.WriteLine(item.InnerText);
    }
}*/

/*HtmlWeb web = new HtmlWeb();
var document = web.Load("https://en.wikipedia.org/wiki/Tea");

var title = document.DocumentNode.SelectNodes("//*[@id=\"firstHeading\"]").First().InnerText;


var paragraphs = document.DocumentNode.SelectNodes("//*[@id=\"mw - content - text\"]/div[1]/p");

Console.WriteLine(title);

paragraphs.ToList().ForEach(i => Console.WriteLine(i.InnerText));*/

/*var nodes = htmlDoc.DocumentNode.SelectNodes("//span[@class='catalog__title']");

List<string> info = new List<string>();

if (nodes is not null)
{
    foreach (HtmlNode item in nodes)
    {
        info.Add(item.InnerText);
    }
}
*/