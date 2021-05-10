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
    public class PaymentPlanRepository : IPaymentPlanRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentCommandText _paymentCommandText;
        private readonly string _connectionString;

        public PaymentPlanRepository(IConfiguration configuracion, IPaymentCommandText paymentCommandText)
        {
            _paymentCommandText = paymentCommandText;
            _configuration = configuracion;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Basic

        public async Task<int> AddAsync(PaymentPlanEntity paymentPlanEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(paymentPlanEntity);
                dynamicParameters.Add("PaymentPlanId", DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _paymentCommandText.AddPaymentPlan,
                                            dynamicParameters,
                                            commandType: CommandType.StoredProcedure
                                            );
                    paymentPlanEntity.PaymentPlanId = dynamicParameters.Get<int>("PaymentPlanId");
                }
            }
            catch (Exception exception)
            {

            }

            return indicator;
        }

        public async Task<int> UpdateAsync(PaymentPlanEntity paymentPlanEntity)
        {
            int indicator = -1;

            try
            {
                var dynamicParameters = new DynamicParameters(paymentPlanEntity);

                using (var connection = new SqlConnection(_connectionString))
                {
                    indicator = await connection.ExecuteAsync(
                                            _paymentCommandText.UpdatePaymentPlan,
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

        public async Task<PaymentPlanEntity> GetByIdAsync(int paymentPlanId)
        {
            var rs = new PaymentPlanEntity();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    rs = await connection.QueryFirstOrDefaultAsync<PaymentPlanEntity>(
                                        _paymentCommandText.GetPaymentPlanById,
                                        new { PaymentPlanId = paymentPlanId },
                                        commandType: CommandType.StoredProcedure
                                        );
                }
            }
            catch (Exception exception)
            {

            }

            return rs;
        }

        public async Task<List<PaymentPlanEntity>> GetAllAsync()
        {
            var ls = new List<PaymentPlanEntity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var rs = await connection.QueryAsync<PaymentPlanEntity>(
                                        _paymentCommandText.GetAllPaymentPlan,
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
