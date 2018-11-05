using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Services
{
    public interface IExampleService
    {
        Task<int> CalculateTotal(int x, int y);
    }
}
