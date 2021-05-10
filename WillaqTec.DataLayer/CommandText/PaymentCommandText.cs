
namespace WillaqTec
{
    public class PaymentCommandText : IPaymentCommandText
    {
        // PaymentPlan

        public string AddPaymentPlan => "Usp_Sec_I_Sec_PaymentPlan";
        public string UpdatePaymentPlan => "Usp_Sec_U_Sec_PaymentPlan";
        public string GetPaymentPlanById => "Usp_Sec_S_Sec_PaymentPlan_Get_By_Id";
        public string GetAllPaymentPlan => "Usp_Sec_S_Sec_PaymentPlan";

        // Payment

        public string AddPayment => "Usp_Sec_I_Sec_Payment";
        public string UpdatePayment => "Usp_Sec_U_Sec_Payment";
        public string GetPaymentById => "Usp_Sec_S_Sec_Payment_Get_By_Id";
        public string GetAllPayment => "Usp_Sec_S_Sec_Payment";

        // PaymentOperation

        public string AddPaymentOperation => "Usp_Sec_I_Sec_PaymentOperation";
        public string UpdatePaymentOperation => "Usp_Sec_U_Sec_PaymentOperation";
        public string GetPaymentOperationById => "Usp_Sec_S_Sec_PaymentOperation_Get_By_Id";
        public string GetAllPaymentOperation => "Usp_Sec_S_Sec_PaymentOperation";

    }
}
