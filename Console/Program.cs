using System;
using System.Collections.Generic;
using System.Linq;

namespace NAB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ItemCatalog.BuildCatalog();

            var rules = RulesBuilder.Build();
            var app = new App(rules);
            var exit = false;
            while (!exit)
            {
                exit = app.Start("N");
            }
        }
    }

    public class App
    {
        private readonly List<IRule> _rules;

        public App(List<IRule> rules)
        {
            _rules = rules;
        }

        public bool Start(string inputCmd)
        {
            if (!string.IsNullOrEmpty(inputCmd) && inputCmd.ToUpper() == "N")
                return NewCheckout(inputCmd);

            return false;
        }

        private bool NewCheckout(string inputCmd)
        {
            var co = new CheckOut(_rules);
            var shoppingList = new List<string>();

            while (!string.IsNullOrEmpty(inputCmd) && inputCmd.ToUpper() != "CO" && inputCmd.ToUpper() != "Q")
            {
                Display.PrintOutAppendNewLine(Message.NewCart);

                if (ItemCatalog.GetSkus().Contains(inputCmd.ToUpper()))
                {
                    co.Scan(ItemFactory.Create(inputCmd.ToUpper()));
                    shoppingList.Add(inputCmd);
                }

                Display.PrintShoppingList(shoppingList);
                Display.PrintInstructions();

                var input = Console.ReadLine();
                inputCmd = !string.IsNullOrEmpty(input) ? input : "E";

                if (inputCmd.ToUpper() == "N" || inputCmd.ToUpper() == "Q") break;
            }

            if (!string.IsNullOrEmpty(inputCmd) && inputCmd.ToUpper() == "Q") return true;
            if (string.IsNullOrEmpty(inputCmd) || inputCmd.ToUpper() != "CO") return false;
           
            var result = co.Total();

            Display.PrintReceipt(result);

            inputCmd = Console.ReadLine();

            return !string.IsNullOrEmpty(inputCmd) && inputCmd.ToUpper() == "Q";
        }
    }
}