using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication5
{
  public class ContentRouteData
  {
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Area { get; set; }
    public Dictionary<string, string> Constraints { get; set; }
    public string Namespace { get; set; }
    public string Lang { get; set; }

    public string Url { get; set; }
  }
}
