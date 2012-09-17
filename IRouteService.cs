using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication5
{
  public interface IRouteService
  {

    IEnumerable<ContentRouteData> GetRoutes();
  }
}
