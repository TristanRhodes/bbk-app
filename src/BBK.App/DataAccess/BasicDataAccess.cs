using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBK.App.DataAccess
{
    public interface IBasicDataAccess
    {
        string EchoMessage(string message);
    }

    public class BasicDataAccess : IBasicDataAccess
    {
        public string EchoMessage(string message)
        {
            return message;
        }
    }
}
