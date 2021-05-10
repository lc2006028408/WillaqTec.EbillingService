using System.Collections.Generic;
using System.Threading.Tasks;

namespace WillaqTec
{
    public class PaymentOperationService : IPaymentOperationService
    {
        private readonly IPaymentOperationRepository _paymentOperationRepository;

        public PaymentOperationService(IPaymentOperationRepository paymentOperationRepository)
        {
            _paymentOperationRepository = paymentOperationRepository;
        }

        //Basic

        public async Task<int> AddAsync(PaymentOperationEntity paymentOperationEntity)
        {
            return await _paymentOperationRepository.AddAsync(paymentOperationEntity);
        }

        public async Task<int> UpdateAsync(PaymentOperationEntity paymentOperationEntity)
        {
            return await _paymentOperationRepository.UpdateAsync(paymentOperationEntity);
        }

        public async Task<PaymentOperationEntity> GetByIdAsync(int paymentOperationId)
        {
            return await _paymentOperationRepository.GetByIdAsync(paymentOperationId);
        }

        public async Task<List<PaymentOperationEntity>> GetAllAsync()
        {
            return await _paymentOperationRepository.GetAllAsync();
        }

    }
}
