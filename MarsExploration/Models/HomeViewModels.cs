using MarsExploration.Core.Extensions;
using MarsExploration.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsExploration.Models
{
    public class HomeViewModels
    {
        public HomeViewModels()
        {
            locations = new Dictionary<string, string>();
            locations.Add(LocationEnum.N.ToString(), LocationEnum.N.GetDisplayName());
            locations.Add(LocationEnum.S.ToString(), LocationEnum.S.GetDisplayName());
            locations.Add(LocationEnum.W.ToString(), LocationEnum.W.GetDisplayName());
            locations.Add(LocationEnum.E.ToString(), LocationEnum.E.GetDisplayName());
        }
        public Dictionary<string, string> locations { get; set; }
    }
}
