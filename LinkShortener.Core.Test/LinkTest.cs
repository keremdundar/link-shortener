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
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(0)).ReturnsAsync('a');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(1)).ReturnsAsync('b');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(2)).ReturnsAsync('X');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(3)).ReturnsAsync('c');
            mockLookupTable.Setup(p=>p.GetMinimumGeneratedChar(4)).ReturnsAsync('d');
            mockLinkCache.Setup(p=>p.IsLinkExist(It.IsAny<string>())).ReturnsAsync(false);
            Link link = new Link(mockLookupTable.Object,mockLinkCache.Object);
            Assert.AreEqual("abXcd",await link.GenerateAsync());
        }
    }
}