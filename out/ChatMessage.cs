namespace QNAGen.Models
{
    /// <summary>
    /// Represents a chat message in the QNAGen application.
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        /// Gets or sets the content of the chat message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the message is from the user.
        /// If true, the message is from the user; if false, it's from the AI assistant.
        /// </summary>
        public bool IsUser { get; set; }
    }
}