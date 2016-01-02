using BBK.App.DataAccess;
using System.Linq;
using WebApi.Controllers;
using Xunit;
using System;

namespace BBK.App.Tests.Controllers
{
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
