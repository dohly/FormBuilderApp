using System;

namespace Infrastructure.Services
{
    public interface ILogger
    {
        void Error(Exception e);
    }
    public class DummyLogger : ILogger
    {
        public void Error(Exception e)
        {
            // todo: log it
        }
    }
}
