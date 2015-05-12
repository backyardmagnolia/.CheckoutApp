using System.Collections.Generic;

namespace NAB
{
    public class CheckOut
    {
        private readonly List<IRule> _rules;
        private List<Item> _items = new List<Item>();
        private List<Item> _outputItems = new List<Item>();
        private double _totalCoPrice;

        public CheckOut(List<IRule> rules)
        {
            _rules = rules;
        }

        public void Scan(Item item)
        {
            _items.Add(item);
        }

        public double Total()
        {
            _outputItems = _items;

            // Loop through the Rules list on inputItem
            foreach (var rule in _rules)
            {
                while (rule.CanApply(_items))
                {
                    _outputItems = rule.ApplyRule(_items);
                    _items = _outputItems;
                }
            }

            Display.PrintOut(Message.CheckOutItems);

            // Sum up checkedout items:price
            foreach (var item in _outputItems)
            {
                _totalCoPrice += item.GetTotalPrice();
            }

            return _totalCoPrice;
        }
    }
}