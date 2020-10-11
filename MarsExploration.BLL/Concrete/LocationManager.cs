using MarsExploration.BLL.Abstract;
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
            for (int i = 0; i < position.commands.Length; i++)
            {
                position.command = (CommandEnum)Enum.Parse(typeof(CommandEnum),position.commands[i].ToString());
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
            return position;
        }

        private void SetCommand(Position position)
        {
            switch (position.location)
            {
                case LocationEnum.N: position.yCoordinate = position.yCoordinate + 1; break;
                case LocationEnum.S: position.yCoordinate = position.yCoordinate - 1; break;
                case LocationEnum.E: position.xCoordinate = position.xCoordinate + 1; break;
                case LocationEnum.W: position.xCoordinate = position.xCoordinate - 1; break;
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
