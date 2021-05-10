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
    public class CompanyCreditCardRepository : ICompanyCreditCardRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMainCommandText _mainCommandText;
        private readonly string _connectionString;

        public CompanyCreditCardRepository(IConfiguration configuracion, IMainCommandText mainCommandText)
        {
            _mainCommandText = mainCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(CompanyCreditCardEntity companyCreditCardEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(companyCreditCardEntity);
                dynamicParameters.Add("CompanyCreditCardId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.AddCompanyCreditCard,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    companyCreditCardEntity.CompanyCreditCardId = dynamicParameters.Get<int>("CompanyCreditCardId");
                }
            }
            catch (Exception exception)
            {

            }

            return indicator;
        }

        public async Task<int> UpdateAsync(CompanyCreditCardEntity companyCreditCardEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(companyCreditCardEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.UpdateCompanyCreditCard,
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

        public async Task<CompanyCreditCardEntity> GetByIdAsync(int companyCreditCardId)
        {
            var rs = new CompanyCreditCardEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<CompanyCreditCardEntity>(
                                        _mainCommandText.GetCompanyCreditCardById,
                                        new { CompanyCreditCardId = companyCreditCardId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<CompanyCreditCardEntity>> GetAllAsync()
        {
            var ls = new List<CompanyCreditCardEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<CompanyCreditCardEntity>(
                                        _mainCommandText.GetAllCompanyCreditCard,
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

