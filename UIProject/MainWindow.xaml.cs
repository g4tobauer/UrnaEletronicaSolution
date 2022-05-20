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
        private Votacao _votacaoAtual;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            NovaVotacao();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            GerenciadorDeTeclas(button);
        }

        private void NovaVotacao()
        {
            _votacaoAtual = new Votacao();
            Limpar();
        }
        private void GerenciadorDeTeclas(Button button)
        {
            var strDigito = string.Empty;
            if (button == btnBranco) Anular();
            else
            if (button == btnCorrige) Limpar();
            else
            if (button == btnConfirma) ConfirmarVotacao();
            else
            if (button == btn0) Digitar("0");
            else
            if (button == btn1) Digitar("1");
            else
            if (button == btn2) Digitar("2");
            else
            if (button == btn3) Digitar("3");
            else
            if (button == btn4) Digitar("4");
            else
            if (button == btn5) Digitar("5");
            else
            if (button == btn6) Digitar("6");
            else
            if (button == btn7) Digitar("7");
            else
            if (button == btn8) Digitar("8");
            else
            if (button == btn9) Digitar("9");
        }
        private void AtualizarNumeroCandidato()
        {            
            lblCandidateNumber.Content = _votacaoAtual.NumeroCandidatoAtual;
        }
        private void Digitar(string strDigito)
        {
            _votacaoAtual.InserirDigito(strDigito);
            AtualizarNumeroCandidato();
        }
        private void Limpar()
        {
            _votacaoAtual.LimparVotacao();
            AtualizarNumeroCandidato();
        }
        private void Anular()
        {
            _votacaoAtual.AnularVotacao();
            AtualizarNumeroCandidato();
        }
        private void ConfirmarVotacao()
        {
            if (!_votacaoAtual.VotacaoFinalizada())
            {
                AtualizarNumeroCandidato();
                return;
            }
            _votacaoAtual.ConfirmaVotacao();
            NovaVotacao();
        }
    }
}
