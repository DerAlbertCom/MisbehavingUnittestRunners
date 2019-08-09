using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        [Fact(Skip = "Skipped with Fact")]
        public void Test1()
        {

        }

        // this one is where the problems starts
        [SkipFact(Skip = "Simple not run, not skipped")]
        public void Test2()
        {

        }

        // this on beh
        [Fact]
        public void Test3()
        {

        }


    }

    public class UnitTest2
    {
        [Fact(Skip = "Skipped with Fact")]
        public void Test10()
        {

        }

        [SkipFact()]
        public void Test20()
        {

        }

        [Fact]
        public void Test30()
        {

        }
    }

    public class SkipFact : FactAttribute
    {
        // Yes, this is a wrong implementation, but the compiler does not complain, so it seems
        // legit to override a getter/setter property with getter only.
        // The problem is not the wrong implementation, the problem is that exceptions in the xUnit test
        // discovery for whatever reason are not bubbled up, and in the worst case simple swallowed and 
        // the test does not run, but without any notice (each runner behaves a little bit different).

        public override string Skip => "Skipped";
    }
}
