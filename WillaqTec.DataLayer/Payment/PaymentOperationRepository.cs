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
    public class PaymentOperationRepository : IPaymentOperationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentCommandText _paymentCommandText;
        private readonly string _connectionString;

        public PaymentOperationRepository(IConfiguration configuracion, IPaymentCommandText paymentCommandText)
        {
            _paymentCommandText = paymentCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(PaymentOperationEntity paymentOperationEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(paymentOperationEntity);
                dynamicParameters.Add("PaymentOperationId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _paymentCommandText.AddPaymentOperation,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    paymentOperationEntity.PaymentOperationId = dynamicParameters.Get<int>("PaymentOperationId");
                }
            }
            catch (Exception exception)
            {

            }

            return indicator;
        }

        public async Task<int> UpdateAsync(PaymentOperationEntity paymentOperationEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(paymentOperationEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _paymentCommandText.UpdatePaymentOperation,
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

        public async Task<PaymentOperationEntity> GetByIdAsync(int paymentOperationId)
        {
            var rs = new PaymentOperationEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<PaymentOperationEntity>(
                                        _paymentCommandText.GetPaymentOperationById,
                                        new { PaymentOperationId = paymentOperationId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<PaymentOperationEntity>> GetAllAsync()
        {
            var ls = new List<PaymentOperationEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<PaymentOperationEntity>(
                                        _paymentCommandText.GetAllPaymentOperation,
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
