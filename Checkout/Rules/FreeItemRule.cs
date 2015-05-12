using System.Collections.Generic;
using System.Linq;

namespace NAB
{
    public class FreeItemRule : IRule
    {
        private readonly string _purchasedSku;
        private readonly string _giftSku;

        public FreeItemRule(string purchasedSku, string giftSku)
        {
            _purchasedSku = purchasedSku;
            _giftSku = giftSku;
            InputItems = new List<Item>();
        }

        public List<Item> InputItems { get; private set; }

        public bool CanApply(List<Item> cartItems)
        {
            InputItems = cartItems;
            var itemsMacBook = (from d in cartItems
                where d.Sku.ToUpper() == _purchasedSku
                select d);

            var itemsHdmi = (from d in cartItems
                where d.Sku.ToUpper() == _giftSku
                select d);


            return itemsMacBook.Any() && itemsHdmi.Any();
        }

        public List<Item> ApplyRule(List<Item> cartItems)
        {
            var itemMacBook = cartItems.First(d => d.Sku.ToUpper() == _purchasedSku);

            var itemsHdmi = cartItems.First(d => d.Sku.ToUpper() == _giftSku);

            var promoItemParent = new PromoItem(ItemName.FreeItemPromo);

            itemsHdmi.Price = 0;
            promoItemParent.PromoItems.Add(itemMacBook);
            promoItemParent.PromoItems.Add(itemsHdmi);

            InputItems.Remove(cartItems.First(d => d.Sku.ToUpper() == _purchasedSku));
            InputItems.Remove(cartItems.First(d => d.Sku.ToUpper() == _giftSku));
            InputItems.Add(promoItemParent);
            return InputItems;
        }
    }
}