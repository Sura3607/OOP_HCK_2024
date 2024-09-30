using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HarvestFarm_Serializer
{
    [DataContract]
    [Serializable]
    public class Sunflower : Product, ISerializable
    {
        [DataMember]
        public int Num_fetilizer { get; private set; }
        [DataMember]
        public int Num_water { get; private set; }
        public Sunflower(): base(20, 25, 1, 1)
        {
            Num_fetilizer = 2;
            Num_water = 1;
        }
        public Sunflower(SerializationInfo info, StreamingContext context)
            : base(20, 25, 1, 1, info, context) 
        {
            Num_fetilizer = info.GetInt32("Num_fetilizer");
            Num_water = info.GetInt32("Num_water");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Num_fetilizer", Num_fetilizer);
            info.AddValue("Num_water", Num_water);
        }
        public void feed()
        {
            if (Num_fetilizer <= 0)
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
            Duration = Start.AddSeconds(40);
            Console.WriteLine("Đã trồng thành công Sunflower.");
        }
    }
}
