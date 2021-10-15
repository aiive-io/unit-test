using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    public partial class Pessoa : IPessoa
    {

    }

    public interface IPessoa : IValidity, IEmployee
    {

    }
}
