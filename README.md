RoutingAndCaching
=================
I've created this example project to show how we've done routing for dynamic cms pages with unknown urls.
Several standard CMSs handle this with a kind of special 404 page, or a catch all route at the end of
ASP.NET's Routing table. I prefer to know exactly which pages there are up front, cache the urls and then
insert my own RouteBase implementation at the exact place in the Routing table where you want it.

I've added the CmsPageRoute.cs file which shows how the urls are cached and how this nicely integrates into
ASP.NET's RouteData. You can see it allows the custom ContentRouteData to specify which controller is needed
to be used.  
This allows for custom conventions to be programmed by the implementation of IRouteService.

Note that CmsPageRout.cs does not have any dependency on IRouteService. You could even take out the
PrepareRouteData and move it to a different class if needed (I didn't want to overengineer this example).
