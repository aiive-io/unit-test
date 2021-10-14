namespace Aula06
{
    public enum Ambiente
    {
        Teste,
        Homologacao,
        Producao
    }

    public class Logger
    {
        private readonly Ambiente _ambiente;

        public Logger(Ambiente ambiente)
        {
            _ambiente = ambiente;
        }

        public void Log(string text)
        {
            if (_ambiente != Ambiente.Producao) return;
        }
    }
}
