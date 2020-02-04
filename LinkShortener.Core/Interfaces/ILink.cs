using System.Threading.Tasks;

namespace LinkShortener.Core.Interfaces
{
    public interface ILink
    {
         Task<string> GenerateAsync();
         
    }
}