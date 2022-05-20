using System;
using System.Collections.Generic;
using System.Text;

namespace UIProject.classes
{
    public class Sessao
    {
        public enum Cargo
        {
            DeputadoEstadual,
            DeputadoFederal,
            Governador,
            Senador,
            Presidente
        }

        public Sessao(Cargo tipoCargo)
        {
            TipoCargo = tipoCargo;
        }

        public Cargo TipoCargo { get; private set; }

        public string NumeroCandidato { get; set; }

        public bool EBranco { get; set; }
    }
}
