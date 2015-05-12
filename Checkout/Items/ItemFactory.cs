using System.Collections.Generic;
using System;
using System.Linq;

namespace NAB
{
    public static class ItemFactory
    {
        public static Item Create(string skuCode)
        {
            Item item = null;
            switch (skuCode.ToUpper())
            {
                case ItemSku.Nexus9:
                    item = new Nexus9();
                    break;
                case ItemSku.AppleTv:
                    item = new AppleTv();
                    break;
                case ItemSku.MacBookPro:
                    item = new MacBookPro();
                    break;
                case ItemSku.Hdmi:
                    item = new Hdmi();
                    break;
            }
            return item;
        }

        public static List<Item> Create(List<string> skuCodes)
        {
            return skuCodes.Select(Create).ToList();
        }
    }

}
