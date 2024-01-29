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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Obter o Index do ComboBox
            int selectedMonthIndex = cmbMonth.SelectedIndex;

            //Selectionar o índice correspondente
            int inputMonth = selectedMonthIndex + 1;

            //Obter ano selecionado
            int inputYear = Convert.ToInt32(((ComboBoxItem)cmbYear.SelectedItem).Content);


            string currentDirectory = Directory.GetCurrentDirectory();
            string jsonPath = System.IO.Path.Combine(currentDirectory, "model.json");
            var jsonText = File.ReadAllText(jsonPath);

            var model = JsonConvert.DeserializeObject<Model>(jsonText);


            var newOvolutionDate = model.OvulationOriginalDate;
            while (newOvolutionDate.Month != inputMonth || newOvolutionDate.Year != inputYear)
            {
                newOvolutionDate = newOvolutionDate.AddDays(model.CiclyeTime);
            }

            txtResultDate.Text = newOvolutionDate.ToString("dd-MM-yyyy");
            txtResultDayOfWeek.Text = newOvolutionDate.DayOfWeek.ToString();

        }

        private void ConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow configurationWindow = new ConfigurationWindow();

            configurationWindow.ShowDialog();
        }

        private void cmbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtResultDayOfWeek_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
