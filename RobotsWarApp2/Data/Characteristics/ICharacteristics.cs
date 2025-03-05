using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Enums;

namespace RobotsWarApp2.Data.Characteristics
{
    internal interface ICharacteristics
    {

        Dictionary<string, int> GetCharacteristics(ECoreType eCoreType);
    }
}
