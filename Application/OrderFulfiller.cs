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
    public class OrderFulfiller 
    {
        private readonly IUnitOfWork _uow;

        private readonly IGenericRepository<WarehouseBatchContent> _warehouseBatchContentRepo;

        public OrderFulfiller(IUnitOfWork uow, IGenericRepository<WarehouseBatchContent> warehouseBatchContentRepo)
        {
            _uow = uow;
            _warehouseBatchContentRepo = warehouseBatchContentRepo;
            
        }
        public void RetrieveFromWarehouse(int productId)
        {
            var result = _warehouseBatchContentRepo.Get(x => x.ManufactoringLotNavigation.ProductId == productId)
                .Select(x => new
                {
                    Location = x.WarehouseBatchNavigation.LocationNavigation,
                    WarehouseBatch = x.WarehouseBatchNavigation
                })
                .ToList()
                .Select(a => a.Location);
        }
    }
}
