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
    public class Wheat : Product,ISerializable
    {
        [DataMember]
        public int Num_fetilizer { get; private set; }
        [DataMember]
        public int Num_water { get; private set; }
        public Wheat() : base(15, 18, 1f, 2f)
        {
            Num_fetilizer = 1;
            Num_water = 2;
        }
        public Wheat(SerializationInfo info, StreamingContext context)
            : base(15, 18, 1f, 2f, info, context)
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
            if(Num_fetilizer <= 0)
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
            Duration = Start.AddSeconds(30);
            Console.WriteLine("Đã trồng thành công Wheat.");
        }
    }
}
