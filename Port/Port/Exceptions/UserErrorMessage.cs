﻿namespace Port.Exceptions
{
    public class UserErrorMessage : Exception
    {
        public UserErrorMessage(string? message) : base(message)
        {
        }
    }
}
