using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    public partial class Pessoa : IValidity
    {
        public int Id { get; set; }

        public bool IsValid()
        {
            return Id != 0;
        }
    }

    public interface IValidity
    {
        bool IsValid();
    }
}
