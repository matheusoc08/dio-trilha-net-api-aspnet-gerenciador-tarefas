using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_trilha_net_api_aspnet_gerenciador_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace dio_trilha_net_api_aspnet_gerenciador_tarefas.Context
{
    public class OrganizadorContext : DbContext
    {

        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options) { }
        public DbSet<Tarefa> Tarefas { get; set; }

    }

}