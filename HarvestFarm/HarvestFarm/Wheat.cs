using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Wheat : Product
    {
        public int Num_fetilizer { get; private set; }
        public int Num_water { get; private set; }
        public Wheat() : base(15, 18, 1f, 2f)
        {
            Num_fetilizer = 1;
            Num_water = 2;
        }
        public void feed()
        {
            if(Num_fetilizer <= 0)
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
            return Num_fetilizer == 0 && Num_water == 0 && DateTime.Now >= Duration;
        }
        public override float harvest()
        {
            return Value;
        }

        public override void seed()
        {
            Start = DateTime.Now;
            Duration = Start.AddSeconds(30);
            Console.WriteLine("Đã trồng thành công Wheat.");
        }
    }
}
