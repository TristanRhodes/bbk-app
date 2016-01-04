using BBK.App.DataAccess;
using LightMock;

namespace BBK.App.Tests.Mocks
{
    public class MockIBasicDataAccess : IBasicDataAccess
    {
        private IInvocationContext<IBasicDataAccess> _mockContext;

        public MockIBasicDataAccess(IInvocationContext<IBasicDataAccess> mockContext)
        {
            _mockContext = mockContext;
        }

        public string EchoMessage(string message)
        {
            return _mockContext.Invoke(c => c.EchoMessage(message));
        }
    }
}
