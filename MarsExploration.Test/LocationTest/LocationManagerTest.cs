using MarsExploration.BLL.Abstract;
using MarsExploration.BLL.Concrete;
using MarsExploration.Entities.Enum;
using MarsExploration.Entities.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.Test.LocationTest
{
    [TestClass]
    public class LocationManagerTest
    {
        private readonly ILocationManager _locationManager;
        private readonly int[,] MarsCoordinate;

        public LocationManagerTest()
        {
            _locationManager = new LocationManager();
             MarsCoordinate = new int[5, 5];
        }

        [TestMethod]
        public void FirstTestMethod()
        {
            string commands = "L;M;L;M;L;M;L;M;M";

            //ilk konumu al.
            Position locationManagerResult = new Position(1,2,LocationEnum.N,0);

            foreach (var item in commands.Split(';'))
            {
                CommandEnum command = (CommandEnum)Enum.Parse(typeof(CommandEnum), item);
               var position = new Position(locationManagerResult.xCoordinate, locationManagerResult.yCoordinate, locationManagerResult.location, command);
                locationManagerResult = _locationManager.SetLocation(position);
            }

            var test = locationManagerResult;//1 3 N

        }
        [TestMethod]
        public void SecondTestMethod()
        {
            string commands = "M;M;R;M;M;R;M;R;R;M";
            Position locationManagerResult = new Position(3, 3, LocationEnum.E, 0);

            foreach (var item in commands.Split(';'))
            {
                CommandEnum command = (CommandEnum)Enum.Parse(typeof(CommandEnum), item);
                var position = new Position(locationManagerResult.xCoordinate, locationManagerResult.yCoordinate, locationManagerResult.location, command);
                locationManagerResult = _locationManager.SetLocation(position);
            }

            var test = locationManagerResult;//5 1 E
        }
        [TestMethod]
        public void ThirdTestMethod()
        {
            string commands = "M,M;L;R;M;R;M;L;M";
            Position locationManagerResult = new Position(2, 3, LocationEnum.E, 0);

            foreach (var item in commands.Split(';'))
            {
                CommandEnum command = (CommandEnum)Enum.Parse(typeof(CommandEnum), item);
                var position = new Position(locationManagerResult.xCoordinate, locationManagerResult.yCoordinate, locationManagerResult.location, command);
                locationManagerResult = _locationManager.SetLocation(position);
            }

            var test = locationManagerResult;//5 2 E
        }
    }
}
