using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Push
{
    public enum Color
    {
        Blue,
        Green,
        Purple,
        Red,
        Yellow
    }

    public class NumberedCard : ICard
    {
        public NumberedCard(int number, Color color)
        {
            Number = number;
            Color = color;
        }

        public Color Color { get; }
        public int Number { get; }

        public string DisplayName => $"{Number} of {Color}";

        public override bool Equals(object obj)
        {
            if (obj is NumberedCard otherCard)
            {
                return (Color == otherCard.Color && Number == otherCard.Number);
            }

            return false;
        }
    }
}
