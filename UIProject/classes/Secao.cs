using System;
using System.Collections.Generic;
using System.Text;

namespace UIProject.classes
{
    public class Secao
    {
        public static int IdSecao { get; private set; }

        public enum Cargo
        {
            DeputadoEstadual,
            DeputadoFederal,
            Governador,
            Senador,
            Presidente
        }

        public Secao(Cargo tipoCargo)
        {
            TipoCargo = tipoCargo;
            IdSecao++;
        }

        public Cargo TipoCargo { get; private set; }

        public string NumeroCandidato { get; private set; }

        public bool ENulo { get; private set; }

        public void InserirDigito(string numeroCandidato)
        {
            NumeroCandidato = string.Format("{0}{1}", NumeroCandidato == null ? "" : NumeroCandidato, numeroCandidato);
        }
        public void LimparSecao()
        {
            ENulo = false;
            NumeroCandidato = string.Empty;
        }
        public void AnularSecao()
        {
            ENulo = true;
            NumeroCandidato = string.Empty;
        }
    }
}
