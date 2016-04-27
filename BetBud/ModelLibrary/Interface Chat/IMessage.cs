using System;

namespace ModelLibrary.Interface_Chat
{
    public interface IMessage
    {
        #region Properties

        string UserMessage { get; set; }
        int UserId { get; set; }
        DateTime Date { get; set; }

        #endregion

        #region Methods

        string PushMessage();

        #endregion
    }
}