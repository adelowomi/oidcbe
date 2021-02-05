using System.Collections.Generic;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {

        private readonly IDepartmentAppService _departmentAppService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="documentAppService"></param>
        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;

        }

        /// <summary>
        /// Get All Documents For Current Logged On User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/departments")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<DepartmentViewModel>>), 200)]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<DepartmentViewModel>>), 400)]
        public IActionResult GetDepartments()
        {
            return Ok(_departmentAppService.Departments());
        }

        /// <summary>
        ///  This method returns the raw file of an image, thereby mimicking access over web
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/departments/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<DepartmentViewModel>), 200)]
        [ProducesResponseType(typeof(SwaggerResponse<DepartmentViewModel>), 400)]
        public IActionResult GetDepartmentsBy(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_departmentAppService.DepartmentBy(id));
        }


        /// <summary>
        /// Get Document Link
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/departments/name/{name}")]
        [ProducesResponseType(typeof(SwaggerResponse<DepartmentViewModel>), 200)]
        [ProducesResponseType(typeof(SwaggerResponse<DepartmentViewModel>), 400)]
        public IActionResult GetDepartmentsBy(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_departmentAppService.DepartmentBy(0, name));
        }


        /// <summary>
        /// Get Document Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/departments/users/{id}")]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<DepartmentViewModel>>), 200)]
        [ProducesResponseType(typeof(SwaggerResponse<IEnumerable<DepartmentViewModel>>), 400)]
        public IActionResult GetUsersByDepartment(int id)
        {
            return Ok(_departmentAppService.GetUsersBy(id));
        }
    }
}
