using System;

namespace Aula04
{
    public enum Situacao
    {
        Ativo,
        Inativo,
        Afastado       
    }

    public class Farmaceutico
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime? DataAdmissao { get; private set; }
        public DateTime? DataInativacao { get; private set; }
        public Situacao Situacao { get; private set; }

        public Farmaceutico(Guid id, string nome)
        {
            Id = id;
            Nome = nome;

            
        }

        public void Contratar(DateTime dataAdmissao)
        {
            if (DataAdmissao.HasValue)
            {
                throw new ArgumentException("Farmaceutico já possui DataAdmissao.", nameof(DataAdmissao));
            }

            DataAdmissao = dataAdmissao;

            Situacao = Situacao.Ativo;
        }

        public void Inativar(DateTime dataInativacao)
        {
            if(DataInativacao.HasValue) throw new ArgumentException("Farmaceutico já possui DataInativacao", "DataInativacao");

            if (DataAdmissao >= dataInativacao) throw new ArgumentException("Data de Inativação não pode ser anterior à data de admissão.", "DataInativacao");

            DataInativacao = dataInativacao;

            Situacao = Situacao.Inativo;
        }
        
        public void Afastar(DateTime dataInativacao)
        {
            if (Situacao == Situacao.Afastado && DataInativacao.HasValue) throw new ArgumentException("Farmaceutico já afastado", "DataInativacao");

            if (Situacao == Situacao.Inativo) throw new ArgumentException("Farmaceutico inativado não pode ser afastado", "DataInativacao");

            if (DataAdmissao >= dataInativacao) throw new ArgumentException("Data de Inativação não pode ser anterior à data de admissão.", "DataInativacao");

            DataInativacao = dataInativacao;

            Situacao = Situacao.Afastado;
        }

        public void Retorno()
        {
            if (Situacao == Situacao.Inativo) throw new ArgumentException("Farmaceutico inativo não pode ter retorno", "DataInativacao");
            
            DataInativacao = default;
            
            Situacao = Situacao.Ativo;
        }
    }
}
