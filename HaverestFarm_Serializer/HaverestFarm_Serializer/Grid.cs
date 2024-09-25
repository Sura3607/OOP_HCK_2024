using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HarvestFarm_Serializer
{
    [DataContract]
    public class Grid
    {
        [DataMember]
        private ArrayList grid;
        public Grid()
        {
            grid = new ArrayList(5) { null, null, null, null, null };
        }
        public void SetCell(int x,Product product)
        {
            //hnagf x cột y 
            if (x < 1 || x > 5)
            {
                throw new ArgumentOutOfRangeException("Tọa độ hông hợp lệ.");
            }
            grid [x -1] = product;
        }
        public Product GetCell(int x)
        {
            if (x < 1 || x > 5)
            {
                throw new ArgumentOutOfRangeException("Tọa độ hông hợp lệ.");
            }
            return (Product)grid[x - 1];
        }
        public bool IsCellEmpty(int x)
        {
            if (x < 1 || x > 5)
            {
                throw new ArgumentOutOfRangeException("Tọa độ hông hợp lệ.");
            }
            return grid[x - 1] == null;
        }

        // Trả về toàn bộ lưới
        public ArrayList GetGrid()
        {
            return grid;
        }
        public void PrintGrid()
        {
            Console.WriteLine(new string('-', 50));
            Console.Write("\t");
            for (int i = 0; i < 5; i++)
            {
                Product product = (Product)grid[i];
                
                if (product == null)
                {
                    Console.Write("_");
                }
                else if (product is Sunflower)
                {
                    Console.ForegroundColor = SetColor((Sunflower)product);
                    Console.Write("S");
                }
                else if (product is Wheat)
                {
                    Console.ForegroundColor = SetColor((Wheat)product);
                    Console.Write("W ");
                }
                else if (product is Tomato)
                {
                    Console.ForegroundColor = SetColor((Tomato)product);
                    Console.Write("T ");
                }
                else
                {
                    Console.Write("? ");
                }
                Console.ResetColor();
                Console.Write("\t");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
        private ConsoleColor SetColor(Sunflower p)
        {
            if (p.CanHarvest())            
                return ConsoleColor.Green;
            if(p.Num_fetilizer == 0 && p.Num_water == 0)
                return ConsoleColor.White;
   
            if(p.Num_water >= p.Num_fetilizer)
                return ConsoleColor.Blue;
            else
                return ConsoleColor.Red;
        }
        private ConsoleColor SetColor(Tomato p)
        {
            if (p.CanHarvest())
                return ConsoleColor.Green;
            if (p.Num_fetilizer == 0 && p.Num_water == 0)
                return ConsoleColor.White;

            if (p.Num_water >= p.Num_fetilizer)
                return ConsoleColor.Blue;
            else
                return ConsoleColor.Red;
        }
        private ConsoleColor SetColor(Wheat p)
        {
            if (p.CanHarvest())
                return ConsoleColor.Green;
            if (p.Num_fetilizer == 0 && p.Num_water == 0)
                return ConsoleColor.White;

            if (p.Num_water >= p.Num_fetilizer)
                return ConsoleColor.Blue;
            else
                return ConsoleColor.Red;
        }
    }
}
