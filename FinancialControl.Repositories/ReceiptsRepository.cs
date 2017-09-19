using FinancialControl.Repositories.Dto;

namespace FinancialControl.Repositories
{
    public interface IReceiptsRepository
    {
        void AddReceipt(Receipt receipt);
    }
    public class ReceiptsRepository : IReceiptsRepository
    {
        private readonly IDataAccessProxy _dataAccess;

        public ReceiptsRepository(IDataAccessProxy dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void AddReceipt(Receipt receipt)
        {
            _dataAccess.AddReceipt(receipt);
        }
    }
}
