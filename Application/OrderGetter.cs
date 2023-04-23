/* using Microsoft.EntityFrameworkCore.Storage;
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
    public class OrderGetter : IGetOrders
    {
        private readonly IUnitOfWork _uow;

        private readonly IGenericRepository<OrderProduct> _orderProductRepo;

        public OrderGetter(IUnitOfWork uow, IGenericRepository<OrderProduct> orderProductRepo)
        {
            _uow = uow;

            _orderProductRepo = orderProductRepo;
        }
        public void GetOrders(int orderId)
        {

            var OrderProducts =  _orderProductsRepo.Get(x=> x.OrderId).ToList();
            foreach (var x in OrderProducts)
            {
                
                RetrieveFromWarehouse(dto);
            }

            _uow.Save();


        }
    }
}
*/