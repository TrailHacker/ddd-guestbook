using System;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Services
{
	public class GuestbookService : IGuestbookService
	{
		private readonly IRepository<Guestbook> _repository;
		private readonly IMessageSender _messageSender;

		public GuestbookService(IRepository<Guestbook> repository, IMessageSender messageSender)
		{
			if (repository == null)
				throw new ArgumentNullException(nameof(repository));
			if (messageSender == null)
				throw new ArgumentNullException(nameof(messageSender));

			_repository = repository;
			_messageSender = messageSender;
		}

		public void RecordEntry(Guestbook guestbook, GuestbookEntry entry)
		{
			guestbook.Entries.Add(entry);
			_repository.Update(guestbook);
		}
	}
}