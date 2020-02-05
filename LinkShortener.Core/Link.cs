using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkShortener.Core.Interfaces;

namespace LinkShortener.Core
{
    public class Link : ILink
    {
        private readonly ILookupTable _lookupTable;
        private readonly ILinkCache _linkCache;
        private readonly IRandomCharGenerator _randomCharGenerator;
        private readonly Random random;
        public Link(ILookupTable lookupTable,ILinkCache linkCache,IRandomCharGenerator randomCharGenerator)
        {
            _lookupTable = lookupTable;
            _linkCache = linkCache;
            _randomCharGenerator = randomCharGenerator;
            random = new Random();
        }
        public async Task<string> GenerateAsync()
        {
            string generatedString = string.Empty;
            bool isFound = true;
            var lookupValues = await _lookupTable.GeneratedNumberOfCharTable();
            while(isFound){
                for(int a = 0; a<Constants.Constants.LINK_LENGTH;a++){
                    generatedString += _randomCharGenerator.GetRandomCharFromArray(lookupValues,a);
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