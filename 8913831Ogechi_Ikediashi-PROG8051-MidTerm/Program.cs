using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// InventoryItem class defined to represent an inventory item
public class InventoryItem
{
    // This inventory item properties definiton shows that a single item will have the following details: Name, Id, Price and Quantity in Stock
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor to initialize the properties of the inventory item with the values passed to the constructor.
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Method 1 to update the price of the inventory item with the new price.
    public void UpdatePrice(double newPrice)
    {
        // The :C here will help to formart my Price as a currency using my logal region/timezone
        Price = newPrice;
        Console.WriteLine($"Price updated to {Price:C} for {ItemName}");
    }

    // Method 2 to restock the inventory item. This method will increase the item's stock quantity by the additional quantity.
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
        Console.WriteLine($"\nRestocked {additionalQuantity} {ItemName}(s). New stock: {QuantityInStock} \n");
    }

    // Method 3 to sell a specified quantity of the inventory item
    public void SellItem(int quantitySold)
    {
        if (quantitySold < 0)
        {
            Console.WriteLine("\nInvalid number of items requested for.");
        }
        // Checking if there is enough stock to sell
        else if (quantitySold <= QuantityInStock)
        {
            // Decreasing the item's stock quantity by the quantity sold.
            QuantityInStock -= quantitySold;
            Console.WriteLine($"\nSold {quantitySold} {ItemName}(s). New stock: {QuantityInStock}");
        }
        else
        // Ensuring the stock doesn't go negative.
        {
            Console.WriteLine($"Not enough stock to sell {quantitySold} {ItemName}(s).");
            Console.WriteLine("\n");
        }
    }

    // Method 4 to check if the inventory item is in stock
    public bool IsInStock()
    {
        // This would return true if the item is in stock (quantity > 0), otherwise false.
        return QuantityInStock > 0;
    }

    // Method 5 to print the details of the inventory item
    public void PrintDetails()
    {
        // This will print the details of the item using the format: Item: <name> (ID: <id>) - Price: <price>, Stock: <stock quantity>).
        // The :C here will help to formart my Price as a currency using my logal region/timezone
        Console.WriteLine($"{ItemName} (ID: {ItemId}) - Price: {Price:C}, Stock: {QuantityInStock}");
    }
}


// Main program: This is the code block that runs first and it will help to call/trigger the InventoryItem Class and its methods
class Program
{
    static void Main(string[] args)
    {
        // Creating 5 instances of InventoryItem class
        InventoryItem item1 = new InventoryItem("Dell Laptop", 9000001, 2999.99, 35);
        InventoryItem item2 = new InventoryItem("iPhone Smartphone", 9000002, 999.99, 70);
        InventoryItem item3 = new InventoryItem("Beats By Dre Speaker", 9000003, 399.99, 20);
        InventoryItem item4 = new InventoryItem("iPhone Charger", 9000004, 99.99, 100);
        InventoryItem item5 = new InventoryItem("LQWell Mini Projector", 9000005, 199.99, 15);

        Console.WriteLine("Items In Store includes: \n");

        // 1. Print details of all the inventory items
        item1.PrintDetails();
        item2.PrintDetails();
        item3.PrintDetails();
        item4.PrintDetails();
        item5.PrintDetails();

        // 2. Sell some items and print updated details
        item1.SellItem(-10);
        item2.SellItem(3);
        item3.SellItem(3);

        // 3. Restock an item and print updated details
        item3.RestockItem(7);

        // 4. Check if items are in stock and print a message accordingly
        Console.WriteLine($"Is {item1.ItemName} in stock? {item1.IsInStock()}");
        Console.WriteLine($"Is {item2.ItemName} in stock? {item2.IsInStock()}");
        Console.WriteLine($"Is {item3.ItemName} in stock? {item3.IsInStock()}");
        Console.WriteLine($"Is {item4.ItemName} in stock? {item4.IsInStock()}");
        Console.WriteLine($"Is {item5.ItemName} in stock? {item5.IsInStock()} \n");

    }
}
