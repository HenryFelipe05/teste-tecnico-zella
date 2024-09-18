using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Application.Commands
{
	public class NovaTarefaCommand
	{
        public int CodigoUsuario { get; set; }
        public string? NomeTarefa { get; set; }
        public string? DescricaoTarefa { get; set; }
        public int CodigoStatusTarefa { get; set; }
    }
}
