﻿using System;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IGuestbookService _guestbookService;
	    private readonly IMessageSender _messageSender;
	    private readonly IRepository<Guestbook> _guestbookRepository;

        public HomeController(IGuestbookService guestbookService, IMessageSender messageSender, IRepository<Guestbook> guestbookRepository)
        {
	        if (guestbookService == null)
		        throw new ArgumentNullException(nameof(guestbookService));
	        if (messageSender == null)
		        throw new ArgumentNullException(nameof(messageSender));

	        _guestbookService = guestbookService;
	        _messageSender = messageSender;
	        _guestbookRepository = guestbookRepository;
        }

        public IActionResult Index()
        {
            if (!_guestbookRepository.List().Any())
            {
                var newGuestbook = new Guestbook() {Name = "My Guestbook"};
                newGuestbook.Entries.Add(new GuestbookEntry()
                {
                    EmailAddress = "steve@deviq.com",
                    Message = "Hi!" });
                _guestbookRepository.Add(newGuestbook);
            }

            //var guestbook = _guestbookRepository.List().FirstOrDefault();
            var guestbook = _guestbookRepository.GetById(1);
            var viewModel = new HomePageViewModel();
            viewModel.GuestbookName = guestbook.Name;
            viewModel.PreviousEntries.AddRange(guestbook.Entries);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guestbook = _guestbookRepository.GetById(1);
				_guestbookService.RecordEntry(guestbook, model.NewEntry); 

                model.PreviousEntries.Clear();
                model.PreviousEntries.AddRange(guestbook.Entries);
            }
            return View(model);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
