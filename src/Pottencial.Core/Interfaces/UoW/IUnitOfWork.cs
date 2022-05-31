using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Core.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<bool> Comitar();
    }
}
