using System;
using System.Collections.Generic;
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

namespace SimpleVolumeController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly SliderData Slider_Data = new SliderData { SliderValue = "0" };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Slider_Data;
            txt10.Text = Slider_Data.SliderValue;
            _ = txt10.Focus();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            txt10.Text = Convert.ToString(val);
            Slider_Data.SliderValue = txt10.Text;
        }
        private void TextChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            
           if(txt10.Text == "")
            {
                Slider.Value = 0;
                return;
            }

            if ((Convert.ToInt32(txt10.Text) >= 0) && (Convert.ToInt32(txt10.Text) <= 80))
            {
                Slider.Value = Convert.ToInt32(txt10.Text);
            }
            else
            {
                _ = MessageBox.Show("The value should not be more than 80.");
                Slider.Value = 0;
            }

        }
        private void Mod_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Slider.IsEnabled = false;
            txt10.IsEnabled = false;

        }
        private void Mod_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Slider.IsEnabled = true;
            txt10.IsEnabled = true;

        }

    }
    class SliderData
    {
        private string sliderValue;

        public string SliderValue
        {
            get { return sliderValue; }
            set { sliderValue = value; }
        }
    }
}
