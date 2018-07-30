using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCSRedis
{
    [TestClass]
    public class TestClient : TestBase
    {
        [TestMethod]
        public void MultClientTest()
        {
            for (int i = 0; i < 10000; i++)
            {
                string key = "test" + i;
                string value = "value" + i;
                Client.Set(key, value, 10);
                Assert.AreEqual(value, Client.Get(key));
            }
        }
        [TestMethod]
        public async Task MultClientTestAsync()
        {
            for (int i = 0; i < 10000; i++)
            {
                string key = "testasync" + i;
                string value = "valueasync" + i;
                await Client.SetAsync(key, value, 10);
                Assert.AreEqual(value, await Client.GetAsync(key));
            }
        }
        [TestMethod]
        public void MultTaskClientTest()
        {
            var result = Parallel.For(0, 1000000, async i =>
             {
                 string key = "testTaskasync" + i;
                 string value = "valueTaskasync" + i;
                 await Client.SetAsync(key, value, 10);
                 Assert.AreEqual(value, await Client.GetAsync(key));
             });
        }
    }
}
