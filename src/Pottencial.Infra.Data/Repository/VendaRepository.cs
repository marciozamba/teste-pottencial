using AutoMapper;
using Pottencial.Core.Domains;
using Pottencial.Core.Interfaces.Repositories;
using Pottencial.Infra.Data.Context;
using Pottencial.Infra.Data.Entities;
using Pottencial.Infra.Data.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Pottencial.Infra.Data.Repository
{
    public class VendaRepository : BaseRepository<Venda, TabelaVenda>, IVendaRepository
    {
        public VendaRepository(DefaultContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
