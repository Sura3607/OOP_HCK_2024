using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Player
    {
        public string Name { get; private set; }
        public float Reward { get; private set; }
        public FarmState State { get; private set; }
        public ArrayList Inventory { get; private set; } 
        public ArrayList ArrayList { get; private set; }
        
        public Player(string name, int reward)
        {
            Name = name;
            Reward = reward;
            ArrayList = new ArrayList();
        }
        public void Buy(Product product)
        {
            if (Reward < product.Cost)
            {
                throw new ArgumentOutOfRangeException("Không đủ tiền.");
            }
            Reward -= product.Cost;
            Inventory.Add(product);
        }
        public void Harvest(Product product)
        {
            int profit = product.harvest();
            Reward += profit;
            Console.WriteLine($"Lợi nhuận thu hoạch: {profit}, Điểm thưởng hiện tại: {Reward}");
        }
    }
}
