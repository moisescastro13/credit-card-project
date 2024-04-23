using CreditCardUI.Interfaces;
using CreditCardUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardUI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index(Guid Id)
        {
            ViewBag.Id = Id;

            return View();
        }
        public async Task<IActionResult> Details(Guid Id, DateTime FromDate)
        {
            var transactions = await _transactionService.TransactionsDetails(Id, FromDate);

            ViewBag.FromDate = FromDate;
            ViewBag.Id = Id;    
            return View(transactions);
        }

        public async Task<IActionResult> DetailsPDF(Guid Id, DateTime FromDate)
        {
            var pfd = await _transactionService.TransactionsPDF(Id, FromDate);

            return File(pfd, "application/pdf", "EstadoDeCuenta.pdf");
        }

        public async Task<IActionResult> Create(CreateTransactionDto createTransactionDto)
        {
            await _transactionService.Create(createTransactionDto);


            return RedirectToAction("Index", "Home");
        }
    }
}
