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
    //[Route("home/")]
    //[Produces("application/json")]
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
            try
            {
                if (ModelState.IsValid)
                {
                    LocationEnum location = (LocationEnum)Enum.Parse(typeof(LocationEnum), locationModel.StPosition);
                    Position position = new Position(locationModel.StStartX, locationModel.StStartY, location, locationModel.StCommand, locationModel.StMarsX, locationModel.StMarsY);
                    newPosition = _locationManager.SetLocation(position);
                    return Json((object)new
                    {
                        data = "[" + newPosition.xCoordinate + "," + newPosition.yCoordinate + "] " + newPosition.location,
                        message = newPosition == null ? "işlme başarısız!" : "işlme başarılı",
                        success = newPosition == null ? "false" : "true",
                        redirectUrl = "",
                    });
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Coordinate_Out_bounds")
                {
                    return Json((object)new
                    {
                        data = "[Coordinate_Out_bounds]",
                        message = "Başlangıç koordinatların büyük koordinat girildi.",
                        success = "false",
                        redirectUrl = "",
                    });
                }
            }
            return Json((object)new
            {
                data = "NULL",
                message = "işlme başarısız! alanları kontorl ediniz",
                success = "false",
                redirectUrl = "",
            });

        }
    }
}
