using InvestCarWeb.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InvestCarWeb.Extentions.ViewComponents.Helpers
{
    public static class Util
    {
        //public static int TotReg(IdentyDbContext ctx)
        //{
        //    return (from pac in ctx.Paciente.AsNoTracking() select pac).Count();
        //}

        //public static decimal GetNumRegEstado(IdentyDbContext ctx, string estado)
        //{
        //    return ctx.Paciente
        //        .Include(x => x.EstadoPaciente)
        //        .AsNoTracking()
        //        .Count(x => x.EstadoPaciente.Descricao.Contains(estado));
        //}

    }
}
