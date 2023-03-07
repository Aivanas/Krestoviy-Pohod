using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading;
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
//Имя Ибрагим вам о чём нибудь говорит?
namespace Krestoviy_Pohod
{

    public partial class MainWindow : Window
    {
        bool is_end = false;
        bool player_side_krestiki = true;
        int Clicked_buttons = 0;
        bool[] is_occupied = new bool[9] {false, false, false, false, false, false, false, false, false};

        void Win(System.Windows.Controls.Image arr_el )
        {
            clear_place();
            if (arr_el == n_1 && player_side_krestiki == true)
            {
                MessageBox.Show("Вы проиграли :(");
            }
            else if (arr_el == k_1 && player_side_krestiki == true)
            {
                MessageBox.Show("Вы выиграли :)");
            }
            else if(arr_el == k_1 && player_side_krestiki == false)
            {
                MessageBox.Show("Вы проиграли :(");
            }
            else if (arr_el == n_1 && player_side_krestiki == false)
            {
                MessageBox.Show("Вы выиграли :)");
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
                clear_place();
                MessageBox.Show("Ничья, Коллега!");
            }

            
        }


        public void Show_clicked_button(int grid_num, bool isRobot)
        {
            System.Windows.Controls.Image[] nol_arr = new[] { n_1, n_2, n_3, n_4, n_5, n_6, n_7, n_8, n_9 };
            System.Windows.Controls.Image[] kr_arr = new[] { k_1, k_2, k_3, k_4, k_5, k_6, k_7, k_8, k_9 };
              
            if (player_side_krestiki == true && isRobot == true)
            {
                Clicked_buttons++;
                Image img = nol_arr[grid_num - 1];
                img.Visibility = Visibility.Visible;
                check_win(nol_arr);
                
            }
            else if (player_side_krestiki == true && isRobot == false)
            {
                Clicked_buttons++;
                Image img = kr_arr[grid_num - 1];
                img.Visibility = Visibility.Visible;
                check_win(kr_arr);
            }
            else if (player_side_krestiki == false && isRobot == true)
            {
                Clicked_buttons++;
                Image img = kr_arr[grid_num - 1];
                img.Visibility = Visibility.Visible;
                check_win(kr_arr);
            }
            else if (player_side_krestiki == false && isRobot == false)
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
            Show_clicked_button(grid_num, false);
            is_occupied[grid_num-1] = true;

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
            int i = 0;
            while (i < 9)
            {
                is_occupied[i] = false;
                i++;
            }

            //if (player_side_krestiki == true)
            //{
            //    player_side_krestiki = false;
            //    Player_side_message.Text = "Вы играете за нолики";
            //}
            //else if (player_side_krestiki == false)
            //{
            //    player_side_krestiki = true;
            //    Player_side_message.Text = "Вы играете за крестики";
            //}

        }


        private void robo_step()
        {
            
            Random rand = new Random();
            int rand_num;
            while (true)
            {
                rand_num = rand.Next(1, 9);
                if (is_occupied[rand_num-1] != true)
                {
                    Show_clicked_button(rand_num, true);
                    is_occupied[rand_num - 1] = true;
                    break;
                }
            }
        }

        
       
    }
}
