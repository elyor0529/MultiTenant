﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Model
{
    public class Link
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Name { get; set; }
    }
}
