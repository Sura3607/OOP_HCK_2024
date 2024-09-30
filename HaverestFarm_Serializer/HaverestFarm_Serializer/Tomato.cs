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
    public class Tomato : Product,ISerializable
    {
        [DataMember]
        public int Num_fetilizer { get; private set; }
        [DataMember] 
        public int Num_water { get; private set; }
        public Tomato(): base(10, 20, 0.2f, 0.5f)
        {
            Num_fetilizer = 1;
            Num_water = 1;
        }
        public Tomato(SerializationInfo info, StreamingContext context)
            : base(10, 20, 0.2f, 0.5f, info, context)
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
            Duration = Start.AddSeconds(15);
            Console.WriteLine("Đã trồng thành công Tomato.");
        }
    }
}
