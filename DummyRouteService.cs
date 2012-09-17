using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication5
{
  public class DummyRouteService : IRouteService
  {
    public IEnumerable<ContentRouteData> GetRoutes()
    {
      return new[] {
        new ContentRouteData { Url = "/nl/bla", Controller = "TextPage", Action = "Index", Constraints = new Dictionary<string, string> { { "pageid", "12345" } } }
      };
    }
  }
}
