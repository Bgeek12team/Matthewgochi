using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Matthew;
namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool matthewIsLive;
        private Client matthew;

        public MainWindow()
        {
            InitializeComponent();
            friendsMatthew.Visibility = Visibility.Hidden;
            buttonSendQuestion.Visibility = Visibility.Hidden;
            buttonFeed.Visibility = Visibility.Hidden;
            txBxSendQuestion.Visibility = Visibility.Hidden;
            matthewIsLive = false;
            matthew = new Client();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void showMatthew(object sender, RoutedEventArgs e)
        {
            int to = matthewIsLive ? 30 : -150;
            DoubleAnimation animation = new DoubleAnimation
            {
                To = to, // Задайте значение, до которого должно перемещаться изображение
                Duration = TimeSpan.FromSeconds(1), // Продолжительность анимации
            };
            if (!matthewIsLive)
            {
                friendsMatthew.Visibility = Visibility.Visible;
                translateTransform.BeginAnimation(TranslateTransform.YProperty, animation);
                buttonFeed.Visibility = Visibility.Visible;
                buttonSendQuestion.Visibility = Visibility.Visible;
                txBxSendQuestion.Visibility = Visibility.Visible;
                buttonShowMatthew.Content = "Обратно на парашу";
            } 
            else 
            { 
                buttonShowMatthew.Content = "Призвать";
                translateTransform.BeginAnimation(TranslateTransform.YProperty, animation);
                buttonSendQuestion.Visibility = Visibility.Hidden;
                buttonFeed.Visibility = Visibility.Hidden;
                friendsMatthew.Visibility = Visibility.Hidden;
                txBxSendQuestion.Visibility = Visibility.Hidden;
            }
            matthewIsLive = !matthewIsLive;
        }
        private void sendQuestion(object sender, RoutedEventArgs e)
        {
            string answer = txBxSendQuestion.Text != String.Empty ? matthew.Play(txBxSendQuestion.Text) : "Error";
            MessageBox.Show(answer);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void deleteText(object sender, RoutedEventArgs e) => txBxSendQuestion.Text = string.Empty;
    }
}