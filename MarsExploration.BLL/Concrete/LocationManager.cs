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
        public Position SetLocation(Position position)
        {
            try
            {
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
            catch (Exception ex)
            {
                throw new NotFoundCommandException();
            }
            return position;
        }

        private void SetCommand(Position position)
        {

            switch (position.location)
            {
                case LocationEnum.N: position.yCoordinate = position.yMarsCoordinate >= (position.yCoordinate + 1) ? (position.yCoordinate + 1) : position.yCoordinate; break;
                case LocationEnum.S: position.yCoordinate = position.yMarsCoordinate >= (position.yCoordinate - 1) && (position.yCoordinate - 1) >= 0 ? (position.yCoordinate - 1) : position.yCoordinate; break;
                case LocationEnum.E: position.xCoordinate = position.xMarsCoordinate >= (position.xCoordinate + 1) ? (position.xCoordinate + 1) : position.xCoordinate; break;
                case LocationEnum.W: position.xCoordinate = position.xMarsCoordinate >= (position.xCoordinate - 1) && (position.xCoordinate - 1)>=0 ? (position.xCoordinate - 1) : position.xCoordinate; break;
            }
        }

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
                case "NF": position.location = LocationEnum.N; break;
            }
        }
    }
}
