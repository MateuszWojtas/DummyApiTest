using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: zapisywanie aktulanych all suers dla asercji  getall
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: nothing at the moment
        }
    }
}
