using System;

namespace CafeOrderingSystem
{
    public enum DrinkType { Coffee, Tea, Juice, Water }
    public enum DrinkSize { Small, Medium, Large }
    public enum OrderStatus { New, Preparing, Ready, Delivered }

    public class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }

        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            this.OrderNumber = orderNumber;
            this.CustomerName = customerName;
            this.Drink = drink;
            this.Size = size;
            this.Status = OrderStatus.New; 
            this.Price = CalculatePrice();
        }

        public decimal CalculatePrice()
        {
            switch (Drink)
            {
                case DrinkType.Coffee:
                    if (Size == DrinkSize.Small) return 3;
                    if (Size == DrinkSize.Medium) return 4;
                    return 5;
                case DrinkType.Tea:
                    if (Size == DrinkSize.Small) return 2;
                    if (Size == DrinkSize.Medium) return 3;
                    return 4;
                case DrinkType.Juice:
                    if (Size == DrinkSize.Small) return 4;
                    if (Size == DrinkSize.Medium) return 5;
                    return 6;
                case DrinkType.Water:
                    if (Size == DrinkSize.Small) return 1;
                    if (Size == DrinkSize.Medium) return 1.5m;
                    return 2;
                default:
                    return 0;
            }
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            this.Status = newStatus;
            Console.WriteLine($"Sifaris #{OrderNumber} statusu: {newStatus}");
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"[Sifaris #{OrderNumber}] Musteri: {CustomerName} | " +
                              $"İcki: {Size} {Drink} | Qiymet: {Price} AZN | Status: {Status}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Sifarislerin İdare Edilmesi ---\n");

            DrinkOrder order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Preparing);
            order1.UpdateStatus(OrderStatus.Ready);
            order1.UpdateStatus(OrderStatus.Delivered);
            Console.WriteLine();

            DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            order2.DisplayOrder();
            order2.UpdateStatus(OrderStatus.Ready);
            order2.DisplayOrder();
            Console.WriteLine();

            DrinkOrder order3 = new DrinkOrder(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
            order3.DisplayOrder();
            Console.WriteLine();

            Console.WriteLine("--- Enum Metodlari Testi ---");

            Console.WriteLine("\nDrinkType Deyerleri:");
            foreach (var d in Enum.GetValues(typeof(DrinkType))) Console.Write(d + " ");

            Console.WriteLine("\n\nDrinkSize Deyerleri:");
            foreach (var s in Enum.GetValues(typeof(DrinkSize))) Console.Write(s + " ");

            Console.WriteLine("\n\nOrderStatus Deyerleri:");
            foreach (var st in Enum.GetValues(typeof(OrderStatus))) Console.Write(st + " ");

            Console.WriteLine($"\n\nToString Test: {DrinkType.Coffee.ToString()} (Tip: {DrinkType.Coffee.ToString().GetType().Name})");

            string drinkStr = "Tea";
            DrinkType parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), drinkStr);
            Console.WriteLine($"Parse Test: '{drinkStr}' string-i {parsedDrink} enum-una cevrildi.");

            Console.WriteLine("\n--- Statistika ---");
            Console.WriteLine($"umumi sifaris sayı: 3");
            Console.WriteLine($"Sifaris 1: {order1.Price} AZN");
            Console.WriteLine($"Sifaris 2: {order2.Price} AZN");
            Console.WriteLine($"Sifaris 3: {order3.Price} AZN");

            decimal total = order1.Price + order2.Price + order3.Price;
            Console.WriteLine($"umumi mebleğ: {total} AZN");
        }
    }
}