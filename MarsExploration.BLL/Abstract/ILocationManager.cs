using MarsExploration.Entities.Enum;
using MarsExploration.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.BLL.Abstract
{
    public interface ILocationManager
    {
        Position SetLocation(Position position);
    }
}
