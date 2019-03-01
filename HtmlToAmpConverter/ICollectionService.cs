using HtmlToAmpConverter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Builder
{
  public static class IServiceCollectionExtensions
  {
    public static IServiceCollection ConfigureBBCodeHandler(this IServiceCollection services)
    {
      services.ConfigureBBCodeHandler(options => { });
      return services;
    }

    public static IServiceCollection ConfigureBBCodeHandler(this IServiceCollection services, Action<HtmlToAmpOptions> configureOptions)
    {
      // Default BBCodeHandler loading
      services.AddSingleton<HtmlToAmp>();


      var options = new HtmlToAmpOptions();

      // Add the default renderers
      options.AddBBCodeRenderer<FormBBCodeRenderer>("form");
      options.AddBBCodeRenderer<GalleryBBCodeRenderer>("slideshow");
      options.AddBBCodeRenderer<LiveBBCodeRenderer>("live");
      options.AddBBCodeRenderer<SurveyBBCodeRenderer>("survey");


      // Invoke the options delegate
      configureOptions.Invoke(options);

      foreach (var renderer in options.BBCodeRenderers)
        services.AddScoped(renderer.Value);

      // Register the default BBCode renderers
      services.AddScoped<IDictionary<string, IBBCodeRenderer>>(c =>
      {
        var dic = new Dictionary<string, IBBCodeRenderer>();
        foreach (var renderer in options.BBCodeRenderers)
        {
          dic.Add(renderer.Key, c.GetService(renderer.Value) as IBBCodeRenderer);
        }

        return dic;
      }
      );

      return services;
    }
  }
}
