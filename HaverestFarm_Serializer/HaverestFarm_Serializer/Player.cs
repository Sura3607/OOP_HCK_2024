using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HarvestFarm_Serializer
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(Grid))]
    [KnownType(typeof(FarmState))]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Sunflower))]
    [KnownType(typeof(Wheat))]
    [KnownType(typeof(Tomato))]
    public class Player : ISerializable
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public float Reward { get; private set; }
        [DataMember]
        public FarmState State { get; private set; }
        [DataMember]
        public Dictionary<Product, int> Inventory { get; private set; } 
        public Player(string name)
        {
            Name = name;
            Reward = 50;
            Inventory = new Dictionary<Product, int>();
            State = new FarmState();
        }

        public void Save(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fileStream, this);

                Console.WriteLine("Đã lưu thành công!");
            }
            //DataContractSerializer serializer = new DataContractSerializer(typeof(Player));
            //using (MemoryStream memoryStream = new MemoryStream())
            //{    

            //    serializer.WriteObject(memoryStream, this);

            //    byte[] data = memoryStream.ToArray();
            //    using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            //    {
            //        writer.Write(data.Length);
            //        writer.Write(data);
            //    }

            //    //StringBuilder binaryString = new StringBuilder();
            //    //foreach (byte b in data)
            //    //{
            //    //    binaryString.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            //    //}
            //    //using (StreamWriter writer = new StreamWriter(filePath, false))
            //    //{
            //    //    writer.Write(binaryString.ToString());
            //    //}

            //    Console.WriteLine("Đã lưu thành công!");
            //}
        }
        public static Player Load(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    return (Player)formatter.Deserialize(fileStream);
                }
            }
            //DataContractSerializer serializer = new DataContractSerializer(typeof(Player));
            //if (System.IO.File.Exists(filePath))
            //{
            //    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            //    {
            //        int dataLength = reader.ReadInt32();
            //        byte[] data = reader.ReadBytes(dataLength);

            //        using (MemoryStream memoryStream = new MemoryStream(data))
            //        {

            //            return (Player)serializer.ReadObject(memoryStream);
            //        }
            //    }
            //    //string binaryString;
            //    //using (StreamReader reader = new StreamReader(filePath))
            //    //{
            //    //    binaryString = reader.ReadToEnd();
            //    //}
            //    //int byteCount = binaryString.Length / 8;
            //    //byte[] data = new byte[byteCount];
            //    //for (int i = 0; i < byteCount; i++)
            //    //{
            //    //    data[i] = Convert.ToByte(binaryString.Substring(i * 8, 8), 2);
            //    //}
            //    //using (MemoryStream memoryStream = new MemoryStream(data))
            //    //{
            //    //    return (Player)serializer.ReadObject(memoryStream);
            //    //}
            //}
            else
            {
                throw new Exception("Chưa tồn lại.");
            }
        }
        public void Buy(Product product, int sl)
        {
            float cost = product.Cost*sl;
            if (Reward < cost)
            {
                string message = "Không đủ tiền.";
                throw new Exception(message);
            }
            Reward -= cost;
            if (Inventory.ContainsKey(product))       
                Inventory[product] += sl;            
            else            
                Inventory[product] = sl;            
        }
        public void Feed(Product product, int x, int y)
        {
            if (Reward < product.Fetilizer)
            {
                string message = "Không đủ tiền.";
                throw new Exception(message);
            }
            Reward -= product.Fetilizer;
            if (product.GetType() == typeof(Sunflower))
                ((Sunflower)product).feed();
            else if (product.GetType() == typeof(Tomato))
                ((Tomato)product).feed();
            else
                ((Wheat)product).feed();
            State.UpdateCell(x, product);
        }
        public void Prov_water(Product product, int x, int y)
        {
            if (Reward < product.Water)
            {
                string message = "Không đủ tiền.";
                throw new Exception(message);
            }
            Reward -= product.Water;
            if (product.GetType() == typeof(Sunflower))
                ((Sunflower)product).prov_water();
            else if (product.GetType() == typeof(Tomato))
                ((Tomato)product).prov_water();
            else
                ((Wheat)product).prov_water();
            State.UpdateCell(x, product);
        }
        public void Seed(Product product, int x, int y)
        {
            if(!State.CanSeed(x))
            {
                string message = "Ô này hiện đang có cây.";
                throw new Exception(message);
            }
            if (product.GetType() == typeof(Sunflower))
                ((Sunflower)product).seed();
            else if (product.GetType() == typeof(Tomato))
                ((Tomato)product).seed();
            else
                ((Wheat)product).seed();
            Inventory[product]--;
            if(Inventory[product] == 0)
                Inventory.Remove(product);
            State.UpdateCell(x, product);
        }
        public bool CanHavest(Product product)
        {
            if (product.GetType() == typeof(Sunflower))
                return ((Sunflower)product).CanHarvest();
            else if (product.GetType() == typeof(Tomato))
                return ((Tomato)product).CanHarvest();
            else
                return ((Wheat)product).CanHarvest();
        }
        public void Harvest(Product product, int x)
        {
            if (!CanHavest(product))
            {
                throw new Exception("Không đủ điều kiện thu hoạch.");
            }
            float profit = 0;
            if(product.GetType() == typeof(Sunflower))
                profit += ((Sunflower)product).harvest();
            else if (product.GetType() == typeof(Tomato))
                profit += ((Tomato)product).harvest();
            else
                profit += ((Wheat)product).harvest();
            Reward += profit;
            State.UpdateCell(x, null);
            Console.WriteLine($"Lợi nhuận thu hoạch: {profit}, Điểm thưởng hiện tại: {Reward}");
        }
        public void PrintInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Kho hiện không có sản phẩm nào.");
                return;
            }
            Console.WriteLine("{0,-20} {1,-10}", "Tên sản phẩm", "Số lượng");
            Console.WriteLine(new string('-', 30));
            foreach (var item in Inventory)
            {
                string productName = item.Key.GetType().Name;
                int quantity = item.Value;
                Console.WriteLine("{0,-20} {1,-10}", productName, quantity);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Reward", Reward);
            info.AddValue("State", State);
            info.AddValue("Inventory", Inventory);
        }
        public Player(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Reward = (float)info.GetInt32("Reward");
            State = (FarmState)info.GetValue("State",typeof(FarmState));
            Inventory = (Dictionary<Product,int>)info.GetValue("Inventory", typeof(Dictionary<Product, int>));
        }
    }
}
