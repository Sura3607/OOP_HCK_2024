using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Grid
    {
        private int y = 5; // cột
        private int x = 3; // hàng
        private Product[,] grid;
        public Grid()
        {
            grid = new Product[x,y];
        }
        public void SetCell(int x, int y, Product product)
        {
            //hnagf x cột y 
            if (x < 1 || x > this.x || y < 1 || y > this.y)
            {
                throw new ArgumentOutOfRangeException("Tọa độ hông hợp lệ.");
            }
            grid [x -1, y - 1] = product;
        }
        public Product GetCell(int x, int y)
        {
            if (x < 1 || x > this.x || y < 1 || y > this.y)
            {
                throw new ArgumentOutOfRangeException("Tọa độ hông hợp lệ.");
            }
            return grid[x-1, y-1];
        }
        public bool IsCellEmpty(int x, int y)
        {
            if (x < 1 || x > this.x || y < 1 || y > this.y)
            {
                throw new ArgumentOutOfRangeException("Tọa độ hông hợp lệ.");
            }
            return grid[x - 1, y - 1] == null;
        }

        // Trả về toàn bộ lưới
        public Product[,] GetGrid()
        {
            return grid;
        }
        public void PrintGrid()
        {
            for (int i = 0; i < this.x; i++)
            {
                for (int j = 0; j < this.y; j++)
                {
                    Product product = grid[i, j]; 

                    if (product == null)
                    {
                        Console.Write(". "); 
                    }
                    else if (product is Sunflower)
                    {
                        Console.Write("S "); 
                    }
                    else if (product is Wheat)
                    {
                        Console.Write("W "); 
                    }
                    else if (product is Tomato)
                    {
                        Console.Write("T "); 
                    }
                    else
                    {
                        Console.Write("? "); 
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
