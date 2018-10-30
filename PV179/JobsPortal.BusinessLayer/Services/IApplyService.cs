using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobsPortal.BusinessLayer.DataTransferObjects;

namespace JobsPortal.BusinessLayer.Services
{
    public interface IApplyService
    {
        /// <summary>
        /// Persists order together with all related data
        /// </summary>
        /// <param name="createOrderDto">wrapper for order, orderItems, customer and coupon</param>
        Task<Guid> ConfirmApplicationAsync(ApplicationDto applicationDto);


        /*
        /// <summary>
        /// Calculates total price for all order items (overall coupon discount is included)
        /// </summary>
        /// <param name="orderItems">all order items</param>
        /// <returns>Total price for given items</returns>
        decimal CalculateTotalPrice(ICollection<OrderItemDto> orderItems);*/
    }
}