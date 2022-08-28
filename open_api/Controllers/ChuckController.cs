using open_api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using open_api.Constants;
using open_api.Response;
using open_api.Services.Interface;
using System.IO;

namespace open_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private const string EndpointPrefix = General.apiPrefixName + "chuck.";

        private readonly IService _service;

        public ChuckController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> Get() =>
            ActionResponse.Success(
                HttpStatusCode.OK,
                await _service.GetCategoriesAsync().ConfigureAwait(false),
                $"{EndpointPrefix}getcategories");

    }
}
