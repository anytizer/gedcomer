using System;
using System.IO.MemoryMappedFiles;
using classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            filer f = new filer("");

            Assert.AreEqual("", f.contents);
        }
    }
}
