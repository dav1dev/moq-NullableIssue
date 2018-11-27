using System;

namespace moq_NullableIssue
{
    public interface IHandler
    {
        IResult Do(Guid id);
        IResult Do(int id);
        IResult DoNullable(Guid? id);
    }
}