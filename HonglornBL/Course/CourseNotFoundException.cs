﻿using System;

namespace HonglornBL.Exceptions
{
    public sealed class CourseNotFoundException : Exception
    {
        internal CourseNotFoundException() { }

        internal CourseNotFoundException(string message) : base(message) { }

        internal CourseNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}