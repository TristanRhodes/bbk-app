using BBK.App.DataAccess;
using LightMock;
using System;
using System.Diagnostics;
using System.Dynamic;
using WebApi.Controllers;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BBK.App.Tests.Controllers
{
    public class DiTestControllerTests
    {
        private DiTestController _branchesController;
        private MockContext<IBasicDataAccess> _mockContext;

        public DiTestControllerTests()
        {
            _mockContext = new MockContext<IBasicDataAccess>();
            var mock = CreateMock(_mockContext);
            _branchesController = new DiTestController(mock);
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

        public T CreateMock<T>(IInvocationContext<T> context) where T : class
        {
            dynamic expando = new ExpandoObject();
            expando.Message = "Expando Message!";
            Trace.WriteLine((string)expando.Message);

            dynamic myDynamic = new TestMock<T>(context);
            T typedDynamic = (T)myDynamic;    

            var thing = new BasicDataAccessMock(_mockContext) as T;
            return thing;
        }
    }

    public class BasicDataAccessMock : IBasicDataAccess
    {
        private IInvocationContext<IBasicDataAccess> _mockContext;

        public BasicDataAccessMock(IInvocationContext<IBasicDataAccess> mockContext)
        {
            _mockContext = mockContext;
        }

        public string EchoMessage(string message)
        {
            return _mockContext.Invoke(c => c.EchoMessage(message));
        }
    }

    public class TestMock<T> : DynamicObject
    {
        private IInvocationContext<T> _mockContext;

        public TestMock(IInvocationContext<T> mockContext)
        {
            _mockContext = mockContext;
        }

        public override DynamicMetaObject GetMetaObject(Expression parameter)
        {
            DynamicMetaObject result = new TestMockMetaObject(parameter, this);
            return result;
        }

        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result)
        {
            return base.TryBinaryOperation(binder, arg, out result);
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            return base.TryConvert(binder, out result);
        }

        public override bool TryCreateInstance(CreateInstanceBinder binder, object[] args, out object result)
        {
            return base.TryCreateInstance(binder, args, out result);
        }

        public override bool TryDeleteIndex(DeleteIndexBinder binder, object[] indexes)
        {
            return base.TryDeleteIndex(binder, indexes);
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            return base.TryDeleteMember(binder);
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            return base.TryGetIndex(binder, indexes, out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return base.TryGetMember(binder, out result);
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            return base.TrySetIndex(binder, indexes, value);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return base.TrySetMember(binder, value);
        }

        public override bool TryUnaryOperation(UnaryOperationBinder binder, out object result)
        {
            return base.TryUnaryOperation(binder, out result);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return base.GetDynamicMemberNames();
        }
    }

    class TestMockMetaObject : DynamicMetaObject
    {
        public TestMockMetaObject(Expression expression, DynamicObject value)
            : base(expression, BindingRestrictions.Empty, (object)value)
        {
        }

        public override DynamicMetaObject BindConvert(ConvertBinder binder)
        {
            BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

            //if the type requested is compatible with the 
            //instance, there's no conversion to be done.
            if (binder.Type.IsAssignableFrom(LimitType))
                return binder.FallbackConvert(
                    new DynamicMetaObject(Expression, restrictions, Value));

            if (LimitType.IsGenericType &&
                LimitType.GetGenericTypeDefinition().Equals(typeof(TestMock<>)))
            {
                //get the type parameter for T
                Type proxiedType = LimitType.GetGenericArguments()[0];

                //now check that the proxied type is compatible 
                //with the desired conversion type
                if (binder.ReturnType.IsAssignableFrom(proxiedType))
                {
                    //this FieldInfo lookup can be cached by 
                    //proxiedType in a static ConcurrentDictionary
                    //to cache the reflection for future use
                    FieldInfo context = LimitType.GetField("_mockContext", BindingFlags.Instance | BindingFlags.NonPublic);

                    //return a field expression that retrieves the 
                    //private 't' field of the DynamicProxy
                    //note that we also have to convert 'Expression'
                    //to the proxy type - which we've already ascertained
                    //is the LimitType for this dynamic operation.
                    var fieldExpr = Expression.Field(
                        Expression.Convert(Expression, LimitType), context);
                    
                    var typ = Expression.TypeAs(Expression, proxiedType);

                    //but because we're allowing bases or interfaces of 'T',
                    //it's a good idea to chuck in a 'Convert'
                    return new DynamicMetaObject(
                        Expression.Convert(typ, binder.ReturnType),
                        restrictions);
                }
            }

            return base.BindConvert(binder);
        }
    }
}