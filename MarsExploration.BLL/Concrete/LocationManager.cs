using MarsExploration.BLL.Abstract;
using MarsExploration.Core.ExceptionHandling;
using MarsExploration.Entities.Enum;
using MarsExploration.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.BLL.Concrete
{
    public class LocationManager : ILocationManager
    {
        /// <summary>
        /// Gelen Komutları ayrıştırıp yön ve mesafe fonksiyonara yönlendirme
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Position SetLocation(Position position)
        {
            try
            {
                if (position.xMarsCoordinate < position.xCoordinate || position.yMarsCoordinate < position.yCoordinate)
                {
                    throw new CoordinateException();
                }

                for (int i = 0; i < position.commands.Length; i++)
                {
                    position.command = (CommandEnum)Enum.Parse(typeof(CommandEnum), position.commands[i].ToString());
                    if (position.command != CommandEnum.M)
                    {
                        ///
                        /// L , R göre robotun gideceği yönü bulma
                        ///
                        FindLocation(position);
                    }
                    else
                    {
                        ///
                        ///N,S,W ve E göre bir birim hareket yapma
                        ///
                        SetCommand(position);
                    }
                }
            }
            catch (CoordinateException ex)
            {
                throw ex;
            }           
            catch (Exception ex)
            {

                throw new NotFoundCommandException();
            }
            return position;
        }

        /// <summary>
        /// Gelen komutlara göre birim ilerleme , başlangıç koordinatlarında büyük değer alamaz!
        /// </summary>
        /// <param name="position"></param>
        private void SetCommand(Position position)
        {
            switch (position.location)
            {
                case LocationEnum.N: position.yCoordinate = position.yMarsCoordinate >= (position.yCoordinate + 1) ? (position.yCoordinate + 1) : position.yCoordinate; break;
                case LocationEnum.S: position.yCoordinate = position.yMarsCoordinate >= (position.yCoordinate - 1) && (position.yCoordinate - 1) >= 0 ? (position.yCoordinate - 1) : position.yCoordinate; break;
                case LocationEnum.E: position.xCoordinate = position.xMarsCoordinate >= (position.xCoordinate + 1) ? (position.xCoordinate + 1) : position.xCoordinate; break;
                case LocationEnum.W: position.xCoordinate = position.xMarsCoordinate >= (position.xCoordinate - 1) && (position.xCoordinate - 1) >= 0 ? (position.xCoordinate - 1) : position.xCoordinate; break;
            }
        }

        /// <summary>
        /// Gelen komutlara göre yön tayinin yapılması
        /// </summary>
        /// <param name="position"></param>
        private void FindLocation(Position position)
        {

            switch (position.locationAndCommand)
            {
                case "NL":
                case "SR": position.location = LocationEnum.W; break;
                case "NR":
                case "SL": position.location = LocationEnum.E; break;
                case "EL":
                case "WR": position.location = LocationEnum.N; break;
                case "ER":
                case "WL": position.location = LocationEnum.S; break;
            }
        }
    }
}
