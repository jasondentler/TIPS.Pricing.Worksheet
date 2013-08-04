using System.Collections.Generic;

namespace TIPS.Pricing
{
    public class Package : Option 
    {
        public Package()
        {
            Items = new List<Item>();
        }

        public List<Item> Items { get; private set; }

    }
}
