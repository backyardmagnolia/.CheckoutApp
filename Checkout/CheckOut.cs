using System.Collections.Generic;
using System.Linq.Expressions;

namespace NAB
{
    public class CheckOut
    {
        private readonly List<IRule> _rules;
        private List<Item> _items = new List<Item>();
        private List<Item> _outputItems = new List<Item>();

        public CheckOut(List<IRule> rules)
        {
            _rules = rules;
        }

        public void Scan(Item item)
        {
            if (item != null)
                _items.Add(item);
        }

        public Result Total()
        {
            _outputItems = _items;
            
            if (_rules != null)
            {
                foreach (var rule in _rules)
                {
                    while (rule.CanApply(_items))
                    {
                        _outputItems = rule.ApplyRule(_items);
                        _items = _outputItems;
                    }
                }
            }

            var totalResult = new Result();
            foreach (var item in _outputItems)
            {
                var itemResult = item.GetTotalPrice();
                totalResult.Total += itemResult.Total;
                totalResult.OutputMessage += itemResult.OutputMessage;
            }

            return totalResult;
        }
    }
}