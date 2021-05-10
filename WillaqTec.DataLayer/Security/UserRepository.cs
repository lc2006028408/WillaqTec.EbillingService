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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityCommandText _securityCommandText;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuracion, ISecurityCommandText securityCommandText)
        {
            _securityCommandText = securityCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(UserEntity userEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(userEntity);
                dynamicParameters.Add("UserId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _securityCommandText.AddUser,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    userEntity.UserId = dynamicParameters.Get<int>("UserId");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return indicator;
        }

        public async Task<int> UpdateAsync(UserEntity userEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(userEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _securityCommandText.UpdateUser,
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

        public async Task<UserEntity> GetByIdAsync(int userId)
        {
            var rs = new UserEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<UserEntity>(
                                        _securityCommandText.GetUserById,
                                        new { UserId = userId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<UserEntity>> GetAllAsync()
        {
            var ls = new List<UserEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<UserEntity>(
                                        _securityCommandText.GetAllUser,
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

        // Advanced
        public async Task<UserEntity> ValidateAsync(string userName, string password)
        {
            var rs = new UserEntity();

            var sPassword = UtilitarianUTL.EncriptarCadena(password);

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<UserEntity>(
                                            _securityCommandText.ValidateUser,
                                            new
                                            {
                                                UserName = userName,
                                                Password = UtilitarianUTL.EncriptarCadena(password)
                                            },
                                            commandType: CommandType.StoredProcedure
                                            );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rs;
        }
    }
}
