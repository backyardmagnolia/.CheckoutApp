using System.Collections.Generic;

namespace NAB
{
    public class PromoItem : Item
    {
        private List<Item> _promoItems = new List<Item>();

        public PromoItem()
            : base(ItemSku.Promo, 0, ItemName.Promo)
        {
        }

        public PromoItem(string name)
        {
            Sku = ItemSku.Promo;
            Name = name;
        }

        public List<Item> PromoItems
        {
            get { return _promoItems; }
            set { _promoItems = value; }
        }

        public double TotalPrice { get; set; }

        public override Result GetTotalPrice()
        {
            Result result = new Result();
            foreach (var item in _promoItems)
            {
                result.OutputMessage += item.Name + "(" + Name + ") " + ": " + item.Price.ToString("F") + "\n";
                result.Total += item.Price;
            }

            return result;
        }
    }
}