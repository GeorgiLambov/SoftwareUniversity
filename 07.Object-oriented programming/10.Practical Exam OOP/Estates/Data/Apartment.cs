using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Data;
using Estates.Interfaces;

namespace Estates
{
    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
        {
            this.Type = EstateType.Apartment;
        }
    }
}
