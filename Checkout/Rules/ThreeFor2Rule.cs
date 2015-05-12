using System.Collections.Generic;
using System.Linq;

namespace NAB
{
    public class ThreeFor2Rule : IRule
    {
        private readonly string _sku;
        private List<Item> _inputItems;

        public ThreeFor2Rule(string sku)
        {
            _sku = sku;
            _inputItems = new List<Item>();
        }

        public bool CanApply(List<Item> inputItems)
        {
            _inputItems = inputItems;

            var items = (from d in inputItems
                where d.Sku.ToUpper() == _sku
                select d);
            return items.Count() >= 3;
        }

        public List<Item> ApplyRule(List<Item> inputItems)
        {
            var items = (from d in inputItems
                where d.Sku.ToUpper() == _sku
                select d).Take(3);


            var promoItemParent = new PromoItem(ItemName.ThreeFor2Promo);
            var promoItems = items as Item[] ?? items.ToArray();
            promoItems.Last().Price = 0;

            foreach (var item in promoItems)
            {
                promoItemParent.PromoItems.Add(item);
            }

            foreach (var item in promoItems)
            {
                _inputItems.Remove(item);
            }

            _inputItems.Add(promoItemParent);
            return _inputItems;
        }
    }
}