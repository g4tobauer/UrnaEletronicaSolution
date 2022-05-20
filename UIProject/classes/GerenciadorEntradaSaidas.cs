using System;
using System.IO;
using System.Text;
using UIProject.interfaces;

namespace UIProject.classes
{
    public class GerenciadorEntradaSaidas : IEntrada, ISaida
    {
        public enum Tipo
        {
            Entrada,
            Saida
        }

        private static GerenciadorEntradaSaidas _instance;
        private StreamReader _sr;
        private StreamWriter _sw;
        private Tipo _tipo;

        private GerenciadorEntradaSaidas(Tipo tipo, string path, string fileName)
        {
            _tipo = tipo;
            switch (_tipo)
            {
                case Tipo.Entrada:
                    if (Directory.Exists(path))
                        _sr = new StreamReader(string.Format("{0}{1}", path, fileName));
                    break;
                case Tipo.Saida:
                    if(!Directory.Exists(path)) 
                        Directory.CreateDirectory(path);
                    _sw = new StreamWriter(string.Format("{0}{1}", path, fileName), true, Encoding.ASCII);
                    break;
            }
        }

        public static IEntrada ConstruirFluxoDeEntrada(string path, string fileName)
        {
            if (_instance == null) 
                _instance = new GerenciadorEntradaSaidas(Tipo.Entrada, path, fileName);

            if(_instance._tipo == Tipo.Entrada)
                return _instance;
            return null;
        }

        public static ISaida ConstruirFluxoDeSaida(string path, string fileName)
        {
            if (_instance == null)
                _instance = new GerenciadorEntradaSaidas(Tipo.Saida, path, fileName);

            if (_instance._tipo == Tipo.Saida)
                return _instance;
            return null;
        }

        public void Escrever(string teste)
        {
            _sw.Write(teste);
        }
        public void EscreverLinha(string teste)
        {
            _sw.WriteLine(teste);
        }

        public void Ler(string teste)
        {
            var line = _sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = _sr.ReadLine();
            }
        }

        public void Dispose()
        {
            if (_sr != null)
                _sr.Close();
            if (_sw != null)
                _sw.Close();

            _instance = null;
        }
    }
}
