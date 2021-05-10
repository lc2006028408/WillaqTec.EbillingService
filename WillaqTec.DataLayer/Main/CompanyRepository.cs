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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMainCommandText _mainCommandText;
        private readonly string _connectionString;

        public CompanyRepository(IConfiguration configuracion, IMainCommandText mainCommandText)
        {
            _mainCommandText = mainCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(CompanyEntity companyEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(companyEntity);
                dynamicParameters.Add("CompanyId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.AddCompany,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    companyEntity.CompanyId = dynamicParameters.Get<int>("CompanyId");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return indicator;
        }

        public async Task<int> UpdateAsync(CompanyEntity companyEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(companyEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.UpdateCompany,
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

        public async Task<CompanyEntity> GetByIdAsync(int CompanyId)
        {
            var rs = new CompanyEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<CompanyEntity>(
                                        _mainCommandText.GetCompanyById,
                                        new { CompanyId = CompanyId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<CompanyEntity>> GetAllAsync()
        {
            var ls = new List<CompanyEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<CompanyEntity>(
                                        _mainCommandText.GetAllCompany,
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
