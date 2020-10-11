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
        private readonly int[,] xyMarsCoordinate;
        private int XCoordinate = 5;
        private int YCoordinate = 5;
        public LocationManagerUTest()
        {
            _locationManager = new LocationManager();
            xyMarsCoordinate = new int[XCoordinate, YCoordinate];
        }

        /// <summary>
        /// 13N çıktısı
        /// </summary>
        [Fact]
        public void FirstTestMethod()
        {
            string commands = "LMLMLMLMM";
            var position = new Position(1, 2, LocationEnum.N, commands, XCoordinate, YCoordinate);
            var result = _locationManager.SetLocation(position);
            Assert.NotNull(result);
            var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            Assert.Equal("13N", resultJoin);
        }

        /// <summary>
        /// 51E çıktısı
        /// </summary>
        [Fact]
        public void SecondtTestMethod()
        {
            string commands = "MMRMMRMRRM";
            var position = new Position(3, 3, LocationEnum.E, commands, XCoordinate, YCoordinate);
            var result = _locationManager.SetLocation(position);
            Assert.NotNull(result);
            var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            Assert.Equal("51E", resultJoin);
        }

        /// <summary>
        /// Tanımlanmayan bir komut ile işlem yapma
        /// </summary>
        [Fact]
        public void NotFoundComnmanTestMethod()
        {
            try
            {
                string commands = "LMÖÇ";
                var position = new Position(3, 3, LocationEnum.E, commands, XCoordinate, YCoordinate);
                var result = _locationManager.SetLocation(position);
                Assert.NotNull(result);
                var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            }
            catch (Exception ex)
            {
                Assert.Equal("Not_Found_Command", ex.Message);
            }
        }

        /// <summary>
        /// Başlangıç koordinatlarında büyük koordinat girince
        /// </summary>
        [Fact]
        public void XYComnmanTestMethod()
        {
            try
            {
                string commands = "LMR";
                var position = new Position(6, 6, LocationEnum.E, commands, XCoordinate, YCoordinate);
                var result = _locationManager.SetLocation(position);
                Assert.NotNull(result);
                var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            }
            catch (Exception ex)
            {
                Assert.Equal("Coordinate_Out_bounds", ex.Message);
            }
        }

        /// <summary>
        /// Komut Null olma durumu
        /// </summary>
        [Fact]
        public void NullCommandTest()
        {
            string commands = "";
            var position = new Position(4, 3, LocationEnum.E, commands, XCoordinate, YCoordinate);
            var result = _locationManager.SetLocation(position);
            Assert.NotNull(result);
            var resultJoin = result.xCoordinate.ToString() + result.yCoordinate.ToString() + result.location.ToString();
            Assert.Equal("43E", resultJoin);
        }

    }
}
