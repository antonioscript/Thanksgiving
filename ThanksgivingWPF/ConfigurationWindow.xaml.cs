using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThanksgivingWPF
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string jsonPath = System.IO.Path.Combine(currentDirectory, "model.json");
                var jsonText = File.ReadAllText(jsonPath);

                var model = JsonConvert.DeserializeObject<Model>(jsonText);

                model.CiclyeTime = Convert.ToInt32(txtCycleTime.Text);

                var updatedJson = JsonConvert.SerializeObject(model, Formatting.Indented);

                File.WriteAllText(jsonPath, updatedJson);

                // Exibir alerta de sucesso
                MessageBox.Show("Informações atualizadas com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Tratar exceções, se houver algum problema
                MessageBox.Show($"Erro ao atualizar as  informações: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
