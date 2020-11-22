using System;
using System.Diagnostics.CodeAnalysis;

namespace GripDigital.Test.Core.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}