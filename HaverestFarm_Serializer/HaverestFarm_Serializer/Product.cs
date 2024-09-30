using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HarvestFarm_Serializer
{
    [DataContract]
    [Serializable]
    public abstract class Product : ISerializable
    {
        public float Cost { get; private set; }
        public float Value { get; private set; }
        [DataMember]
        public DateTime Start {  get; internal set; }
        [DataMember]
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

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Start", Start);
            info.AddValue("Duration", Duration);
        }
        public Product(float cost, float value, float fetilizer, float water, SerializationInfo info, StreamingContext context)
        {
            Cost = cost;
            Value = value;
            Fetilizer = fetilizer;
            Water = water;
            Start = (DateTime)info.GetValue("Start", typeof(DateTime));
            Duration = (DateTime)info.GetValue("Duration", typeof(DateTime));
        }
    }
}
