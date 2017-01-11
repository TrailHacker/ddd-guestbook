using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Model;

namespace CleanArchitecture.Core.Events
{
    public class EntryAddedEvent : BaseDomainEvent
    {
	    public EntryAddedEvent(int guestbookId, GuestbookEntry entry)
	    {
		    GuestbookId = guestbookId;
		    Entry = entry;
	    }

	    public int GuestbookId { get; private set; }

	    public GuestbookEntry Entry { get; private set; }
    }
}
