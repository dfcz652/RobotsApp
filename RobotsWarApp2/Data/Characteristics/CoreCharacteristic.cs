using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Enums;

namespace RobotsWarApp2.Data.Characteristics
{
    internal class CoreCharacteristic : ICharacteristics
    {

        public CoreCharacteristic()
        {
        }

        public Dictionary<string, int> GetCharacteristics(ECoreType eCoreType)
        {
            return eCoreType switch
            {
                ECoreType.Light => new Dictionary<string, int> { { "Energy", 4 }, { "EnergyRestoration", 2 } },
                ECoreType.Medium => new Dictionary<string, int> { { "Energy", 6 }, { "EnergyRestoration", 3 } },
                ECoreType.Heavy => new Dictionary<string, int> { { "Energy", 8 }, { "EnergyRestoration", 4 } },
            };
        }
    }
}
