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
            LoadJsonValues();
        }

        private void LoadJsonValues()
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string jsonPath = System.IO.Path.Combine(currentDirectory, "model.json");

                if (File.Exists(jsonPath))
                {
                    var jsonText = File.ReadAllText(jsonPath);
                    var model = JsonConvert.DeserializeObject<Model>(jsonText);

                    // Preencher o Ciclo de Tempo
                    txtCycleTime.Text = model.CiclyeTime.ToString();

                    // Preencher a Data Base
                    dpDataBase.SelectedDate = model.OvulationOriginalDate;
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções, se houver algum problema ao carregar os valores do JSON
                MessageBox.Show($"Erro ao carregar as informações do JSON: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string jsonPath = System.IO.Path.Combine(currentDirectory, "model.json");
                var jsonText = File.ReadAllText(jsonPath);

                var model = JsonConvert.DeserializeObject<Model>(jsonText);

                // Atualizar o Ciclo de Tempo
                model.CiclyeTime = Convert.ToInt32(txtCycleTime.Text);

                // Obter a data do DatePicker
                if (dpDataBase.SelectedDate.HasValue)
                {
                    model.OvulationOriginalDate = dpDataBase.SelectedDate.Value;
                }

                var updatedJson = JsonConvert.SerializeObject(model, Formatting.Indented);

                File.WriteAllText(jsonPath, updatedJson);

                // Exibir alerta de sucesso
                MessageBox.Show("Informações atualizadas com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Tratar exceções, se houver algum problema
                MessageBox.Show($"Erro ao atualizar as informações: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
