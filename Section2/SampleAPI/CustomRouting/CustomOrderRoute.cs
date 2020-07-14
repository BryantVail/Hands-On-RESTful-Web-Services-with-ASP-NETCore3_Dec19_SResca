using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.CustomRouting
{
    public class CustomOrderRoute : Attribute, IRouteTemplateProvider
    {

        public string Template => "api/orders";

        public int? Order { get; set; }

        public string Name => "Orders_route";
    }
}
