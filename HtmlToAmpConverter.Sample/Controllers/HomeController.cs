using HtmlToAmpConverter.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;

namespace HtmlToAmpConverter.Sample.Controllers
{
  public class HomeController : Controller
  {
    private HtmlToAmp _htmlToAmp;

    public HomeController(HtmlToAmp htmlToAmp)
    {
      _htmlToAmp = htmlToAmp;
    }

    public IActionResult Index(string doc = "doc1")
    {

      var model = new IndexViewModel();
      try
      {
        var client = new WebClient();
        string html = client.DownloadString($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/documents/{doc}.html");
        var startTime = DateTime.Now.Millisecond;
        var output = _htmlToAmp.ConvertToAmp(html);
        model.Messages = output.Messages;
        model.Content = output.Result;
        model.Timer = (DateTime.Now.Millisecond - startTime);
      }
      catch
      {
        model.Content = "Erreur lors de la récupération du document";
      }
      return View(model);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
