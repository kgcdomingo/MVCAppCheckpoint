using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicianDirectory.Models
{
    public class MVCTabs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }
        public string Url { get; set; }
    }
}