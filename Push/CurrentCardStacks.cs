using System;
using System.Collections.Generic;
using System.Text;

namespace Push
{
    public class CurrentCardStacks
    {
        public List<List<ICard>> Columns { get; set; }

        public CurrentCardStacks()
        {
            Columns = new List<List<ICard>>
            {
                new List<ICard>(), 
                new List<ICard>(), 
                new List<ICard>()
            };
        }

        public void Reset()
        {
            foreach (var column in Columns)
            {
                column.Clear();
            }
        }
    }
}
