using System.Collections.Generic;
using System.Threading.Tasks;

namespace WillaqTec
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        //Basic

        public async Task<int> AddAsync(PaymentEntity paymentEntity)
        {
            return await _paymentRepository.AddAsync(paymentEntity);
        }

        public async Task<int> UpdateAsync(PaymentEntity paymentEntity)
        {
            return await _paymentRepository.UpdateAsync(paymentEntity);
        }

        public async Task<PaymentEntity> GetByIdAsync(int paymentId)
        {
            return await _paymentRepository.GetByIdAsync(paymentId);
        }

        public async Task<List<PaymentEntity>> GetAllAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

    }
}
