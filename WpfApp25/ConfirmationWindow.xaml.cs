using System.Windows;

namespace WpfApp25
{
    public partial class ConfirmationWindow : Window
    {
        public ConfirmationWindow(string message)
        {
            InitializeComponent();
            ConfirmationTextBlock.Text = message;  // Устанавливаем текст из параметра
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  // Закрываем окно
        }
    }
}
