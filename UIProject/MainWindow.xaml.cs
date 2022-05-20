using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using UIProject.classes;

namespace UIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Queue<Sessao.Cargo> _filaCargos = new Queue<Sessao.Cargo>();
        private readonly List<Sessao> _lstSessao = new List<Sessao>();

        private Sessao _sessaoAtual;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            NovaSessao();
        }

        private void NovaSessao()
        {
            _lstSessao.Clear();
            _filaCargos.Clear();
            _filaCargos.Enqueue(Sessao.Cargo.DeputadoEstadual);
            _filaCargos.Enqueue(Sessao.Cargo.DeputadoFederal);
            _filaCargos.Enqueue(Sessao.Cargo.Governador);
            _filaCargos.Enqueue(Sessao.Cargo.Senador);
            _filaCargos.Enqueue(Sessao.Cargo.Presidente);
            _sessaoAtual = new Sessao(_filaCargos.Dequeue());
            Limpar();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            ButtonManager(button);
        }
        private void ButtonManager(Button button)
        {
            if (button == btn0)
            {                
                InputFormat("0");
                return;
            }
            if (button == btn1)
            {
                InputFormat("1");
                return;
            }
            if (button == btn2)
            {
                InputFormat("2");
                return;
            }
            if (button == btn3)
            {
                InputFormat("3");
                return;
            }
            if (button == btn4)
            {
                InputFormat("4");
                return;
            }
            if (button == btn5)
            {
                InputFormat("5");
                return;
            }
            if (button == btn6)
            {
                InputFormat("6");
                return;
            }
            if (button == btn7)
            {
                InputFormat("7");
                return;
            }
            if (button == btn8)
            {
                InputFormat("8");
                return;
            }
            if (button == btn9)
            {
                InputFormat("9");
                return;
            }
            if (button == btnBranco)
            {
                Branco();
                return;
            }
            if (button == btnCorrige)
            {
                Limpar();
                return;
            }
            if (button == btnConfirma)
            {
                Confirmar();
                return;
            }
        }
        private void InputFormat(string value)
        {
            _sessaoAtual.NumeroCandidato = string.Format("{0}{1}", _sessaoAtual.NumeroCandidato == null ? "" : _sessaoAtual.NumeroCandidato, value);
            lblCandidateNumber.Content = _sessaoAtual.NumeroCandidato;
        }
        private void Branco()
        {
            _sessaoAtual.EBranco = true;
            if (FinalizaSessao())
            {
                CommitSessao();
                NovaSessao();
            }
        }
        private void Limpar()
        {
            _sessaoAtual.NumeroCandidato = string.Empty;
            InputFormat("");
        }

        private bool FinalizaSessao()
        {
            _lstSessao.Add(_sessaoAtual);
            _sessaoAtual = null;
            if (_filaCargos.Any())
            {
                _sessaoAtual = new Sessao(_filaCargos.Dequeue());
                Limpar();
                return false;
            }
            return true;
        }

        private void Confirmar()
        {
            if(FinalizaSessao())
            {
                CommitSessao();
                NovaSessao();
            }
        }

        private void CommitSessao()
        {
            StringBuilder sb = new StringBuilder();
            _lstSessao.ForEach(c =>
            {
                switch (c.TipoCargo)
                {
                    case Sessao.Cargo.DeputadoEstadual:
                        sb.Append(string.Format("Deputado Estadual:{0}{1}{2}", c.NumeroCandidato, Environment.NewLine, Environment.NewLine));
                        break;
                    case Sessao.Cargo.DeputadoFederal:
                        sb.Append(string.Format("Deputado Federal:{0}{1}{2}", c.NumeroCandidato, Environment.NewLine, Environment.NewLine));
                        break;
                    case Sessao.Cargo.Governador:
                        sb.Append(string.Format("Governador:{0}{1}{2}", c.NumeroCandidato, Environment.NewLine, Environment.NewLine));
                        break;
                    case Sessao.Cargo.Senador:
                        sb.Append(string.Format("Senador:{0}{1}{2}", c.NumeroCandidato, Environment.NewLine, Environment.NewLine));
                        break;
                    case Sessao.Cargo.Presidente:
                        sb.Append(string.Format("Presidente:{0}{1}{2}", c.NumeroCandidato, Environment.NewLine, Environment.NewLine));
                        break;
                }

            });

            MessageBox.Show(sb.ToString());
        }
    }
}
