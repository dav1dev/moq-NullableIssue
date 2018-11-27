using System;

namespace moq_NullableIssue
{
    public class Processor
    {
        private readonly IHandler _handler;

        public Processor(IHandler handler)
        {
            _handler = handler;
        }

        public void Process(Guid id)
        {
            _handler.Do(id);
        }
        public void Process(int id)
        {
            _handler.Do(id);
        }
    }
}