using System.Collections.Generic;
using System.Linq;

namespace IfmoSchedule.Karma
{
    public class KarmaModel
    {
        //Data[to][from] => value
        public Dictionary<string, Dictionary<string, int>> Data;
        //public List<string> Keys => Data.Keys.ToList();
    }
}