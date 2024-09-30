using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HarvestFarm_Serializer
{
    [Serializable]
    [DataContract]
    public class FarmState : ISerializable
    {
        [DataMember]
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Grid", Grid);
        }
        public FarmState() { }
        public FarmState(SerializationInfo info, StreamingContext context)
        {
            Grid = (Grid)info.GetValue("Grid", typeof(Grid));
        }
    }
}
    
