﻿using NUnit.Framework;

namespace Ethereum.GeneralState.Test
{
    [TestFixture]
    public class ReturnDataTests : TestsBase
    {
        [TestCaseSource(nameof(LoadTests), new object[] { "ReturnDataTest" })]
        public void Test(GenerateStateTest generateStateTest)
        {    
            RunTest(generateStateTest);
        }
    }
}