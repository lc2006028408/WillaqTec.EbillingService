using System.Collections.Generic;
using System.Threading.Tasks;

namespace WillaqTec
{
    public class IdentityDocumentTypeService : IIdentityDocumentTypeService
    {
        private readonly IIdentityDocumentTypeRepository _identityDocumentTypeRepository;

        public IdentityDocumentTypeService(IIdentityDocumentTypeRepository IdentityDocumentTypeRepository)
        {
            _identityDocumentTypeRepository = IdentityDocumentTypeRepository;
        }

        //Basic

        public async Task<int> AddAsync(IdentityDocumentTypeEntity identityDocumentTypeEntity)
        {
            return await _identityDocumentTypeRepository.AddAsync(identityDocumentTypeEntity);
        }

        public async Task<int> UpdateAsync(IdentityDocumentTypeEntity identityDocumentTypeEntity)
        {
            return await _identityDocumentTypeRepository.UpdateAsync(identityDocumentTypeEntity);
        }

        public async Task<IdentityDocumentTypeEntity> GetByIdAsync(int identityDocumentTypeId)
        {
            return await _identityDocumentTypeRepository.GetByIdAsync(identityDocumentTypeId);
        }

        public async Task<List<IdentityDocumentTypeEntity>> GetAllAsync()
        {
            return await _identityDocumentTypeRepository.GetAllAsync();
        }

    }
}
