using NUnit.Framework;
using Moq;
using LinkShortener.Core.Interfaces;
using LinkShortener.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class LinkTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Should_Generate_ShortUrl()
        {
            var mockLookupTable = new Mock<ILookupTable>();  
            var mockLinkCache = new Mock<ILinkCache>();  
            var mockRandomCharGenerator = new Mock<IRandomCharGenerator>();
            Dictionary<char,int[]> lookupTable = new Dictionary<char, int[]>();
            lookupTable.Add('a',new int[]{0,0,0,0,0});
            lookupTable.Add('b',new int[]{0,0,0,0,0});
            lookupTable.Add('c',new int[]{0,0,0,0,0});
            lookupTable.Add('d',new int[]{0,0,0,0,0});
            lookupTable.Add('e',new int[]{0,0,0,0,0});
            mockLookupTable.Setup(p=>p.GeneratedNumberOfCharTable()).ReturnsAsync(lookupTable);
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(0)).ReturnsAsync('a');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(1)).ReturnsAsync('b');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(2)).ReturnsAsync('X');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(3)).ReturnsAsync('c');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(4)).ReturnsAsync('d');
            mockLinkCache.Setup(p=>p.IsLinkExist(It.IsAny<string>())).ReturnsAsync(false);
            mockRandomCharGenerator.Setup(p=>p.GetRandomCharFromArray(lookupTable,It.IsAny<int>())).Returns('a');
            Link link = new Link(mockLookupTable.Object,mockLinkCache.Object,mockRandomCharGenerator.Object);
            Assert.AreEqual("aaaaa",await link.GenerateAsync());
        }
    }
}