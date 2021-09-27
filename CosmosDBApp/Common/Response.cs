using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBApp.Common
{
    public class Response
    {
        public int StatusCode;
        public string Message;

        public object Result { get; private set; }

        public void AddValue(object @object)
        {
            Result = @object;
        }
    }
}
