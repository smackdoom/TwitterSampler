using System;
namespace TwitterSampler.Models
{
    public class TryGetResult
    {
        public TryGetResult() { }

        public TryGetResult(bool success) : this(success, null) { }

        public TryGetResult(Exception exception) : this(exception == null, exception) { }

        public TryGetResult(bool success, Exception exception)
        {
            Success = success;
            Exception = exception;
        }

        public virtual bool Success { get; set; }
        public string Message { get; set; }
        public virtual Exception Exception { get; set; }

        public virtual string GetErrorMessage()
        {
            var message = Exception?.Message ?? Message ?? string.Empty;
            if (!Success && string.IsNullOrEmpty(message))
                message = "Unspecified error";
            return message;
        }

        public virtual string GetMessage()
        {
            if (Success)
                return Message ?? string.Empty;
            else
                return GetErrorMessage();
        }
    }

    public class TryGetResult<T> : TryGetResult
    {
        public TryGetResult() { }
        public TryGetResult(T value) : base(true)
        {
            Result = value;
        }
        public TryGetResult(T value, Exception exception) : base(exception)
        {
            Result = value;
        }
        public TryGetResult(Exception exception) : base(exception) { }

        public virtual T Result { get; set; }
    }
}
