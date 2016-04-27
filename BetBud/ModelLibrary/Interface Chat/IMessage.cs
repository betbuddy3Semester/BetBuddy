using System;

namespace ModelLibrary.Interface_Chat
{
    public interface IMessage
    {
        // Prop's
        string Message { get; set; }
        int UserID();
        DateTime Date { get; set; }

        // Methods
        string PushMessage();
    }
}
