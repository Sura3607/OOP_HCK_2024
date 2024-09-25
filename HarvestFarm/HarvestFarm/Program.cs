using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HarvestFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chào mừng đến với trò chơi Farm!");

            // Khởi tạo người chơi
            Console.Write("Nhập tên người chơi: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            Console.WriteLine($"Chào mừng {player.Name}! Bạn có {player.Reward} điểm thưởng.");

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n+-------------------------------------+");
                Console.ResetColor();
                Console.WriteLine($"|   Bạn đang có {player.Reward} điểm.              |");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+-------------------------------------+\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Chọn hành động:");

                Console.ResetColor();
                Console.WriteLine("+-------------------------------------+");
                Console.WriteLine("| 1. Mua hạt giống                    |");
                Console.WriteLine("| 2. Gieo hạt                         |");
                Console.WriteLine("| 3. Bón phân                         |");
                Console.WriteLine("| 4. Tưới nước                        |");
                Console.WriteLine("| 5. Thu hoạch                        |");
                Console.WriteLine("| 6. Kiểm tra trạng thái nông trại    |");
                Console.WriteLine("| 7. Kiểm tra kho đồ                  |");
                Console.WriteLine("| ESC. Thoát trò chơi                 |");
                Console.WriteLine("+-------------------------------------+\n");
                Console.Write("Lựa chọn của bạn: ");
                Console.ResetColor();

                ConsoleKeyInfo choice = Console.ReadKey(true);

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        BuySeeds(player);
                        break;
                    case ConsoleKey.D2:
                        PlantSeeds(player);
                        break;
                    case ConsoleKey.D3:
                        FeedPlants(player);
                        break;
                    case ConsoleKey.D4:
                        WaterPlants(player);
                        break;
                    case ConsoleKey.D5:
                        Harvest(player);
                        break;
                    case ConsoleKey.D6:
                        CheckFarmState(player);
                        break;
                    case ConsoleKey.D7:
                        ShowBag(player);
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCảm ơn bạn đã chơi!");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }
            }
        }

        static void BuySeeds(Player player)
        {
            Console.Clear();
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-20}", "STT", "Tên sản phẩm", "Giá", "Giá trị sau khi thu hoạch");
            Console.WriteLine(new string('-', 65)); 
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-20}", "1", "Sunflower", "20đ", "25đ");
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-20}", "2", "Tomato", "10đ", "20đ");
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-20}", "3", "Wheat", "15đ", "18đ");
            Console.WriteLine(new string('-', 65));
            Console.Write("Lựa chọn của bạn: ");

            ConsoleKeyInfo choice = Console.ReadKey(true);
            Product product = null;

            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Sunflower");
                    product = new Sunflower();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Tomato");
                    product = new Tomato();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Wheat");
                    product = new Wheat();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            Console.Write("Nhập số lượng hạt giống: ");
            int quantity = int.Parse(Console.ReadLine());

            try
            {
                player.Buy(product, quantity);
                Console.WriteLine($"Bạn đã mua {quantity} hạt giống {product.GetType().Name}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void PlantSeeds(Player player)
        {
            Console.Clear();
            Console.Write("Nhập vị trí để trồng cây (1-5): ");
            int position = int.Parse(Console.ReadLine());

            Console.WriteLine("Chọn loại hạt giống để trồng:");
            foreach (var entry in player.Inventory)
            {
                Console.WriteLine($"{entry.Key.GetType().Name}: {entry.Value} hạt giống");
            }

            string choice = Console.ReadLine();
            Product product = player.Inventory.Keys.FirstOrDefault(p => p.GetType().Name.ToLower() == choice.ToLower());

            if (product == null)
            {
                Console.WriteLine("Hạt giống không hợp lệ.");
                return;
            }

            try
            {
                player.Seed(product, position, 0);
                Console.WriteLine($"Bạn đã trồng thành công {product.GetType().Name} ở vị trí {position}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void FeedPlants(Player player)
        {
            Console.Clear();
            Console.Write("Nhập vị trí để bón phân (1-5): ");
            int position = int.Parse(Console.ReadLine());
            Product product = player.State.GetPlan(position);

            if (product == null)
            {
                Console.WriteLine("Không có cây nào ở vị trí này.");
                return;
            }

            try
            {
                player.Feed(product, position, 0);
                Console.WriteLine($"Bạn đã bón phân cho cây {product.GetType().Name} ở vị trí {position}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void WaterPlants(Player player)
        {
            Console.Clear();
            Console.Write("Nhập vị trí để tưới nước (1-5): ");
            int position = int.Parse(Console.ReadLine());
            Product product = player.State.GetPlan(position);

            if (product == null)
            {
                Console.WriteLine("Không có cây nào ở vị trí này.");
                return;
            }

            try
            {
                player.Prov_water(product, position, 0);
                Console.WriteLine($"Bạn đã tưới nước cho cây {product.GetType().Name} ở vị trí {position}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Harvest(Player player)
        {
            Console.Clear();
            Console.Write("Nhập vị trí để thu hoạch (1-5): ");
            int position = int.Parse(Console.ReadLine());
            Product product = player.State.GetPlan(position);

            if (product == null)
            {
                Console.WriteLine("Không có cây nào để thu hoạch ở vị trí này.");
                return;
            }

            try
            {
                player.Harvest(product, position);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CheckFarmState(Player player)
        {
            Console.Clear();
            Console.WriteLine("Trạng thái nông trại:");
            player.State.Update();
        }
        static void ShowBag(Player player)
        {
            Console.Clear();
            player.PrintInventory();
        }
    }

}
