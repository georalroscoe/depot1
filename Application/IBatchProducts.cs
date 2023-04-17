using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Dtos;

namespace Application.Interfaces
{
    public interface IBatchProducts
    {
        void BatchMover(ProductBatcherDto dto);
    }
}
