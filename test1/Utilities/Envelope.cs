namespace test1.Utilities
{
    public class Envelope<T>
    {
        public T Result { get; }

        public object Error { get; }

        public DateTime TimeGenerated { get; }

        /// <summary>
        /// Parameter rise constructor with error messages and generic result
        /// </summary>
        /// <param name="result">The type of the object</param>
        /// <param name="errorMessage">Error messages</param>
        protected internal Envelope(T result, object errorMessage)
        {
            Result = result;
            Error = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }
    /// <summary>
    /// Envelope class for generic response base on response type
    /// </summary>
    public sealed class Envelope : Envelope<string>
    {
        /// <summary>
        /// Parameter rise constructor with one argument
        /// </summary>
        /// <param name="errorMessage"></param>
        private Envelope(object errorMessage)
            : base(null, errorMessage)
        {
        }

        /// <summary>
        /// Return success response with specified type
        /// </summary>
        /// <typeparam name="T">Specified type</typeparam>
        /// <param name="result">Any object</param>
        /// <returns>Success response with specified type</returns>
        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        /// <summary>
        /// Return success response without any type
        /// </summary>
        /// <returns>Success response</returns>
        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        /// <summary>
        /// Return error response with error messages
        /// </summary>
        /// <param name="errorMessage">Specified error messages</param>
        /// <returns>Error response in error messages</returns>
        public static Envelope ErrorMessage(object errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }
}


