using Xunit;
using ASApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NameIsTestReturned()
        {
            // arrange
            var product = new Product { Id = 3, Name = "Test", Price = 330 };

            // act
            ProductRep.Add(product);
            var res = ProductRep.Get(3);


            // assert
            Xunit.Assert.Equal("Test", res.Name);
        }
    }
}