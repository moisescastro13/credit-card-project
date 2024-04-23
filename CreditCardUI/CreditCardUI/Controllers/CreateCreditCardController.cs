using CreditCardUI.Interfaces;
using CreditCardUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardUI.Controllers;

public class CreateCreditCardController: Controller
{
    private readonly ICreditCardService _creditCardService;

    public CreateCreditCardController(ICreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create(CreateCreditCardDto createCreditCardDto)
    {
        if (ModelState.IsValid)
        {
            await _creditCardService.Create(createCreditCardDto);

        }

        return RedirectToAction("Index", "Home");
    }
}
