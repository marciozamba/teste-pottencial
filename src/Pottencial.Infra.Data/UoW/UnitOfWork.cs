using Pottencial.Core.Interfaces.UoW;
using Pottencial.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _contexto;

        public UnitOfWork(DefaultContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Comitar()
        {
            using var contextTransaction = _contexto.Database.BeginTransaction();

            try
            {
                int affectedRows = 0;

                affectedRows += await _contexto.SaveChangesAsync();

                contextTransaction.Commit();

                return affectedRows > 0;
            }
            catch (Exception)
            {
                contextTransaction.Rollback();

                throw;
            }
        }
    }
}
