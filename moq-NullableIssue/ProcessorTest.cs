using System;
using Moq;
using Xunit;

namespace moq_NullableIssue
{
    public class ProcessorTest
    {
        private readonly Mock<IHandler> _handler;
        private readonly Processor _testee;

        public ProcessorTest()
        {
            _handler = new Mock<IHandler>();
            _testee = new Processor(_handler.Object);
        }

        [Fact]
        public void Process_SetupDoWithGuid_GetUnexpectedException()
        {
            var id = Guid.NewGuid();
            var data = Mock.Of<DataStructureGuid>(x => x.Id == id);
            _handler.Setup(x => x.Do(data.Id.Value)).Returns(Mock.Of<IResult>());

            _testee.Process(id);
        }

        [Fact]
        public void Process_SetupDoWithInt_GetUnexpectedException()
        {
            const int id = int.MaxValue;
            var data = Mock.Of<DataStructureInt>(i => i.Id == id);
            _handler.Setup(x => x.Do(data.Id.Value));

            _testee.Process(id);
        }

        [Fact]
        public void DoNullable_SetupGuid_NoException()
        {
            var id = Guid.NewGuid();
            var data = Mock.Of<DataStructureGuid>(i => i.Id == id);
            _handler.Setup(x => x.DoNullable(data.Id));

            _testee.Process(id);
        }
    }
}
