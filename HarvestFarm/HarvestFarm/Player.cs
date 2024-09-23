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
        public Dictionary<Product, int> Inventory { get; private set; } 
        public Player(string name)
        {
            Name = name;
            Reward = 50;
            Inventory = new Dictionary<Product, int>();
            State = new FarmState();
            State.Update();
        }
        public void Buy(Product product, int sl)
        {
            if (Reward < product.Cost)
            {
                string message = "Không đủ tiền.";
                throw new Exception(message);
            }
            Reward -= product.Cost;
            if (Inventory.ContainsKey(product))         
                Inventory[product] += sl;            
            else            
                Inventory[product] = sl;            
        }
        public void Feed(Product product, int x, int y)
        {
            if (Reward < product.Fetilizer)
            {
                string message = "Không đủ tiền.";
                throw new Exception(message);
            }
            Reward -= product.Fetilizer;
            if (product.GetType() == typeof(Sunflower))
                ((Sunflower)product).feed();
            else if (product.GetType() == typeof(Tomato))
                ((Tomato)product).feed();
            else
                ((Wheat)product).feed();
            State.UpdateCell(x, y, product);
        }
        public void Prov_water(Product product, int x, int y)
        {
            if (Reward < product.Water)
            {
                string message = "Không đủ tiền.";
                throw new Exception(message);
            }
            Reward -= product.Water;
            if (product.GetType() == typeof(Sunflower))
                ((Sunflower)product).prov_water();
            else if (product.GetType() == typeof(Tomato))
                ((Tomato)product).prov_water();
            else
                ((Wheat)product).prov_water();
            State.UpdateCell(x, y, product);
        }
        public void Seed(Product product, int x, int y)
        {
            if(!State.CanSeed(x, y))
            {
                string message = "Ô này hiện đang có cây.";
                throw new Exception(message);
            }
            if (product.GetType() == typeof(Sunflower))
                ((Sunflower)product).seed();
            else if (product.GetType() == typeof(Tomato))
                ((Tomato)product).seed();
            else
                ((Wheat)product).seed();
            Inventory[product]--;
            State.UpdateCell(x, y, product);
        }
        public void Harvest(Product product)
        {
            float profit = 0;
            if(product.GetType() == typeof(Sunflower))
                profit += ((Sunflower)product).harvest();
            else if (product.GetType() == typeof(Tomato))
                profit += ((Tomato)product).harvest();
            else
                profit += ((Wheat)product).harvest();
            Reward += profit;
            Console.WriteLine($"Lợi nhuận thu hoạch: {profit}, Điểm thưởng hiện tại: {Reward}");
        }
    }
}
