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
        public Sunflower(): base(20, 25, 1, 1)
        {
            Num_fetilizer = 2;
            Num_water = 1;
        }
        public void feed()
        {
            if (Num_fetilizer <= 0)
            {
                string message = "Đã bón đủ phân.";
                throw new Exception(message);
            }
            Num_fetilizer--;
        }
        public void prov_water()
        {
            if (Num_water <= 0)
            {
                string message = "Đã tưới đủ nước.";
                throw new Exception(message);
            }
            Num_water--;
        }
        public bool CanHarvest()
        {
            if(Num_fetilizer == 0 && Num_water == 0)
                return true;
            return false;
        }
        public override float harvest()
        {
            return Value;
        }
        public override void seed()
        {
            Start = DateTime.Now;
            Duration = Start.AddSeconds(40);
            Console.WriteLine("Đã trồng thành công Sunflower.");
        }
    }
}
