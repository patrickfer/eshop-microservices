using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Discount.Grpc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly DiscountContext _context;

    public DiscountRepository(DiscountContext context)
    {
        _context = context;
    }

    public async Task<Coupon> GetCoupon(string productName)
    {
        var coupon = await _context
           .Coupons
           .FirstOrDefaultAsync(x => x.ProductName == productName);

        return coupon;
    }

    public async Task<Coupon> CreateCoupon(Coupon coupon, CancellationToken cancellationToken = default)
    {
        _context.Coupons.Add(coupon);
        await _context.SaveChangesAsync(cancellationToken);

        return coupon;
    }

    public async Task<bool> UpdateCoupon(Coupon coupon, CancellationToken cancellationToken = default)
    {
        _context.Coupons.Update(coupon);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteCoupon(Coupon coupon, CancellationToken cancellationToken = default)
    {
        _context.Coupons.Remove(coupon);
        await _context.SaveChangesAsync(cancellationToken); 
        
        return true;
    }
}
