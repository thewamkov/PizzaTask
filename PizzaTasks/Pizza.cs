﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTasks
{
    class Pizza
    {
        [JsonProperty("toppings")]
        public string[] Toppings { get; set; }
    }
}
