using System.Collections.Generic;
using System.Threading.Tasks;


namespace WillaqTec
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        //Basic

        public async Task<int> AddAsync(PersonEntity personEntity)
        {
            return await _personRepository.AddAsync(personEntity);
        }

        public async Task<int> UpdateAsync(PersonEntity personEntity)
        {
            return await _personRepository.UpdateAsync(personEntity);
        }

        public async Task<PersonEntity> GetByIdAsync(int personId)
        {
            return await _personRepository.GetByIdAsync(personId);
        }

        public async Task<List<PersonEntity>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

    }
}
