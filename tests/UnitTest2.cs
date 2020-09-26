using System;
using classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            filer f = new filer(@"gedcom.ged");

            gedcomer gc = new gedcomer();
            gc.parse(f.contents);

            Assert.IsTrue(gc.ToString().Length >= 10);
        }
    }
}
