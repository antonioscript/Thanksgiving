using System.Windows;

namespace ThanksgivingWPF
{
    public partial class ConfigurationWindow : Window
    {
        private Model modelInstance;

        public ConfigurationWindow(Model model)
        {
            InitializeComponent();
            modelInstance = model;
            txtCycleTime.Text = modelInstance.CiclyeTime.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCycleTime.Text, out int newCycleTime))
            {
                modelInstance.CiclyeTime = newCycleTime;
                MessageBox.Show("Configurações salvas com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor válido para o Ciclo de Tempo.");
            }
        }
    }
}
