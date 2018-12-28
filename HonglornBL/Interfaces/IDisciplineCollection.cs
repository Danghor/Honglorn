using System;

namespace HonglornBL.Interfaces
{
    public interface IDisciplineCollection
    {
        Guid? MaleSprintPKey { get; }
        Guid? MaleJumpPKey { get; }
        Guid? MaleThrowPKey { get; }
        Guid? MaleMiddleDistancePKey { get; }

        Guid? FemaleSprintPKey { get; }
        Guid? FemaleJumpPKey { get; }
        Guid? FemaleThrowPKey { get; }
        Guid? FemaleMiddleDistancePKey { get; }

    }
}