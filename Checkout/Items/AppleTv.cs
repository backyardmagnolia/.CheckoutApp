using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAB
{
    public class AppleTv : Item
    {
        public AppleTv()
            : base(ItemSku.AppleTv, ItemPrice.AppleTv, ItemName.AppleTv)
        {
        }
    }
}
