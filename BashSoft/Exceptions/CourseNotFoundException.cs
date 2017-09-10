﻿namespace BashSoft.Exceptions
{
    using System;

    public class CourseNotFoundException : Exception
    {
        public const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        public CourseNotFoundException()
            : base(NotEnrolledInCourse)
        {
        }
    }
}