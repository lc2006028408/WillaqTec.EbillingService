using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System;
using Dapper;

namespace WillaqTec
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMainCommandText _mainCommandText;
        private readonly string _connectionString;

        public PersonRepository(IConfiguration configuracion, IMainCommandText mainCommandText)
        {
            _mainCommandText = mainCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(PersonEntity personEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(personEntity);
                dynamicParameters.Add("PersonId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.AddPerson,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    personEntity.PersonId = dynamicParameters.Get<int>("PersonId");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return indicator;
        }

        public async Task<int> UpdateAsync(PersonEntity personEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(personEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.UpdatePerson,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                }
            }
            catch (Exception exception)
            {

            }

            return indicator;
        }

        public async Task<PersonEntity> GetByIdAsync(int personId)
        {
            var rs = new PersonEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<PersonEntity>(
                                        _mainCommandText.GetPersonById,
                                        new { PersonId = personId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<PersonEntity>> GetAllAsync()
        {
            var ls = new List<PersonEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<PersonEntity>(
                                        _mainCommandText.GetAllPerson,
                                        commandType: CommandType.StoredProcedure
                                        );
                    ls.AddRange(rs);
                }
            }
            catch (Exception exception)
            {

            }

            return ls;
        }
    }
}
