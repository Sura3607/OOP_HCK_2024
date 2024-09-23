using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class FarmState
    {
        private Product currentProduct;
        private Grid Grid = new Grid();
        public Product GetPlan(int x, int y)
        {
            return Grid.GetCell(x, y);
        }
        public bool CanSeed(int x, int y)
        {
            return Grid.IsCellEmpty(x, y);
        }
        public void Update()
        {
            Grid.PrintGrid();
        }
        public void UpdateCell(int x, int y, Product product)
        {
            Grid.SetCell(x, y, product);
        }
    }
}
