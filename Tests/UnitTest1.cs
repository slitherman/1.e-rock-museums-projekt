using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<string, string> hello = new Dictionary<string, string>();
            hello["nig"] = "ger";
            Dictionary<string, string> world = new Dictionary<string, string>();
            world["foo"] = "bar";
            hello.ToList().ForEach(x => world.Add(x.Key, x.Value));
            //var CombinedCollections = hello.Concat(world.Where(kvp => hello.ContainsKey(kvp.Key)));
            Console.WriteLine("he");
        }
    }
}
