using System;
using System.Collections.Generic;
using System.Linq;

namespace NAB
{
    public static class Display
    {
        public static void PrintOutAppendNewLine(string msg)
        {
            Console.WriteLine(msg + "\n\n");
        }

        public static void PrintOut(string msg)
        {
            Console.WriteLine(msg);
        }


        public static void PrintReceipt(Result result)
        {
            PrintOut(Message.CheckOutItems);
            PrintOut(result.OutputMessage);
            PrintOutAppendNewLine(Message.TotalItems + result.Total.ToString("F"));
            PrintOut(Message.Line);
        }

        public static void PrintInstructions()
        {
            PrintOutAppendNewLine(Message.Instructions);
            PrintOutAppendNewLine(ItemCatalog.Catalog.Aggregate(Message.CatalogItems,
               (current, item) => current + ("           " + item.Key + "   |  " + item.Value + "\n")));
            
        }

        public static void  PrintShoppingList(List<string> shoppingList)
        {
            string shoppingListDisplay = "";
            if (shoppingList == null || !shoppingList.Any())
            {
                shoppingListDisplay = Message.EmptyCartItems;
            }
            else 
            {
                shoppingListDisplay = shoppingList.Aggregate(Message.CartItems,
                    (current, item) => current + (item.ToUpper() + ", "));
            }
            PrintOutAppendNewLine(shoppingListDisplay);
        }
    }
}
