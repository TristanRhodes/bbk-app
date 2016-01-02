﻿//using BBK.App.DataAccess;
//using LightMock;
//using WebApi.Controllers;
//using Xunit;

//namespace BBK.App.Tests.Controllers
//{
//    public class DiTestControllerTests
//    {
//        private DiTestController _branchesController;
//        private MockContext<IBasicDataAccess> _mockContext;

//        public DiTestControllerTests()
//        {
//            _mockContext = new LightMock.MockContext<IBasicDataAccess>();
//            var mock = new BasicDataAccessMock(_mockContext);
//            _branchesController = new DiTestController(mock);
//        }

//        [Fact]
//        public void TestMock()
//        {
//            var message = "This is a message!";

//            _mockContext
//                .Arrange(f => f.EchoMessage(message))
//                .Returns(message);

//            _mockContext.Assert(f => f.EchoMessage(message));
//        }
//    }

//    public class BasicDataAccessMock : IBasicDataAccess
//    {
//        private IInvocationContext<IBasicDataAccess> _mockContext;

//        public BasicDataAccessMock(IInvocationContext<IBasicDataAccess> mockContext)
//        {
//            _mockContext = mockContext;
//        }

//        public string EchoMessage(string message)
//        {
//            return _mockContext.Invoke(c => c.EchoMessage(message));
//        }
//    }
//}
