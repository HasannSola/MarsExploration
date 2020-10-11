using MarsExploration.BLL.Abstract;
using MarsExploration.BLL.Concrete;
using MarsExploration.Entities.Enum;
using MarsExploration.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsExploration.UTest.LocationTest
{
    public class LocationManagerUTest
    {
        private readonly ILocationManager _locationManager;
        private readonly int[,] MarsCoordinate;

        public LocationManagerUTest()
        {
            _locationManager = new LocationManager();
            MarsCoordinate = new int[5, 5];
        }

        [Fact]
        public void FirstTestMethod()
        {
            string commands = "LMLMLMLMM";
            var position = new Position(1, 2, LocationEnum.N, commands);
            var result = _locationManager.SetLocation(position);
            Assert.NotNull(result);
            var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            Assert.Equal("13N", resultJoin);
        }

        [Fact]
        public void SecondtTestMethod()
        {
            string commands = "MMRMMRMRRM";
            var position = new Position(3, 3, LocationEnum.E, commands);
            var result = _locationManager.SetLocation(position);
            Assert.NotNull(result);
            var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            Assert.Equal("51E", resultJoin);
        }


        [Fact]
        public void NotFoundComnmanTestMethod()
        {
            try
            {
                string commands = "LMÖÇ";
                var position = new Position(3, 3, LocationEnum.E, commands);
                var result = _locationManager.SetLocation(position);
                Assert.NotNull(result);
                var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            }
            catch (Exception ex)
            {
                Assert.Equal("Not_Found_Command", ex.Message);
            }
        }

        [Fact]
        public void XYComnmanTestMethod()
        {
            try
            {
                string commands = "LMR";
                var position = new Position(5, 6, LocationEnum.E, commands);
                var result = _locationManager.SetLocation(position);
                Assert.NotNull(result);
                var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            }
            catch (Exception ex)
            {
                Assert.Equal("Not_Found_Command", ex.Message);
            }
        }

    }
}
