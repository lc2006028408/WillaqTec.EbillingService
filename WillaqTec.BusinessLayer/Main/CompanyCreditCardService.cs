using System.Collections.Generic;
using System.Threading.Tasks;

namespace WillaqTec
{
    public class CompanyCreditCardService : ICompanyCreditCardService
    {
        private readonly ICompanyCreditCardRepository _companyCreditCardRepository;

        public CompanyCreditCardService(ICompanyCreditCardRepository companyCreditCardRepository)
        {
            _companyCreditCardRepository = companyCreditCardRepository;
        }

        //Basic

        public async Task<int> AddAsync(CompanyCreditCardEntity companyCreditCardEntity)
        {
            return await _companyCreditCardRepository.AddAsync(companyCreditCardEntity);
        }

        public async Task<int> UpdateAsync(CompanyCreditCardEntity companyCreditCardEntity)
        {
            return await _companyCreditCardRepository.UpdateAsync(companyCreditCardEntity);
        }

        public async Task<CompanyCreditCardEntity> GetByIdAsync(int companyCreditCardId)
        {
            return await _companyCreditCardRepository.GetByIdAsync(companyCreditCardId);
        }

        public async Task<List<CompanyCreditCardEntity>> GetAllAsync()
        {
            return await _companyCreditCardRepository.GetAllAsync();
        }
    }
}
