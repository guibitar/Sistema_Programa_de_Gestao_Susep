using Microsoft.EntityFrameworkCore;
using Susep.SISRH.Domain.AggregatesModel.PlanoTrabalhoAggregate;
using Susep.SISRH.Infrastructure.Contexts;
using SUSEP.Framework.Data.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susep.SISRH.Infrastructure.Repositories
{
    public class PlanoTrabalhoSRepository : SqlServerRepository<PlanoTrabalho>, IPlanoTrabalhoSRepository
    {
        private readonly SISRHDbContext _context;

        public PlanoTrabalhoSRepository(SISRHDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PlanoTrabalho> ObterAsync(Guid id)
        {
            return await Entity
                .FirstOrDefaultAsync(p => p.PlanoTrabalhoId == id);
        }

        public async Task<PlanoTrabalho> AdicionarAsync(PlanoTrabalho item)
        {
            var result = await Entity.AddAsync(item);
            return result.Entity;
        }

        public void Atualizar(PlanoTrabalho item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Excluir(PlanoTrabalho item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }
    }
}
