using BBK.App.DataAccess;
using LightMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBK.App.Tests.Mocks
{
    /// <summary>
    /// Extension methods for use with the MockContext for creating mock instances.
    /// </summary>
    public static class MockContextExtensions
    {
        private static IReadOnlyDictionary<Type, Func<object, object>> _collection ;

        static MockContextExtensions()
        {
            var collection = new Dictionary<Type, Func<object, object>>();

            // NOTE: Bootstrap instance constructors here.
            collection.Add(typeof(IBasicDataAccess), (context) => new MockIBasicDataAccess((MockContext<IBasicDataAccess>)context));

           _collection = collection;
        }

        public static T CreateInstance<T>(this MockContext<T> context)
        {
            var type = typeof(T);

            if (!_collection.ContainsKey(type))
                throw new ArgumentException("Context not handled");

            return (T)_collection[type](context);
        }
    }
}
