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
/*
 * Programming II Craft Project
 * Your Name
 * Date
 * Uses demo code from PROG 201 Programming II course
 * https://github.com/janell-baxter/ProgrammingIICraftDemo
 */
namespace ProgrammingIICraftDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum Mode
    {
        Setup,
        Buy,
        Craft,
        Sell
    }
    public partial class MainWindow : Window
    {
        Workshop workshop = new Workshop();
        Mode mode = Mode.Setup;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            SetUp();
        }
        private void RefreshInformationDisplays()
        {
            PlayerInventory.Text = workshop.ShowInventory("player");
            PlayerName.Text = workshop.ShowPlayerNameAndCurrency();
        }
        private void SetUp()
        {
            HideButtons();
            GetPlayerName();
        }
        private void GetPlayerName()
        {
            Output.Text = "Hello!\nPlease enter your name in the box below and then click the submit button.";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (mode == Mode.Setup)
            {
                if (Input.Text != "")
                    workshop.SetPlayerName(Input.Text);

                mode = Mode.Buy;
                Output.Text = "";
                ShowMenu();
                RefreshInformationDisplays();
                Input.Text = "";
                ShowButtons();
                return;
            }
            
            else if (mode == Mode.Craft)
            {
                
            }
            else if (mode == Mode.Sell)
            {
                
            }
            else
            {
                ShowMenu();
            }

            Input.Text = "";

        }
      
        private void ShowMenu()
        {
            string output = $"{workshop.ShowPlayerName()}, what would you like to do?\nClick a button above to craft, trade, or see recipes.\n";

           
            Output.Text = output;
        }

        private void CraftMode_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Craft;
            Output.Text = workshop.ShowRecipes();
            Output.Text += workshop.CreateNewItem();
        }

        private void BuyMode_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Buy;
            Output.Text = "Buy mode";
        }

        private void SellMode_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Sell;
            //Output.Text = workshop.ShowInventory("vendor");
            Output.Text = "Sell mode";
        }
        private void HideButtons()
        {
            CraftMode.Visibility = Visibility.Collapsed;
            SellMode.Visibility = Visibility.Collapsed;
            BuyMode.Visibility = Visibility.Collapsed;
        }
        private void ShowButtons()
        {
            CraftMode.Visibility = Visibility.Visible;
            SellMode.Visibility = Visibility.Visible;
            BuyMode.Visibility = Visibility.Visible;
        }
    }
}
