using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using edxl_cap_v1_2.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace edxl_cap_v1_2.Controllers
{
    public class GetSelectedAlertIndexController : Controller
    {
        private readonly IGetSelectedAlertIndex _getSelectedAlertIndex;

        public GetSelectedAlertIndexController(IGetSelectedAlertIndex getSelectedAlertIndex)
        {
            _getSelectedAlertIndex = getSelectedAlertIndex;
        }

        // GET: /mydependency/
        public async Task<IActionResult> Index()
        {
            await _getSelectedAlertIndex.GetSelectedAlertIndex();

            return View();
        }
    }
}
