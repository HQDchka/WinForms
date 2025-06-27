using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HW14
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rbOption1.IsChecked == true)
                textSelectedVariant.Text = "Выбран: Белый кот";
            else if (rbOption2.IsChecked == true)
                textSelectedVariant.Text = "Выбран: Котёнок который устал";
            else if (rbOption3.IsChecked == true)
                textSelectedVariant.Text = "Выбран: Китайский котек";
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder("Включено: ");
            if (cbOptionA.IsChecked == true) sb.Append("Поспал плохо ");
            if (cbOptionB.IsChecked == true) sb.Append("SmileFace ");
            if (cbOptionC.IsChecked == true) sb.Append("Не довольный? ");
            textSelectedOptions.Text = sb.ToString().Trim();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            rbOption1.IsChecked = rbOption2.IsChecked = rbOption3.IsChecked = false;
            cbOptionA.IsChecked = cbOptionB.IsChecked = cbOptionC.IsChecked = false;
            textSelectedVariant.Text = "";
            textSelectedOptions.Text = "";
        }
    }
}
