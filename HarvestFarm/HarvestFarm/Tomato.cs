using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Tomato : Product
    {
        public int Num_fetilizer { get; private set; }
        public int Num_water { get; private set; }
        public Tomato(float cost, float value, float fetilizer, float water)
                    : base(cost, value, 10, fetilizer, water)
        {
            Num_fetilizer = 0;
            Num_water = 0;
        }
        public bool feed()
        {
            return true;
        }
        public bool prov_water()
        {
            return true;
        }
        public override int harvest()
        {
            return 0;
        }

        public override void seed()
        {
            
        }
    }
}
