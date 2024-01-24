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
            //var model = new Model();

            //Obter o Index do ComboBox
            int selectedMonthIndex = cmbMonth.SelectedIndex;

            //Selectionar o índice correspondente
            int inputMonth = selectedMonthIndex + 1;

            //Obter ano selecionado
            int inputYear = Convert.ToInt32(((ComboBoxItem)cmbYear.SelectedItem).Content);


            var jsonText = File.ReadAllText("C:\\Projects\\Thanksgiving\\ThanksgivingWPF\\model.json");
            var model = JsonConvert.DeserializeObject<Model>(jsonText);


            var newOvolutionDate = model.OvulationOriginalDate;
            while (newOvolutionDate.Month != inputMonth || newOvolutionDate.Year != inputYear)
            {
                newOvolutionDate = newOvolutionDate.AddDays(model.CiclyeTime);
            }

            txtResult.Text = newOvolutionDate.ToString("dd-MM-yyyy");

        }

        private void ConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            var model = new Model();
            ConfigurationWindow configWindow = new ConfigurationWindow(model);
            configWindow.ShowDialog();
        }
    }
}
