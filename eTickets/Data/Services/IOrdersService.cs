﻿using eTickets.Models;

namespace eTickets.Data.Services;

public interface IOrdersService
{
    Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string emailAddress);
    Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole); 
}
