using System.Collections.Generic;
using System.Threading.Tasks;

namespace WillaqTec
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        //Basic

        public async Task<int> AddAsync(CompanyEntity companyEntity)
        {
            return await _companyRepository.AddAsync(companyEntity);
        }

        public async Task<int> UpdateAsync(CompanyEntity companyEntity)
        {
            return await _companyRepository.UpdateAsync(companyEntity);
        }

        public async Task<CompanyEntity> GetByIdAsync(int companyId)
        {
            return await _companyRepository.GetByIdAsync(companyId);
        }

        public async Task<List<CompanyEntity>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }
    }
}
