using CreditCardUI.Interfaces;
using CreditCardUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreditCardUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICreditCardService _creditCardService;
    public HomeController(ILogger<HomeController> logger, ICreditCardService creditCardService)
    {
        _logger = logger;
        _creditCardService = creditCardService;
    }

    public async Task<IActionResult> Index()
    {
        var creditCards = await _creditCardService.GetAll();

        return View(creditCards);
    }
    public async Task<IActionResult> Details(Guid Id)
    {
        var creditCardInformation = await _creditCardService.GetCreditCardInformation(Id);
        //ViewBag.Id = Id;
        return View(creditCardInformation);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
