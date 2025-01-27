using System;

namespace Sirb.Validation.Exceptions
{
    public class StateNotFoundException(string message, Exception innerException) : Exception(DefineMessage(message), innerException)
    {
        [NonSerialized] private const string DefaultMessage = "State not found";

        public StateNotFoundException() : this(DefaultMessage)
        {
        }

        public StateNotFoundException(string message) : this(message, null)
        {
        }

        public StateNotFoundException(Exception innerException) : this(DefaultMessage, innerException)
        {
        }

        private static string DefineMessage(string message, string fallBackMessage = DefaultMessage)
        {
            return string.IsNullOrEmpty(message?.Trim()) ? fallBackMessage : message;
        }

        public static void ThrowIf(bool condition, string message, Exception innerException = null)
        {
            if (condition)
            {
                throw new StateNotFoundException(message, innerException);
            }
        }
    }
}
