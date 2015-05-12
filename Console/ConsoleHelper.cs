using System;
using System.Collections.Generic;
using System.Linq;

namespace NAB
{
    public static class Message
    {
        public const string Instructions = "Type one of the below command and hit Enter\n"
                                           + "Command | Description\n"
                                           + "----------------------\n"
                                           + " Q      | Exit Program\n"
                                           + " N      | Start A New Checkout\n"
                                           + " CO     | Checkout Cart Items\n"
                                           + "<sku>   | Add Item Sku Code\n";

        public const string NewCart = "New Cart Started\n"
                                      + "------------------";

        public const string CheckOutItems = "Checkout items\n"
                                            + Line;

        public const string TotalItems = "       TotalPrice: ";
        public const string CatalogItems = "        SKU Code | Item\n" + "        ---------------------\n";
        public const string Line = "------------------------------------------------";
        public const string CartItems = "Cart items: ";
        public const string EmptyCartItems = CartItems + " Empty";
    }

    public static class ItemCatalog
    {
        public static readonly Dictionary<string, string> Catalog = new Dictionary<string, string>();

        public static void BuildCatalog()
        {
            Catalog.Add(ItemSku.AppleTv, ItemName.AppleTv);
            Catalog.Add(ItemSku.MacBookPro, ItemName.MacBookPro);
            Catalog.Add(ItemSku.Nexus9, ItemName.Nexus9);
            Catalog.Add(ItemSku.Hdmi, ItemName.Hdmi);
        }

        public static string DisplayCatalog()
        {
            return Catalog.Aggregate(Message.CatalogItems,
                (current, item) => current + ("           " + item.Key + "   |  " + item.Value + "\n"));
        }

        public static Dictionary<string, string>.KeyCollection GetSkus()
        {
            return Catalog.Keys;
        }
    }

}