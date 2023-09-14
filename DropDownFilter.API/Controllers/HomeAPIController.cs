using DropDownFilter.Models.Comman;
using DropDownFilter.Models;
using DropDownFilter.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DropDownFilter.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        private readonly IHomeHelper _homeHelper;
        public HomeAPIController(IHomeHelper homeHelper)
        {
            _homeHelper = homeHelper;
        }

        [Route("filter")]
        [HttpPost]
        public IActionResult Filter(DropDownModel dropDownModel)
        {
            Response response = new Response();
            try
            {
                var userdata = _homeHelper.Filter(dropDownModel);
                response.code = StatusCodes.Status200OK;
                response.status = true;
                response.message = "Success";
                response.data = userdata;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
