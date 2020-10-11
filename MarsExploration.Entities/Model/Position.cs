using MarsExploration.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.Entities.Model
{
    public class Position
    {
        public Position(int xCoordinate, int yCoordinate, LocationEnum location, String commands, CommandEnum command=0)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.location = location;
            this.command = command;
            this.commands = commands;
        }

        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public LocationEnum location { get; set; }
        public CommandEnum command { get; set; }
        public string commands { get; set; }
        public string locationAndCommand { get { return location.ToString() + command.ToString(); } }
    }
}
