using System.Collections.Generic;
using System.Threading.Tasks;


namespace WillaqTec
{
    public class PaymentPlanService : IPaymentPlanService
    {
        private readonly IPaymentPlanRepository _paymentPlanRepository;
        public PaymentPlanService(IPaymentPlanRepository paymentPlanRepository)
        {
            _paymentPlanRepository = paymentPlanRepository;
        }

        //Basic

        public async Task<int> AddAsync(PaymentPlanEntity paymentPlanEntity)
        {
            return await _paymentPlanRepository.AddAsync(paymentPlanEntity);
        }

        public async Task<int> UpdateAsync(PaymentPlanEntity paymentPlanEntity)
        {
            return await _paymentPlanRepository.UpdateAsync(paymentPlanEntity);
        }

        public async Task<PaymentPlanEntity> GetByIdAsync(int paymentPlanId)
        {
            return await _paymentPlanRepository.GetByIdAsync(paymentPlanId);
        }

        public async Task<List<PaymentPlanEntity>> GetAllAsync()
        {
            return await _paymentPlanRepository.GetAllAsync();
        }
    }
}
