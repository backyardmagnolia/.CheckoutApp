namespace NAB
{
    public abstract class Item
    {
        protected Item()
        {
        }

        protected Item(string sku, double price, string name)
        {
            Sku = sku;
            Price = price;
            Name = name;
        }

        public double Price { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }

        public virtual Result GetTotalPrice()
        {
            var result = new Result
            {
                OutputMessage = Name + ": " + Price.ToString("F") + "\n",
                Total = Price
            };
            return result;
        }
    }

    public class Result
    {
        public double Total { get; set; }
        public string OutputMessage { get; set; }
    }
}