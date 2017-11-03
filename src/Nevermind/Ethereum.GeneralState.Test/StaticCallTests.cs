﻿using NUnit.Framework;

namespace Ethereum.GeneralState.Test
{
    [TestFixture]
    public class StaticCallTests : TestsBase
    {
        [TestCaseSource(nameof(LoadTests), new object[] { "StaticCallTests" })]
        public void Test(GenerateStateTest generateStateTest)
        {    
            RunTest(generateStateTest);
        }
    }
}