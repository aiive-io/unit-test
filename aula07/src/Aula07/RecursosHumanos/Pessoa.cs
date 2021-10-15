using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    public partial class Pessoa : IEmployee
    {
        public DateTime? DataSaida { get; set; }
        public DateTime DataRegistro { get; set; }

        public bool IsEmployee()
        {
            return DataSaida.HasValue && DataSaida.Value >= DataRegistro;
        }
    }

    public interface IEmployee
    {
        bool IsEmployee();
    }
}
