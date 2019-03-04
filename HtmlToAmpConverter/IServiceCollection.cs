using HtmlToAmpConverter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Builder
{
  public static class IServiceCollectionExtensions
  {
    public static IServiceCollection AddHtmlToAmpConverter(this IServiceCollection services)
    {
      services.AddHtmlToAmpConverter(options => { });
      return services;
    }

    public static IServiceCollection AddHtmlToAmpConverter(this IServiceCollection services, Action<HtmlToAmpOptions> configureOptions)
    {
      // Default HtmlToAmp service loading
      services.AddTransient<HtmlToAmp>();

      // Setup configuration
      services.Configure<HtmlToAmpOptions>(configureOptions);

      // Get options
      var options = new HtmlToAmpOptions();
      configureOptions.Invoke(options);

      // Renderer
      foreach (var renderer in options.SanitizerTypes)
        services.AddTransient(renderer);

      // Register the default BBCode renderers
      services.AddTransient<HashSet<IHtmlToAmpSanitizer>>(c =>
      {
        var collection = new HashSet<IHtmlToAmpSanitizer>();
        foreach (var renderer in options.SanitizerTypes)
        {
          collection.Add(c.GetService(renderer) as IHtmlToAmpSanitizer);
        }

        return collection;
      }
      );

      return services;
    }
  }
}
