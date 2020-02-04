using System.Threading.Tasks;

namespace LinkShortener.Core.Interfaces
{
    public interface ILinkCache
    {
         Task<bool> IsLinkExist(string link);
         Task<string> GetShortLink(string url);
         Task<string> GetUrl(string shortenLink);
         Task SaveLink(string shortenLink,string url);
    }
}