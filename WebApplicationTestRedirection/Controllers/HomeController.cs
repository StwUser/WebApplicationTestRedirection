using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationTestRedirection.Implementations;
using WebApplicationTestRedirection.Interfaces;
using WebApplicationTestRedirection.Models;

namespace WebApplicationTestRedirection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAddressesRepository _repository;

        public HomeController(ILogger<HomeController> logger, IAddressesRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_repository.AddAddress(new Address() { LongUrl = "long2", ShortUrl = "short2", CreationData = "data2", Transitions = 0 });

            var addresses = _repository.GetAddresses();

            ViewBag.Addresses = addresses;

            return View();
        }

        [HttpGet]
        public ActionResult R(string t)
        {
            if (t == null)
            {
                return new RedirectResult(@"http://localhost:5000/NotFoundPage.html");
            }

            var req =
                (from address in _repository.GetAddresses()
                 where address.ShortUrl.Substring(address.ShortUrl.Length -6) == t
                 select address).FirstOrDefault();

            if (req == null)
            {
                return new RedirectResult(@"http://localhost:5000/NotFoundPage.html");
            }

            req.Transitions += 1;
            _repository.UpdateAddress(req.Id, req);

           return new RedirectResult(req.LongUrl);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Create(Address address)
        {
            IEnumerable<string> request =
                from add in _repository.GetAddresses()
                select add.ShortUrl;

            var urlsCollection = new List<string>(request);

            var result = AddressCreator.Create(address, urlsCollection);

            if (result) 
            {
                _repository.AddAddress(address);
                return "Запись создана";
            }

            return "Введеный Url не валиден.";
        }

        public string Delete(int id)
        {
            _repository.DeleteAddress(id);

            return "Запись удалена.";
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (id != 0)
            {
                var address = _repository.GetAddress(id);
                ViewBag.Id = address.Id;
                ViewBag.LongUrl = address.LongUrl;
                ViewBag.ShortUrl = address.ShortUrl;
                ViewBag.CreationData = address.CreationData;
                ViewBag.Transitions = address.Transitions;
            }
            return View();
        }

        [HttpPost]
        public string Update(Address address)
        {
            _repository.UpdateAddress(address.Id, address);
            return "Запись обновлена.";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
