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
    public class ProductBatcher : IBatchProducts
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<WarehouseBatchContent> _warehouseBatchContentRepo;
        private readonly IGenericRepository<WarehouseBatch> _warehouseBatchRepo;
        private readonly IGenericRepository<Location> _locationRepo;
      

        public ProductBatcher(IGenericRepository<WarehouseBatchContent> warehouseBatchContentRepo, IUnitOfWork uow, IGenericRepository<WarehouseBatch> warehouseBatch, IGenericRepository<Location> locationRepo)
        {
            _warehouseBatchContentRepo = warehouseBatchContentRepo;
            _uow = uow;
            _warehouseBatchRepo = warehouseBatch;
            _locationRepo = locationRepo;
            
        }
        public void BatchMover(ProductBatcherDto dto)
        {

            var oldBatch = _warehouseBatchRepo.GetById(dto.OldBatchId);
            var warehousebatchcontent = _warehouseBatchContentRepo.Get(x => x.WarehouseBatchId == dto.OldBatchId).ToList();
            var warehousebatchconten = _warehouseBatchContentRepo.Get(x => x.WarehouseBatchId == dto.NewBatchId).ToList();
            var newBatch = _warehouseBatchRepo.GetById(dto.NewBatchId);
            /*var locationNewBatch = _locationRepo.GetById(dto.Location);
             
             
             dot include */

           

            if (dto.NewBatchId == 0)
            {
                var locationNewBatch = _locationRepo.GetById(dto.LocationId);
                newBatch = locationNewBatch.AddNewBatch();
            }

            oldBatch.MoveFromBatch(newBatch, dto.Quantity, dto.ManufactoringLotId);

            _uow.Save();
            
        }
    }
}
