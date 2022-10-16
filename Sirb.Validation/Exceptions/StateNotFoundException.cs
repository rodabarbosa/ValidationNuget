#region

using System;
using System.Runtime.Serialization;

#endregion

namespace Sirb.Validation.Exceptions
{
    [Serializable]
    public class StateNotFoundException : Exception, ISerializable
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

        public StateNotFoundException(string message, Exception innerException) : base(DefineMessage(message), innerException)
        {
        }

        public StateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
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
