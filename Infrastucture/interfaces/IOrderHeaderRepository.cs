using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.interfaces
{
	public interface IOrderHeaderRepository<T> : IGenericRepository<OrderHeader>
	{
		void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
		void UpdateStripePaymentID(int id, string sessionId, string InvoiceId);
	}
}
