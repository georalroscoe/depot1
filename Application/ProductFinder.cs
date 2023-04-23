using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;
using DataAccess.Mapping;
using DataAccess.Repositories;
using Microsoft.Identity.Client;
using System.Diagnostics;
using Application.Interfaces;
using Dtos;
using System.Xml;

namespace Application
{
    public class ProductFinder : IFindProducts
    {
        private readonly IUnitOfWork _uow;

        private readonly IGenericRepository<WarehouseBatchContent> _warehouseBatchContentRepo;

        private readonly IGenericRepository<OrderProduct> _orderProductRepo;


        public ProductFinder(IUnitOfWork uow, IGenericRepository<WarehouseBatchContent> warehouseBatchContentRepo, IGenericRepository<OrderProduct> orderProductRepo)
        {
            _uow = uow;
            _warehouseBatchContentRepo = warehouseBatchContentRepo;
            _orderProductRepo= orderProductRepo;
        }
        public OrderLocationDto GetOrderDetails(int orderId)
        {
            var orderLocationDto = new OrderLocationDto();
            orderLocationDto.OrderId = orderId;
            var orders = _orderProductRepo.Get(x => x.OrderId == orderId).ToList();
            foreach (var order in orders)
            {
                orderLocationDto.Products.Add(FindProducts(order.ProductId, order.Quantity));

            }
            return orderLocationDto;
        }
        public ProductLocationDto FindProducts(int productId, int quantity)
        { 
        
         var productLocationDto = new ProductLocationDto(

             );
            productLocationDto.ProductId = productId;

            var result = _warehouseBatchContentRepo.Get(x => x.ManufactoringLotNavigation.Product.ProductId == productId)
                .Select(x => new
                {
                    Location = x.WarehouseBatchNavigation.LocationNavigation.LocationId,
                    WarehouseBatch = x.WarehouseBatchNavigation.WarehouseBatchId,
                    Quantity = x.Quantity
                    
                })
                .ToList().OrderBy(x => x.Quantity);
            int elementIndex = 0;
           
            while (quantity > 0)
            {
                if(result.Count() == elementIndex)
                {
                    return productLocationDto;
                }
                var batchLocationDto = new BatchLocationDto();
                if (quantity < result.ElementAt(elementIndex).Quantity)
                {
                    batchLocationDto.Quantity = quantity;
                    batchLocationDto.Location = result.ElementAt(elementIndex).Location;
                    batchLocationDto.WarehouseBatch = result.ElementAt(elementIndex).Location;
                    quantity = 0;
                }
                else
                {
                    batchLocationDto.Quantity = result.ElementAt(elementIndex).Quantity;
                    batchLocationDto.Location = result.ElementAt(elementIndex).Location;
                    batchLocationDto.WarehouseBatch = result.ElementAt(elementIndex).Location;
                    quantity -= result.ElementAt(elementIndex).Quantity;
                }
                elementIndex++;
                
                productLocationDto.BatchLocations.Add(batchLocationDto);
            }


            return productLocationDto;

            
           

        
        }
    }
}
