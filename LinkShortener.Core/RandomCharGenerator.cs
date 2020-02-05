using System;
using System.Collections.Generic;
using System.Linq;
using LinkShortener.Core.Interfaces;

namespace LinkShortener.Core
{
    public class RandomCharGenerator : IRandomCharGenerator
    {
        public char GetRandomCharFromArray(Dictionary<char, int[]> lookupTable, int index)
        {
            Random random = new Random();
            var minimumCount = lookupTable.Min(p=>p.Value[index]);
            var arrangedLookupTable = lookupTable.Where(p=>p.Value[index]==minimumCount).ToList();
            var randomIndex = random.Next(arrangedLookupTable.Count-1);

            return arrangedLookupTable[randomIndex].Key;
        }
    }
}