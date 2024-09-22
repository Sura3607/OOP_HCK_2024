using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public abstract class Product
    {
        public float Cost { get; private set; }
        public float Value { get; private set; }
        public DateTime Start {  get; private set; }
        public DateTime Duration {  get; private set; }
        public float Fetilizer { get; private set; }
        public float Water {  get; private set; }
        public Product(float cost, float value, int durationSeconds, float fetilizer, float water)
        {
            Cost = cost;
            Value = value;
            Start = DateTime.Now;
            Duration = Start.AddSeconds(durationSeconds);
            Fetilizer = fetilizer;
            Water = water;
        }
        public abstract void seed();
        public abstract int harvest();

    }
}
