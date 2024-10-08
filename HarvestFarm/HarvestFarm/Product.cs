﻿using System;
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
        public DateTime Start {  get; internal set; }
        public DateTime Duration {  get; internal set; }
        public float Fetilizer { get; private set; }
        public float Water {  get; private set; }
        public Product(float cost, float value, float fetilizer, float water)
        {
            Cost = cost;
            Value = value;
            Fetilizer = fetilizer;
            Water = water;
        }
        public abstract void seed();
        public abstract float harvest();

    }
}
