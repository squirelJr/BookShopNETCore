using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Notify
{
  
        public class PublishBookNotify : INotification
        {
            public string Message { get; set; }
        }

        public class PublishProductNotifyMessageHandler : INotificationHandler<PublishBookNotify>
        {
            public Task Handle(PublishBookNotify notification, CancellationToken cancellationToken)
            {
                //TODO: Send message
                Console.WriteLine($"Message: {notification.Message}");
                return Task.CompletedTask;
            }
        }

        public class PublishProductNotifyTextHandler : INotificationHandler<PublishBookNotify>
        {
            public Task Handle(PublishBookNotify notification, CancellationToken cancellationToken)
            {
                //TODO: Send text
                Console.WriteLine($"Text: {notification.Message}");
                return Task.CompletedTask;
            }
        }
    
}
