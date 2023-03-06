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

    public partial class MainWindow : Window
    {
        bool is_end = false;
        String player_side = "крестики";
        int Clicked_buttons = 0;

        void Win(System.Windows.Controls.Image arr_el )
        {
            clear_place();
            if (arr_el == n_1 && player_side == "нолики")
            {
                MessageBox.Show("Вы выиграли :)");
            }
            else if (arr_el == k_1 && player_side == "крестики")
            {
                MessageBox.Show("Вы выиграли :)");
            }
            else if(arr_el == k_1 && player_side == "нолики")
            {
                MessageBox.Show("Вы проиграли :(");
            }
            else if (arr_el == n_1 && player_side == "крестики")
            {
                MessageBox.Show("Вы проиграли :(");
            }

        }
        public void check_win(System.Windows.Controls.Image[] arr)
        {
            if (arr[0].Visibility == Visibility.Visible && arr[4].Visibility == Visibility.Visible && arr[8].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end= true;
            }
            else if (arr[0].Visibility == Visibility.Visible && arr[1].Visibility == Visibility.Visible && arr[2].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end = true;
            }
            else if (arr[0].Visibility == Visibility.Visible && arr[3].Visibility == Visibility.Visible && arr[6].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end = true;
            }
            else if (arr[1].Visibility == Visibility.Visible && arr[4].Visibility == Visibility.Visible && arr[7].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end = true;
            }
            else if (arr[2].Visibility == Visibility.Visible && arr[5].Visibility == Visibility.Visible && arr[8].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end = true;
            }
            else if (arr[2].Visibility == Visibility.Visible && arr[4].Visibility == Visibility.Visible && arr[6].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end = true;
            }
            else if (arr[6].Visibility == Visibility.Visible && arr[7].Visibility == Visibility.Visible && arr[8].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end = true;
            }
            else if (arr[3].Visibility == Visibility.Visible && arr[4].Visibility == Visibility.Visible && arr[5].Visibility == Visibility.Visible)
            {
                Win(arr[0]);
                is_end = true;
            }
            else if (Clicked_buttons == 9)
            {
                //Случай если ничья
                //не придумал
            }

            
        }


        public void Show_clicked_button(int grid_num)
        {
            System.Windows.Controls.Image[] nol_arr = new[] { n_1, n_2, n_3, n_4, n_5, n_6, n_7, n_8, n_9 };
            System.Windows.Controls.Image[] kr_arr = new[] { k_1, k_2, k_3, k_4, k_5, k_6, k_7, k_8, k_9 };
              
            if (player_side == "крестики")
            {
                Clicked_buttons++;
                Image img = kr_arr[grid_num - 1];
                img.Visibility = Visibility.Visible;
                check_win(kr_arr);
                
            }
            else
            {
                Clicked_buttons++;
                Image img = nol_arr[grid_num - 1];
                img.Visibility = Visibility.Visible;
                check_win(nol_arr);
            }
   
        }

        private void ButtonGrid_OnClick(object sender, RoutedEventArgs e)
        {
            Button my_button = sender as Button;
            my_button.IsEnabled = false;
            int grid_num = Convert.ToInt16(my_button.Name.Substring(my_button.Name.Length - 1));
            Show_clicked_button(grid_num);
            if (!is_end)
            {
                robo_step();
            }
           

        }


        private void Start_bt_Click(object sender, RoutedEventArgs e)
        {
            var buttons = DrillGrid.Children.OfType<Button>().ToList();
            buttons.ForEach(btn =>
            {
                btn.IsEnabled = true;
            });
            Start_bt.IsEnabled = false;
            is_end = false;
        }

        private void Rest_bt_Click(object sender, RoutedEventArgs e)
        {
            clear_place();
        }

        private void clear_place()
        {
            var buttons = DrillGrid.Children.OfType<Button>().ToList();
            buttons.ForEach(btn =>
            {
                btn.IsEnabled = false;
            });

            Start_bt.IsEnabled = true;

            var images = DrillGrid.Children.OfType<Image>().ToList();
            images.ForEach(img =>
            {
                img.Visibility = Visibility.Hidden;
            });
        }


        private void robo_step()
        {
            System.Windows.Controls.Image[] nol_arr = new[] { n_1, n_2, n_3, n_4, n_5, n_6, n_7, n_8, n_9 };
            System.Windows.Controls.Image[] kr_arr = new[] { k_1, k_2, k_3, k_4, k_5, k_6, k_7, k_8, k_9 };
            Random rand = new Random();
            while (true)
            {
                int rand_num = rand.Next(0, 8);
                if (nol_arr[rand_num].Visibility != Visibility.Visible && kr_arr[rand_num].Visibility != Visibility.Visible)
                {
                    Show_clicked_button(rand_num);
                    break;
                }
            }
        }
    }
}
