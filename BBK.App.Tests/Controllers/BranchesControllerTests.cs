using System.Linq;
using WebApi.Controllers;
using Xunit;

namespace BBK.App.Tests.Controllers
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class BranchesControllerTests
    {
        private BranchesController _branchesController;

        public BranchesControllerTests()
        {
            _branchesController = new BranchesController();
        }

        [Fact]
        public void GetBranches()
        {
            var branches = _branchesController
                .GetAllBranches()
                .ToList();

            Assert.Equal(branches[0], "Balham");
            Assert.Equal(branches[1], "Elephant and Castle");
        }
    }
}
