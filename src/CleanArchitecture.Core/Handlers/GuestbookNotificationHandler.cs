using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Handlers
{
    public class GuestbookNotificationHandler : IHandle<EntryAddedEvent>
    {
	    private readonly IRepository<Guestbook> _guestbookRepository;
	    private readonly IMessageSender _messageSender;

	    public GuestbookNotificationHandler(IRepository<Guestbook> guestbookRepository, IMessageSender messageSender)
	    {
		    if (guestbookRepository == null)
			    throw new ArgumentNullException(nameof(guestbookRepository));
		    if (messageSender == null)
			    throw new ArgumentNullException(nameof(messageSender));
		    _guestbookRepository = guestbookRepository;
		    _messageSender = messageSender;
	    }

	    public void Handle(EntryAddedEvent domainEvent)
	    {
		    throw new NotImplementedException();
	    }
    }
}
