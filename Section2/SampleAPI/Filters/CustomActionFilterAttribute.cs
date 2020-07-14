using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Filters
{
    public class CustomActionFilterAttribute : TypeFilterAttribute
    {

        //run TypeFilterAttribute constructor & pass in concrete filter to base()
        public CustomActionFilterAttribute() : base(typeof(CustomActionFilterAsync))
        {

        }

    }
}
