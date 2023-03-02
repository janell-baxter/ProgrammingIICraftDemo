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
        Review,
        Craft,
        Trade
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
            PlayerInventory.Text = workshop.ShowPlayerInventory();
            PlayerName.Text = workshop.ShowPlayerNameAndCurrency();
        }
        private void SetUp()
        {
            HideButtons();
            GetPlayerName();
        }
        private void GetPlayerName()
        {
            ConsoleOutput.Text = "Hello!\nPlease enter your name in the box below and then click the submit button.";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (mode == Mode.Setup)
            {
                if (ConsoleInput.Text != "")
                    workshop.SetPlayerName(ConsoleInput.Text);

                mode = Mode.Review;
                ConsoleOutput.Text = "";
                ShowMenu();
                RefreshInformationDisplays();
                ConsoleInput.Text = "";
                ShowButtons();
                return;
            }
            
            else if (mode == Mode.Craft)
            {
                
            }
            else if (mode == Mode.Trade)
            {
                
            }
            else
            {
                ShowMenu();
            }

            ConsoleInput.Text = "";

        }
      
        private void ShowMenu()
        {
            string output = $"{workshop.ShowPlayerName()}, what would you like to do?\nClick a button above to craft, trade, or see recipes.\n";

           
            ConsoleOutput.Text = output;
        }

        private void CraftMode_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Craft;
            ConsoleOutput.Text = workshop.CreateNewItem();
        }

        private void RecipesMode_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Review;
            ConsoleOutput.Text = workshop.ShowRecipes();
        }

        private void TradeMode_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Trade;
            ConsoleOutput.Text = workshop.Trade();
        }
        private void HideButtons()
        {
            CraftMode.Visibility = Visibility.Collapsed;
            TradeMode.Visibility = Visibility.Collapsed;
            RecipesMode.Visibility = Visibility.Collapsed;
        }
        private void ShowButtons()
        {
            CraftMode.Visibility = Visibility.Visible;
            TradeMode.Visibility = Visibility.Visible;
            RecipesMode.Visibility = Visibility.Visible;
        }
    }
}
