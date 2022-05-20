using System;
using System.Collections.Generic;
using System.Linq;

namespace UIProject.classes
{
    public class Votacao
    {
        public string NumeroCandidatoAtual { get { return _secaoAtual.NumeroCandidato; } }

        private static int _idVotacao = 0;
        private readonly Queue<Secao.Cargo> _filaCargos = new Queue<Secao.Cargo>();
        private readonly List<Secao> _listSecoes = new List<Secao>();
        private Secao _secaoAtual;


        public Votacao()
        {
            _listSecoes.Clear();
            _filaCargos.Clear();
            _filaCargos.Enqueue(Secao.Cargo.DeputadoEstadual);
            _filaCargos.Enqueue(Secao.Cargo.DeputadoFederal);
            _filaCargos.Enqueue(Secao.Cargo.Governador);
            _filaCargos.Enqueue(Secao.Cargo.Senador);
            _filaCargos.Enqueue(Secao.Cargo.Presidente);
            _secaoAtual = new Secao(_filaCargos.Dequeue());
        }

        public void InserirDigito(string numeroCandidato)
        {
            _secaoAtual.InserirDigito(numeroCandidato);
        }

        public void LimparVotacao()
        {
            _secaoAtual.LimparSecao();
        }

        public void AnularVotacao()
        {
            _secaoAtual.AnularSecao();
        }

        public void ConfirmaVotacao()
        {
            var strPath = string.Format("{0}dados", "C:\\");
            //var strPath = string.Format("{0}dados", AppDomain.CurrentDomain.BaseDirectory);
            var strFileName = string.Format("\\Votação{0}.txt", _idVotacao++);
            
            using (var fluxoSaida = GerenciadorEntradaSaidas.ConstruirFluxoDeSaida(strPath, strFileName))
            {
                foreach (var secao in _listSecoes)
                {
                    switch (secao.TipoCargo)
                    {
                        case Secao.Cargo.DeputadoEstadual:
                            fluxoSaida.EscreverLinha(string.Format("Deputado Estadual: {0}", secao.ENulo ? "Nulo" : secao.NumeroCandidato));
                            break;
                        case Secao.Cargo.DeputadoFederal:
                            fluxoSaida.EscreverLinha(string.Format("Deputado Federal: {0}", secao.ENulo ? "Nulo" : secao.NumeroCandidato));
                            break;
                        case Secao.Cargo.Governador:
                            fluxoSaida.EscreverLinha(string.Format("Governador: {0}", secao.ENulo ? "Nulo" : secao.NumeroCandidato));
                            break;
                        case Secao.Cargo.Senador:
                            fluxoSaida.EscreverLinha(string.Format("Senador: {0}", secao.ENulo ? "Nulo" : secao.NumeroCandidato));
                            break;
                        case Secao.Cargo.Presidente:
                            fluxoSaida.EscreverLinha(string.Format("Presidente: {0}", secao.ENulo ? "Nulo" : secao.NumeroCandidato));
                            break;
                    }
                }
            }
        }

        public bool VotacaoFinalizada()
        {
            _listSecoes.Add(_secaoAtual);
            _secaoAtual = null;
            if (_filaCargos.Any())
            {
                _secaoAtual = new Secao(_filaCargos.Dequeue());
                _secaoAtual.LimparSecao();
                return false;
            }
            return true;
        }
    }
}
