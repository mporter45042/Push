using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Push
{
    public class RollCard : ICard
    {
        public string DisplayName => "Roll Card";

        public override bool Equals(object other)
        {
            if (other is RollCard)
            {
                return true;
            }

            return false;
        }
    }
}
