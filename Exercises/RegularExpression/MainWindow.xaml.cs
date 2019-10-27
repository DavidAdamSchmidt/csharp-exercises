using System.Windows;

namespace RegularExpression
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!Validator.IsValidName(TxtName.Text))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)",
                    "Invalid name", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Validator.IsValidPhoneNumber(TxtPhone.Text))
            {
                MessageBox.Show("The phone number is invalid (not matching the 10 digit standard)",
                    "Invalid phone number", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Validator.IsValidEmailAddress(TxtEmail.Text))
            {
                MessageBox.Show("The e-mail address is invalid", "Invalid e-mail address",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                TxtPhone.Text = Formatter.ReformatPhoneNumber(TxtPhone.Text);

                MessageBox.Show("Your inputs have been successfully validated", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
