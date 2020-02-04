using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkShortener.Core.Interfaces
{
    public interface ILookupTable
    {
         Task<int> GetGeneratedNumberOfChar(char lookup, int index);
         Task<char> GetMinimumGeneratedChar(int index);
         Task<Dictionary<char,int[]>> GeneratedNumberOfCharTable();
         Task<bool> Persist(char lookup, int index);
         Task<bool> Remove(char lookup, int index);
    }
}