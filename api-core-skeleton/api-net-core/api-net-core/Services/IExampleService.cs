using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiNetCore.Services
{
    public interface IExampleService
    {
        Task<int> CalculateTotalAsync(int x, int y);
    }
}
