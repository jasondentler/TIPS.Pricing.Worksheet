using System.Collections.Generic;

namespace TIPS.Pricing
{
    public class Package : Option 
    {
        public Package()
        {
            Components = new List<PackageComponent>();
        }

        public List<PackageComponent> Components { get; private set; }

    }
}
