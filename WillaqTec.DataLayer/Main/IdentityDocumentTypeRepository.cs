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
    public class IdentityDocumentTypeRepository : IIdentityDocumentTypeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMainCommandText _mainCommandText;
        private readonly string _connectionString;

        public IdentityDocumentTypeRepository(IConfiguration configuracion, IMainCommandText mainCommandText)
        {
            _mainCommandText = mainCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(IdentityDocumentTypeEntity identityDocumentTypeEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(identityDocumentTypeEntity);
                dynamicParameters.Add("IdentityDocumentTypeId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.AddIdentityDocumentType,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    identityDocumentTypeEntity.IdentityDocumentTypeId = dynamicParameters.Get<int>("IdentityDocumentTypeId");
                }
            }
            catch (Exception exception)
            {

            }

            return indicator;
        }

        public async Task<int> UpdateAsync(IdentityDocumentTypeEntity identityDocumentTypeEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(identityDocumentTypeEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _mainCommandText.UpdateIdentityDocumentType,
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


        public async Task<IdentityDocumentTypeEntity> GetByIdAsync(int identityDocumentTypeId)
        {
            var rs = new IdentityDocumentTypeEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<IdentityDocumentTypeEntity>(
                                        _mainCommandText.GetIdentityDocumentTypeById,
                                        new { IdentityDocumentTypeId = identityDocumentTypeId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<IdentityDocumentTypeEntity>> GetAllAsync()
        {
            var ls = new List<IdentityDocumentTypeEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<IdentityDocumentTypeEntity>(
                                        _mainCommandText.GetAllIdentityDocumentType,
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
