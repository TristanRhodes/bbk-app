using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Basket
    {
        public Basket(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
