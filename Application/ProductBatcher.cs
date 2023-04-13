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
        public void tran(int wBatch, int mLot, int quant, int loc)
        {
            var originalBatch = _warehouseBatchContentRepo.Get(x => x.ManufactoringLot == mLot && x.Id == wBatch).SingleOrDefault();
           
            /* couldnt get the productid from the products table in this get request*/
            int noRows = _warehouseBatchContentRepo.Get(x => x.WarehouseBatch == wBatch).ToList().Count();
            Console.WriteLine(originalBatch.ManufactoringLot);
            WarehouseBatchContent.MoveFromBatch(originalBatch, loc, quant, noRows);
            _uow.Save();
                        
           
            
        }
    }
}
