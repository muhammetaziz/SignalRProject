﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Title1 { get; set; } = string.Empty;
        public string Description1 { get; set; } = string.Empty;
        public string Title2 { get; set; } = string.Empty;
        public string Description2 { get; set; } = string.Empty;
        public string Title3 { get; set; } = string.Empty;
        public string Description3 { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}
