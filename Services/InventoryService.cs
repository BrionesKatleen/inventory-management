/**
    Name: KATLEEN BRIONES
    DATE: FEB 21, 2026
    PRELIM PHASE II: inventory-management system
*/
using System;

namespace InventoryManagament.Services
{
    public class InventoryService
    {
        private string[,] products;
        private int[] initialStock;

        public InventoryService()
        {
            products = new String[2,3]; // 2 Rows 3 Columns

            // Row 1
            products[0,0] = "Apples";
            products[0,1] = "Milk";
            products[0,2] = "Bread";

            // Row 2
            products[1,0] = "10";
            products[1,1] = "15";
            products[1,2] = "20";

            // Initial Stocks
            initialStock = new int[3];
            initialStock[0] = 10;
            initialStock[1] = 15;
            initialStock[2] = 20;
        }
        // ALL INVENTORY PRODUCTS
        public string[,] GetAllProducts()
        {
            return products;
        }

        // SPECIFIC PRODUCT NAME
        public string getProductName(int index)
        {
            if(index >= 0 && index < products.GetLength(1))
            {
                return products[0, index];
            }
            return null;
        }

        // SPECIFIC PRODUCT STOCK
        public int getProductStock(int index)
        {
            if(index >= 0 && index < products.GetLength(1))
            {
                if(int.TryParse(products[1, index], out int stock))
                {
                    return stock;
                }
            }
            return -1;
        }

        // UPDATE SPECIFIC PRODUCT
        public bool UpdateStock(int productIndex, int newStock)
        {
            if(productIndex >= 0 && productIndex < products.GetLength(1) && newStock >= 0)
            {
                products[1, productIndex] = newStock.ToString();
                return true;
            }
            return false;
        }

        // RESET INVENTORY
        public void ResetInventory()
        {
            for (int i = 0; i < initialStock.Length; i++)
            {
                products[1, i] = initialStock[i].ToString();
            }
        }

        public int GetProductCount()
        {
            return products.GetLength(1);
        }

    }
}
