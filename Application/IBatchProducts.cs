using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IBatchProducts
    {
        void tran(int wBatch, int mLot, int quant, int loc);
    }
}
