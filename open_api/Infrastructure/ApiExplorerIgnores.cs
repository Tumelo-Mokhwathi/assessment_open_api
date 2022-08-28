using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace open_api.Infrastructure
{
    public class ApiExplorerIgnores : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action.Controller.ControllerName.Equals("Error"))
                action.ApiExplorer.IsVisible = false;
        }
    }
}
