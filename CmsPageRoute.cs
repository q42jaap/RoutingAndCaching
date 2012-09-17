using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Threading;
using System.Web.Mvc;

namespace MvcApplication5
{
  public class CmsPageRoute : RouteBase
  {
    private IRouteService routeService;
    private Dictionary<string, RouteData> _urlsToRouteData;

    public CmsPageRoute(IRouteService routeService)
    {
      this.routeService = routeService;
      this.SetCmsRoutes();
    }

    public void SetCmsRoutes()
    {
      var urlsToRouteData = new Dictionary<string, RouteData>();
      foreach (var route in this.routeService.GetRoutes()) // gets RouteData for CMS pages from database
      {
        urlsToRouteData.Add(route.Url, PrepareRouteData(route));
      }

      Interlocked.Exchange(ref _urlsToRouteData, urlsToRouteData);
    }

    public override RouteData GetRouteData(System.Web.HttpContextBase httpContext)
    {
      RouteData routeData;
      if (_urlsToRouteData.TryGetValue(httpContext.Request.Path, out routeData))
        return routeData;
      else
        return null;
    }

    public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
    {
      return null;
    }

    private RouteData PrepareRouteData(ContentRouteData contentRoute)
    {
      var routeData = new RouteData(this, new MvcRouteHandler());

      routeData.Values.Add("controller", contentRoute.Controller);
      routeData.Values.Add("action", contentRoute.Action);
      routeData.Values.Add("area", contentRoute.Area);
      routeData.Values.Add("pageid", contentRoute.Constraints["pageid"]); // variable for identifying page id in controller method
      routeData.Values.Add("lang", contentRoute.Lang);

      routeData.DataTokens.Add("Namespaces", new[] { contentRoute.Namespace });
      routeData.DataTokens.Add("area", contentRoute.Area);

      return routeData;
    }

    // routes get periodically updated
    public void UpdateRoutes()
    {
      SetCmsRoutes();
    }
  }
}