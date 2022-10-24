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
    public partial class MainWindow : Window
    {
        Workshop workshop = new Workshop();
        bool SetUp = true;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            GetPlayerName();

        }
        private void RefreshInformationDisplays()
        {
            PlayerInventory.Text = workshop.ShowPlayerInventory();
            PlayerName.Text = workshop.ShowPlayerNameAndCurrency();
        }
        private void GetPlayerName()
        {
            ConsoleOutput.Text = "Hello!\nPlease enter your name in the box below and then click the submit button.";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (SetUp)
            {
                if (ConsoleInput.Text != "")
                    workshop.SetPlayerName(ConsoleInput.Text);

                SetUp = false;
                ConsoleOutput.Text = "";
                ShowMenu();
                RefreshInformationDisplays();
                ConsoleInput.Text = "";
                return;
            }


            switch (ConsoleInput.Text)
            {
                case "1":
                    ConsoleOutput.Text = workshop.CreateNewItem();
                    Pause();
                    break;
                case "2":
                    ConsoleOutput.Text = workshop.Trade();
                    Pause();
                    break;
                case "3":
                    ConsoleOutput.Text = workshop.ShowRecipes();
                    Pause();
                    break;
                case "m":
                    ShowMenu();
                    break;
                default:
                    ConsoleOutput.Text += "Please enter only 1, 2, or 3.\n";
                    break;

            }

            ConsoleInput.Text = "";
        }
        private void Pause()
        {
            ConsoleOutput.Text += "Enter m in the box below to return to the main menu.";
        }
        private void ShowMenu()
        {
            string output = $"{workshop.ShowPlayerName()}, what would you like to do?\n1) Create a new item\n2) Trade\n3) See all recipes\n";
            output += "Please enter 1, 2, or 3 in the box below and then click the submit button\n\n";
            ConsoleOutput.Text = output;
        }

    }
}
