using BankingMicroRabbit.Mvc.Models.DTO;
using System.Threading.Tasks;

namespace BankingMicroRabbit.Mvc.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDTO transferDTO);
    }
}
