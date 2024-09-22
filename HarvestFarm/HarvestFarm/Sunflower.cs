using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Sunflower : Product
    {
        public int Num_fetilizer { get; private set; }
        public int Num_water { get; private set; }
        public Sunflower(float cost, float value, float fetilizer, float water)
                    : base(cost, value, 15, fetilizer, water)
        {
            Num_fetilizer = 0;
            Num_water = 0;
        }
        public void feed()
        {
            Num_fetilizer++;
        }
        public void prov_water()
        {
            Num_water++;
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
