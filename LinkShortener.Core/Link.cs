using System.Threading.Tasks;
using LinkShortener.Core.Interfaces;

namespace LinkShortener.Core
{
    public class Link : ILink
    {
        private readonly ILookupTable _lookupTable;
        private readonly ILinkCache _linkCache;
        public Link(ILookupTable lookupTable,ILinkCache linkCache)
        {
            _lookupTable = lookupTable;
            _linkCache = linkCache;
        }
        public async Task<string> GenerateAsync()
        {
            string generatedString = string.Empty;
            bool isFound = true;
            while(isFound){
                for(int a = 0; a<Constants.Constants.LINK_LENGTH;a++){
                    generatedString += await _lookupTable.GetMinimumGeneratedChar(a);
                }
                if(await _linkCache.IsLinkExist(generatedString)){
                    generatedString = string.Empty;
                }else{
                    isFound = false;
                }
            }
            return generatedString;
        }
    }
}