using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarsExploration.Models;
using MarsExploration.Entities.Model;
using MarsExploration.BLL.Abstract;
using MarsExploration.Entities.Enum;

namespace MarsExploration.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILocationManager _locationManager;

        public HomeController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        public IActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();
            return View(model);
        }



        //[HttpPost("save")]
        public JsonResult CreateLocation([FromBody]LocationModel locationModel)
        {
            Position newPosition = null;
            if (ModelState.IsValid)
            {
                LocationEnum location = (LocationEnum)Enum.Parse(typeof(LocationEnum), locationModel.StPosition);
                Position position = new Position(locationModel.StStartX, locationModel.StStartY, location, locationModel.StCommand, locationModel.StMarsX, locationModel.StMarsY);
                newPosition = _locationManager.SetLocation(position);
            }

            return Json((object)new
            {
                data = "[" + newPosition.xCoordinate + "," + newPosition.yCoordinate + "] " + newPosition.location,
                message = "işlme başarılı",
                success = newPosition == null ? "false" : "true",
                redirectUrl = "",
            });

        }

    }
}
