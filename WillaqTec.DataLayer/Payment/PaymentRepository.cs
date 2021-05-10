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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentCommandText _paymentCommandText;
        private readonly string _connectionString;

        public PaymentRepository(IConfiguration configuracion, IPaymentCommandText paymentCommandText)
        {
            _paymentCommandText = paymentCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(PaymentEntity paymentEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(paymentEntity);
                dynamicParameters.Add("PaymentId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _paymentCommandText.AddPayment,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    paymentEntity.PaymentId = dynamicParameters.Get<int>("PaymentId");
                }
            }
            catch (Exception exception)
            {

            }

            return indicator;
        }

        public async Task<int> UpdateAsync(PaymentEntity paymentEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(paymentEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _paymentCommandText.UpdatePayment,
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

        public async Task<PaymentEntity> GetByIdAsync(int paymentId)
        {
            var rs = new PaymentEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<PaymentEntity>(
                                        _paymentCommandText.GetPaymentById,
                                        new { PaymentId = paymentId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<PaymentEntity>> GetAllAsync()
        {
            var ls = new List<PaymentEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<PaymentEntity>(
                                        _paymentCommandText.GetAllPayment,
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
