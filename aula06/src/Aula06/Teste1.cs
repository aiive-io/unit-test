using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula06
{
    public interface IAdd
    {
        int Add(int a, int b);
    }

    public partial class Teste1: IAdd
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    public partial class Teste1 : ISub
    {
        public int Sub(int a, int b)
        {
            return a - b;
        }
    }

    public interface ITeste1 : IAdd, ISub
    {

    }

    public interface ISub
    {
        int Sub(int a, int b);
    }

    public class TesteService
    {
        private readonly ITeste1 _teste1;

        public TesteService(ITeste1 teste1)
        {
            _teste1 = teste1;
        }

        public void Metodo()
        {
            //Add
            //Sub
        }

        //metodo1
        //metodo2
    }
}
