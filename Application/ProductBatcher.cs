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

namespace Application
{
    public class ProductBatcher : IBatchProducts
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<WarehouseBatchContent> _warehouseBatchContentRepo;
        private readonly IGenericRepository<WarehouseBatch> _warehouseBatchRepo;




        public ProductBatcher(IGenericRepository<WarehouseBatchContent> warehouseBatchContentRepo, IUnitOfWork uow, IGenericRepository<WarehouseBatch> warehouseBatch)
        {
            _warehouseBatchContentRepo = warehouseBatchContentRepo;
            _uow = uow;
            _warehouseBatchRepo = warehouseBatch;
        }



        /*creating a method which takes all the parameters and is called in the program.cs file*/
        public void BatchMover(ProductBatcherDto dto)
        {
            var oldBatch = _warehouseBatchRepo.GetById(dto.OldBatchId);
            var quant = oldBatch.WarehouseBatchContents.Quantity;


            
            if (oldBatch == null)
            {
                throw new Exception("No batch matching the input");
            }
            
            /* couldnt get the productid from the products table in this get request ------ Use WarehhouseBatchContent or VAR? ------- question mark to accept nullable?*/
            /*int numberOfRows = _warehouseBatchContentRepo.Get(x => x.WarehouseBatch == dto.WarehouseBatch).ToList().Count;*/

            oldBatch.MoveFromBatch(dto.NewBatchId, dto.Quantity, dto.ManufactoringLot);
            /*_warehouseBatchContentRepo.Delete(x);
            _warehouseBatchContentRepo.Delete(y);*/
            /*do i have to get another repo for warehouseBatch to alter that entity?*/
            _uow.Save();
           
                        
           
            
        }
    }
}
