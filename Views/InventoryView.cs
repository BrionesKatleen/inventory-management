/**
    Name: KATLEEN BRIONES
    DATE: FEB 21, 2026
    PRELIM PHASE II: inventory-management system
*/
using System;
using InventoryManagament.Services;

namespace InventoryManagament
{
    public class InventoryView
    {
        private InventoryService inventoryService;

        public InventoryView()
        {
            inventoryService = new InventoryService();
        }
        
        // MAIN PROGRAM LOOP
        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== INVENTORY MANAGEMENT SYSTEM ===\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit\n");
                Console.Write("Select an option (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                            ViewInventory();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ResetInventory();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the Inventory Management System. Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option.Please try again.");
                        break;
                }

            }
        }

        // DISPLAY INVENTORY
        private void ViewInventory()
        {
            Console.WriteLine("\n=== CURRENT INVENTORY ===\n");
            
            var products = inventoryService.GetAllProducts();
            int productCount = inventoryService.GetProductCount();
            
            Console.WriteLine("ID\tProduct\t\tStock");
            Console.WriteLine("---\t-------\t\t-----");
            
            for (int i = 0; i < productCount; i++)
            {
                string productName = products[0, i];
                string stock = products[1, i];
                
                // Format for better alignment
                if (productName.Length < 8)
                {
                    Console.WriteLine($"{i + 1}\t{productName}\t\t{stock}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}\t{productName}\t{stock}");
                }
            }
        }

        // UPDATE STOCK
        private void UpdateStock()
        {
            Console.WriteLine("\n=== UPDATE STOCK ===\n");

            // DISPLAY PRODUCT
            var products = inventoryService.GetAllProducts();
            int productCount = inventoryService.GetProductCount();

            Console.WriteLine("Select a product to update:");
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"{i+1}, {products[0,i]} (Current stock: {products[1,i]})");
            }

            // GET PRODUCT SELECTION
            Console.Write("\nEnter product number (1-3): ");
            if(int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 1 && productIndex <= productCount)
            {
                productIndex--; // ADJUST INDEX

                Console.Write($"Enter new stock quantity for {products[0, productIndex]}: ");
                if(int.TryParse(Console.ReadLine(), out int newStock) && newStock >= 0)
                {
                    if(inventoryService.UpdateStock(productIndex, newStock))
                    {
                        Console.WriteLine($"\nStock updates successfully!");
                        Console.WriteLine($"{products[0,productIndex]} new stock: {newStock}");
                    }
                    else
                    {
                        Console.WriteLine("\nFialed to update stock. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid stock quantity. Please enter a non-negative number..");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid product selection.");
            }
        }

        private void ResetInventory()
        {
            Console.WriteLine("\n=== RESET INVENTORY ===\n");

            Console.Write("Are you sure you want to reset all stock to original values? (y/n): ");
            string confirmation = Console.ReadLine().ToLower();

            if(confirmation == "y" || confirmation == "yes")
            {
                inventoryService.ResetInventory();
                Console.WriteLine("\nInventory has been reset to original values!");

                ViewInventory();
            }
            else
            {
                Console.WriteLine("\nReset Cancelled.");
            }
        }
    }
}
