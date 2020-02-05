using NUnit.Framework;
using Moq;
using LinkShortener.Core.Interfaces;
using System.Collections.Generic;

namespace LinkShortener.Core.Test
{
    public class RandomCharGeneratorTest
    {
         [Test]
         public void Should_Return_Minimum_Count_Of_Chars()
         {
            IRandomCharGenerator randomCharGenerator = new RandomCharGenerator();
            Dictionary<char,int[]> lookupTable = new Dictionary<char, int[]>();
            lookupTable.Add('a',new int[]{0,1,1,1,1});
            lookupTable.Add('b',new int[]{1,0,1,1,1});
            lookupTable.Add('c',new int[]{1,1,0,1,1});
            lookupTable.Add('d',new int[]{1,1,1,0,1});
            lookupTable.Add('e',new int[]{1,1,1,1,0});
            Assert.AreEqual('a',randomCharGenerator.GetRandomCharFromArray(lookupTable,0));
            Assert.AreEqual('b',randomCharGenerator.GetRandomCharFromArray(lookupTable,1));
            Assert.AreEqual('c',randomCharGenerator.GetRandomCharFromArray(lookupTable,2));
            Assert.AreEqual('d',randomCharGenerator.GetRandomCharFromArray(lookupTable,3));
            Assert.AreEqual('e',randomCharGenerator.GetRandomCharFromArray(lookupTable,4));
         }
    }
}