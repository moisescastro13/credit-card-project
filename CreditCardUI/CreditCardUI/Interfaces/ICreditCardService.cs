using CreditCardUI.Models;

namespace CreditCardUI.Interfaces
{
    public interface ICreditCardService
    {
        Task<IEnumerable<ReadCreditCard>> GetAll();
        Task<ReadCreditCardInformation> GetCreditCardInformation(Guid id);
        Task Create(CreateCreditCardDto createCreditCardDto);
        Task Update(UpdateCreditCardDto updateCreditCardDto);
    }
}