using System;
using System.Collections.Generic;
using System.Text;

namespace UIProject.interfaces
{
    public interface IEntrada : IDisposable
    {
        public void Ler(string strValor);
    }
    public interface ISaida : IDisposable
    {
        public void Escrever(string strValor);
        public void EscreverLinha(string strValor);
    }
}
