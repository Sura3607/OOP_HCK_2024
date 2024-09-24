using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class FarmState
    {
        private Grid Grid = new Grid();
        public Product GetPlan(int x)
        {
            return Grid.GetCell(x);
        }
        public bool CanSeed(int x)
        {
            return Grid.IsCellEmpty(x);
        }
        public void Update()
        {
            Grid.PrintGrid();
        }
        public void UpdateCell(int x, Product product)
        {
            Grid.SetCell(x, product);
        }
    }
}
