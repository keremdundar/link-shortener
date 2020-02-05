using System.Collections.Generic;

namespace LinkShortener.Core.Interfaces
{
    public interface IRandomCharGenerator
    {
         char GetRandomCharFromArray(Dictionary<char,int[]> lookupTable,int index);
    }
}