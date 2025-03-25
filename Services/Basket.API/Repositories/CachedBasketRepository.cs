﻿using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories;

public class CachedBasketRepository : IBasketRepository
{
    private readonly IBasketRepository _repository;
    private readonly IDistributedCache _cache;

    public CachedBasketRepository(IBasketRepository repository, IDistributedCache cache)
    {
        _repository = repository;
        _cache = cache;
    }
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var cachedBasket = await _cache.GetStringAsync(userName, cancellationToken);

        if (!string.IsNullOrEmpty(cachedBasket))
            JsonSerializer.Deserialize<ShoppingCart>(cachedBasket);

        var basket = await _repository.GetBasket(userName, cancellationToken);
        await _cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
        
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        await _repository.StoreBasket(basket, cancellationToken);

        await _cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteBasket(userName, cancellationToken);

        await _cache.RemoveAsync(userName, cancellationToken);

        return true;
    }
}
