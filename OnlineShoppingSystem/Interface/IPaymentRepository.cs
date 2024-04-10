using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments();
        Task<Payment> GetPayment(int id);
        Task PutPayment(int id, Payment payment);
        Task<Payment> PostPayment(Payment payment);
        Task DeletePayment(int id);
        bool PaymentExists(int id);

    }
}
