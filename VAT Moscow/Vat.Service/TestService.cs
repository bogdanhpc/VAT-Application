using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT
{
    public interface ITestService
    {
        string GetTestService(string test);
    }

    public class TestService : ITestService
    {
        public string GetTestService(string test)
        {
            return "test " + test;
        }
    }
}

