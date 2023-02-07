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

namespace Krestoviy_Pohod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public void mozg(Button my_button)
        {
            System.Windows.Controls.Image[] nol_arr = new[] { n_1, n_2, n_3, n_4, n_5, n_6, n_7, n_8, n_9 };
            System.Windows.Controls.Image[] kr_arr = new[] { k_1, k_2, k_3, k_4, k_5, k_6, k_7, k_8, k_9 };
            int grid_num = Convert.ToInt16(my_button.Name.Substring(my_button.Name.Length - 1));
            
            Image img = nol_arr[grid_num - 1];
            img.Visibility = Visibility.Visible;
            

            



        }

        private void ButtonGrid_OnClick(object sender, RoutedEventArgs e)
        {
            Button my_button = sender as Button;
            my_button.IsEnabled = false;
            mozg(my_button);
           


            
            //my_button.Background = new ImageBrush(new BitmapImage(uri));
            //Uri uri = new Uri(System.IO.Path.GetFullPath(@"../../../Nolik.png"));
            //DrillGrid.Children.Remove(my_button);
            //Image my_image = sender as Image;
            //my_image.Source = new BitmapImage(uri);
            //MessageBox.Show(button.Grid.Column)

            //DrillGrid.Children.Remove();
        }


        private void Start_bt_Click(object sender, RoutedEventArgs e)
        {
            var buttons = DrillGrid.Children.OfType<Button>().ToList();
            buttons.ForEach(btn =>
            {
                btn.IsEnabled = true;
            });
        }

        private void Rest_bt_Click(object sender, RoutedEventArgs e)
        {
            var buttons = DrillGrid.Children.OfType<Button>().ToList();
            buttons.ForEach(btn =>
            {
                btn.IsEnabled = false;
            });

            Button stButton = Start_bt;
            stButton.IsEnabled = true;



            var images = DrillGrid.Children.OfType<Image>().ToList();
            buttons.ForEach(img =>
            {
                img.Visibility = Visibility.Hidden;
            });
            
            





        }
    }
}
