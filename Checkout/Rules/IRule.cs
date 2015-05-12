using System.Collections.Generic;

namespace NAB
{
    public interface IRule
    {
        bool CanApply(List<Item> cartItems);
        List<Item> ApplyRule(List<Item> cartItems);
    }
}