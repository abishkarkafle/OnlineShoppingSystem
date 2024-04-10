using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public PaymentRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<Payment> GetPayment(int id)
        {
            return await _context.Payment.FindAsync(id);
        }

        public async Task PutPayment(int id, Payment Payment)
        {
            if (id != Payment.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(Payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Payment> PostPayment(Payment Payment)
        {
            _context.Payment.Add(Payment);
            await _context.SaveChangesAsync();
            return Payment;
        }

        public async Task DeletePayment(int id)
        {
            var Payment = await _context.Payment.FindAsync(id);
            _context.Payment.Remove(Payment);
            await _context.SaveChangesAsync();
        }

        public bool PaymentExists(int id) // Implemented method
        {
            return _context.Payment.Any(e => e.Id == id);
        }
    }
}
