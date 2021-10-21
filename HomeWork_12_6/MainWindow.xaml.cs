using System;
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

namespace HomeWork_12_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository data = new Repository();

        public MainWindow()
        {
            InitializeComponent();

            data.InstallBase();
            cbUsers.ItemsSource = Enum.GetValues(typeof(Users));
        }

        private void cbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Users)cbUsers.SelectedItem == Users.Manager)
            {
                lvClientManager.ItemsSource = data.clients;
                VisiblManager();
            }
            else if((Users)cbUsers.SelectedItem == Users.Consultant)
            {

                lvClientConsultant.ItemsSource = data.clients;
                VisibilConsultant();
            }
                
        }

        /// <summary>
        /// полномочия менеджера по просмотру
        /// </summary>
        private void VisiblManager()
        {
            lvClientConsultant.Visibility = Visibility.Hidden;
            TelConsSet.Visibility = Visibility.Hidden;
            TeleConsButton.Visibility = Visibility.Hidden;
            TeleConsIndex.Visibility = Visibility.Hidden;
            TeleConsIndexText.Visibility = Visibility.Hidden;

            lvClientManager.Visibility = Visibility.Visible;
            SelectedFirstName.Visibility = Visibility.Visible;
            SelectedLastName.Visibility = Visibility.Visible;
            SelectedMiddleName.Visibility = Visibility.Visible;
            SelectedPasport.Visibility = Visibility.Visible;
            SelectedTelephonNumber.Visibility = Visibility.Visible;
            AddLine.Visibility = Visibility.Visible;
            DellLine.Visibility = Visibility.Visible;
            SaveBD.Visibility = Visibility.Visible;
            LoadBD.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// полномочия консультанта по просмотру
        /// </summary>
        private void VisibilConsultant()
        {

            lvClientConsultant.Visibility = Visibility.Visible;
            TelConsSet.Visibility = Visibility.Visible;
            TeleConsButton.Visibility = Visibility.Visible;
            TeleConsIndex.Visibility = Visibility.Visible;
            TeleConsIndexText.Visibility = Visibility.Visible;

            lvClientManager.Visibility = Visibility.Hidden;
            SelectedFirstName.Visibility = Visibility.Hidden;
            SelectedLastName.Visibility = Visibility.Hidden;
            SelectedMiddleName.Visibility = Visibility.Hidden;
            SelectedPasport.Visibility = Visibility.Hidden;
            SelectedTelephonNumber.Visibility = Visibility.Hidden;
            AddLine.Visibility = Visibility.Hidden;
            DellLine.Visibility = Visibility.Hidden;
            SaveBD.Visibility = Visibility.Hidden;
            LoadBD.Visibility = Visibility.Hidden;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lvClientConsultant.ItemsSource = data.clients;
            lvClientManager.ItemsSource = data.clients;
        }

        ///// <summary>
        ///// заменить линии
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SetLine_Click(object sender, RoutedEventArgs e)
        //{
        //    int index = int.Parse(SelectIndex.Text);

        //    if(!String.IsNullOrEmpty(SelectedFirstName.Text))
        //        data.SetFirstName(SelectedFirstName.Text,index);

        //    if (!String.IsNullOrEmpty(SelectedLastName.Text))
        //        data.SetLastName(SelectedLastName.Text, index);
            
        //    if (!String.IsNullOrEmpty(SelectedMiddleName.Text))
        //        data.SetMiddleName(SelectedMiddleName.Text, index);
            
        //    if (!String.IsNullOrEmpty(SelectedTelephonNumber.Text))
        //        data.SetTelephon(Decimal.Parse(SelectedTelephonNumber.Text), index);
           
        //    if (!String.IsNullOrEmpty(SelectedPasport.Text))
        //        data.SetPasport(SelectedPasport.Text, index);

        //    //Client newClient = new Client(SelectedFirstName.Text, SelectedLastName.Text,
        //    //            SelectedMiddleName.Text,
        //    //            Decimal.Parse(SelectedTelephonNumber.Text),
        //    //            SelectedPasport.Text);
        //    //data.clients[index]= newClient;

        //    lvClientManager.Items.Refresh();
        //}

        /// <summary>
        /// удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DellLine_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(SelectIndex.Text);
            data.clients.RemoveAt(index);

            lvClientManager.Items.Refresh();
        }

        /// <summary>
        /// Кнопка добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLine_Click(object sender, RoutedEventArgs e)
        {
            
            Client newClient = new Client(SelectedFirstName.Text , SelectedLastName.Text, 
                                    SelectedMiddleName.Text, 
                                    Decimal.Parse(SelectedTelephonNumber.Text), 
                                    SelectedPasport.Text);

            data.clients.Add(newClient);

            lvClientManager.Items.Refresh();
            
        }

        /// <summary>
        /// понять индекс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvClientManager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectIndex.Text = lvClientManager.SelectedIndex.ToString();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                data.SaveBD("_db.json");
                MessageBox.Show("BD sucsess save!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка сохранени \n {ex}");
            }
        }

            private void Button_Load(object sender, RoutedEventArgs e)
            {
                try
                {
                    data.LoadBD("_db.json");
                    MessageBox.Show("BD sucsess loaded!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ошибка загрузки \n {ex}");
                }

            }

        /// <summary>
        /// обновить телефон
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeleConsButton_Click(object sender, RoutedEventArgs e)
        {
            data.SetTelephon(Decimal.Parse(TelConsSet.Text), int.Parse(TeleConsIndex.Text));
            lvClientConsultant.Items.Refresh();
        }
    }
    
}

