using System;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class UpdateEmployeeSteps : BaseSteps
    {
        private string _employeeBaseName; 
        private string _employeeUpdatedName; 
        private string _employeeId;

        [Given(@"I Have employee with id (.*) and name (.*)")]
        public void GivenIHaveEmployeeWithIdAndName(string p0, string p1)
        {
            _employeeId = p0;
            _employeeBaseName = p1 != "null" ? p1 : null;
        }
        
        [Given(@"I update its data with new Name (.*)")]
        public void GivenIUpdateItsDataWithNewName(string p0)
        {
            _employeeUpdatedName = p0 != "null" ? p0 : null;
        }
        
        [Then(@"Response with the same id and new name is shown")]
        public void ThenResponseWithTheSameIdAndNewNameIsShown()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
