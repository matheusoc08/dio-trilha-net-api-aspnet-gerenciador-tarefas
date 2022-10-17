using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_trilha_net_api_aspnet_gerenciador_tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}