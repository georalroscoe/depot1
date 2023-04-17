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

       

        public ProductBatcher(IGenericRepository<WarehouseBatchContent> warehouseBatchContentRepo, IUnitOfWork uow)
        {
            _warehouseBatchContentRepo = warehouseBatchContentRepo;
            _uow = uow;
        }



        /*creating a method which takes all the parameters and is called in the program.cs file*/
        public void BatchMover(ProductBatcherDto dto)
        {
            WarehouseBatchContent? originalBatchInstance = _warehouseBatchContentRepo.Get(x => x.ManufactoringLot == dto.ManufactoringLot && x.Id == dto.WarehouseBatch).SingleOrDefault();
            if (originalBatchInstance == null)
            {
                throw new Exception("No batch matching the input");
            }
            
            /* couldnt get the productid from the products table in this get request ------ Use WarehhouseBatchContent or VAR? ------- question mark to accept nullable?*/
            int numberOfRows = _warehouseBatchContentRepo.Get(x => x.WarehouseBatch == dto.WarehouseBatch).ToList().Count;

            originalBatchInstance.MoveFromBatch(dto.Location, dto.Quantity, numberOfRows);
            /*_warehouseBatchContentRepo.Delete(x);
            _warehouseBatchContentRepo.Delete(y);*/
            /*do i have to get another repo for warehouseBatch to alter that entity?*/
            _uow.Save();
           
                        
           
            
        }
    }
}
