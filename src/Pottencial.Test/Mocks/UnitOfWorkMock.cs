using Pottencial.Core.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Test.Mocks
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        public Task<bool> Comitar()
        {
            return Task.FromResult(true);
        }
    }
}
