﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using Xunit;
using Shouldly;

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
        public void UniTest1()
        {
            var branches = _branchesController
                .GetAllBranches()
                .ToList();

            branches[0].ShouldBe("Balham");
            branches[1].ShouldBe("Elephant and Castle");
        }
    }
}