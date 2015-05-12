
using System.Collections.Generic;

namespace NAB
{
    public static class RulesBuilder
    {
        public static List<IRule> Build()
        {
            var rules = new List<IRule>
            {
                new ThreeFor2Rule(ItemSku.AppleTv),
                new FreeItemRule(ItemSku.MacBookPro, ItemSku.Hdmi),
                new DiscountedPriceRule(ItemSku.Nexus9, 4, ItemPrice.NewPriceNexus9)
            };

            return rules;
        }
    }
}
