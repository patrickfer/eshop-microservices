using Discount.Grpc.Models;

namespace Discount.Grpc.Repositories.Interfaces;

public interface IDiscountRepository
{
    Task<Coupon> GetCoupon(string productName);
    Task<Coupon> CreateCoupon(Coupon coupon, CancellationToken cancellationToken = default);
    Task<bool> UpdateCoupon(Coupon coupon, CancellationToken cancellationToken = default);
    Task<bool> DeleteCoupon(Coupon coupon, CancellationToken cancellationToken = default);
}
