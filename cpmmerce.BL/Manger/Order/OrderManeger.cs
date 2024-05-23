﻿using commerce.BL.Dtos.Order;
using commerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using commerce.BL.Dtos.Product;

namespace commerce.BL.Manger.Order
{
    public class OrderManeger : IOrderManeger
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderManeger(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddNewOrder(List<AddOrderDto> newOrder, string UserId)
        {
            List<(int ProductId, int Quantity)> orderItems = newOrder
           .Select(dto => (dto.ProductId, dto.Quantity))
             .ToList();
            _unitOfWork.orderRepository.AddNewOrder(orderItems, UserId);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<GetOrderHistoryDto> GetAllOrder(string userId)
        {
            var orders = _unitOfWork.orderRepository.GetAllOrder(userId);
            if (orders is null) return null;
            return orders.Select(p => new GetOrderHistoryDto
            {
                Id = p.Id,
                CeartionDateTime = p.CeartionDateTime,
                TotalPrice = p.TotalPrice,


            });
        }
    }
}
