﻿using Microsoft.EntityFrameworkCore.Storage;
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
using Microsoft.EntityFrameworkCore;

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
            _orderProductRepo = orderProductRepo;
           
        }
        public OrderLocationDto GetOrderDetails1(int orderId)
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

        public OrderLocationDto GetOrderDetails(int orderId)
        {
            var orderLocationDto = new OrderLocationDto();
            orderLocationDto.OrderId = orderId;

            var order = _orderProductRepo.Get(x => x.OrderId == orderId)
                .Select(x => new
                {
                    Order = x.CustomerOrder,
                    OrderProduct = x,
                    Product = x.Product,
                    ManLot = x.Product.ManufactoringLots,
                    BatchContents = x.Product.ManufactoringLots.SelectMany(y => y.WarehouseBatchContents),
                    Batches = x.Product.ManufactoringLots.SelectMany(y => y.WarehouseBatchContents).Select(z => z.WarehouseBatchNavigation),
                    Locations = x.Product.ManufactoringLots.SelectMany(y => y.WarehouseBatchContents).Select(z => z.WarehouseBatchNavigation.LocationNavigation)

                }).ToList().GroupBy(x => x.Order).Select(x => x.Key).Single();
              
            /* could create extra domain which is like the dto, could create locations domain object in the orderporducts domain, 

            order.GetLocations();


            return orderLocationDto;
        }

        public ProductLocationDto FindProducts(int productId, int quantity)
        { 
        
         var productLocationDto = new ProductLocationDto(

             );
            productLocationDto.ProductId = productId;
            productLocationDto.TotalQuantityRequired = quantity;
            productLocationDto.QuantityReached = true;

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
                    productLocationDto.QuantityReached = false;
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