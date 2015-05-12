using System.Collections.Generic;
using System.Linq;

namespace NAB
{
    public class DiscountedPriceRule : IRule
    {
        private readonly double _newPrice;
        private readonly string _sku;
        private readonly int _minVolumn;

        public DiscountedPriceRule(string discountItemSku, int minVolumn, double newPrice)
        {
            _newPrice = newPrice;
            _sku = discountItemSku;
            _minVolumn = minVolumn;
            InputItems = new List<Item>();
        }

        public List<Item> InputItems { get; private set; }

        public bool CanApply(List<Item> inputItems)
        {
            InputItems = inputItems;

            var items = (from d in inputItems
                         where d.Sku.ToUpper() == _sku
                select d);
            return items.Count() > _minVolumn;
        }

        public List<Item> ApplyRule(List<Item> inputItems)
        {
            var items = (from d in inputItems
                         where d.Sku.ToUpper() == _sku
                select d);

            var promoItemParent = new PromoItem(ItemName.DiscountedPricePromo);
            foreach (var inputItem in items)
            {
                inputItem.Price = _newPrice;
                promoItemParent.PromoItems.Add(inputItem);
            }

            inputItems.RemoveAll(d => d.Sku.ToUpper() == _sku);
            inputItems.Add(promoItemParent);
            return inputItems;
        }
    }
}