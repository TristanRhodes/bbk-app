using BBK.App.DataAccess;
using BBK.App.Tests.Mocks;
using LightMock;
using WebApi.Controllers;
using Xunit;

namespace BBK.App.Tests.Controllers
{
    public class DiTestControllerTests
    {
        private DiTestController _branchesController;
        private MockContext<IBasicDataAccess> _mockContext;

        public DiTestControllerTests()
        {
            _mockContext = new MockContext<IBasicDataAccess>();
            _branchesController = new DiTestController(_mockContext.CreateInstance());
        }

        [Fact]
        public void TestMock()
        {
            var message = "This is a message!";

            _mockContext
                .Arrange(f => f.EchoMessage(message))
                .Returns(message);

            _branchesController.EchoMessage(message);

            _mockContext.Assert(f => f.EchoMessage(message));
        }
    }
}
