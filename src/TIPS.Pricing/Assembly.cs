using System.Collections.Generic;

namespace TIPS.Pricing
{
    public class Assembly : Item
    {

        public Assembly()
        {
            Components = new List<AssemblyComponent>();
        }

        public List<AssemblyComponent> Components { get; private set; }

    }
}
