using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.Entities.Model
{
    public class LocationModel
    {
        public int StMarsX { get; set; }
        public int StMarsY { get; set; }
        public int StStartX { get; set; }
        public int StStartY { get; set; }
        public string StPosition { get; set; }
        public string StCommand { get; set; }
    }
}
