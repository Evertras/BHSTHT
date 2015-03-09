using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace HSDataTest
{
    [TestClass]
    public class AssumptionTests
    {
        [TestMethod]
        public void ListLastMethodIsConstantTime()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Prime
            stopwatch.Start();
            stopwatch.Stop();

            stopwatch.Reset();

            List<int> someList = new List<int>();

            someList.Add(17);

            stopwatch.Start();

            someList.Last();

            stopwatch.Stop();

            var smallTimer = stopwatch.ElapsedMilliseconds;

            const int numToAdd = 100000;

            for (int i = 0; i < numToAdd; ++i)
            {
                someList.Add(17);
            }

            stopwatch.Start();

            someList.Last();

            stopwatch.Stop();

            var largeTimer = stopwatch.ElapsedMilliseconds;

            if (largeTimer - smallTimer > 1)
            {
                Assert.Inconclusive("Last might be longer than anticipated...");
            }
        }
    }
}
