using System;

namespace Domain.Notifications
{
    public class Notification
    {
        public Notification(string key, string value, string statusCode)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            ErrorCode = statusCode;
        }

        public Notification(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            ErrorCode = "400";
        }

        public Guid Id { get; }
        public string Key { get; }
        public string Value { get; }

        public string ErrorCode { get; set; }
    }
}