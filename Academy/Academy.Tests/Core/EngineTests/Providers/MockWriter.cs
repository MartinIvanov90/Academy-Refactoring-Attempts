using System;
using Academy.Core.Contracts;
using System.Text;

namespace Academy.Tests.Core.EngineTests.Providers
{
    public class MockWriter : IWriter
    {
        public string MessageString { get; private set; }

        public void Write(string message)
        {
            //Just setting dem properties
            MessageString = message;
        }
    }
}
