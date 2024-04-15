using System.Globalization;
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
using System.Drawing;
using MatthewV2;
namespace WpfProject
{
    public class TextFormatterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value as string;
            if (string.IsNullOrEmpty(input))
                return null;

            // Разбиваем строку на слова
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var textBlock = new TextBlock { TextWrapping = TextWrapping.Wrap };

            // Форматируем каждое слово
            foreach (var word in words)
            {
                var run = new Run(word + " ");
                run.Foreground = new SolidColorBrush(Colors.Blue); // Пример форматирования
                textBlock.Inlines.Add(run);
            }

            return new InlineUIContainer(textBlock);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool matthewIsLive;
        private Client matthew;
        private DoubleAnimation animation;

        public MainWindow()
        {
            InitializeComponent();
            friendsMatthew.Visibility = Visibility.Hidden;
            buttonSendQuestion.Visibility = Visibility.Hidden;
            buttonFeed.Visibility = Visibility.Hidden;
            txBxSendQuestion.Visibility = Visibility.Hidden;
            matthewIsLive = false;

            matthew = new Client();
            matthew.TurnedEvil += Matthew_TurnedEvil;
            matthew.TurnedKind += Matthew_TurnedKind;
            
            
        }

        private void Matthew_TurnedKind(object? sender, EventArgs e)
        {
            friendsMatthew.Visibility = Visibility.Visible;
            angryArtem.Visibility = Visibility.Hidden;
            translateTransform.BeginAnimation(TranslateTransform.YProperty, animation);
        }

        private void Matthew_TurnedEvil(object? sender, EventArgs e)
        {
            friendsMatthew.Visibility = Visibility.Hidden;
            angryArtem.Visibility = Visibility.Visible;
            translateTransform2.BeginAnimation(TranslateTransform.YProperty, animation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void showMatthew(object sender, RoutedEventArgs e)
        {
            int to = matthewIsLive ? 30 : -150;
            animation = new DoubleAnimation
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
                buttonShowMatthew.Content = "Прекратить общение";
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
        private async void sendQuestion(object sender, RoutedEventArgs e)
        {
            this.ans.AppendText("You: " + txBxSendQuestion.Text + "\r\n");
            var ans = await matthew.Ask(txBxSendQuestion.Text, txBxSendQuestion.Text.Length);
            this.ans.AppendText("He: " + ans + "\r\n");
            this.ans.AppendText("_______________________________________");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void deleteText(object sender, RoutedEventArgs e) => txBxSendQuestion.Text = string.Empty;
        

        private void buttonFeed_Click(object sender, RoutedEventArgs e)
        {
            matthew.Feed(10);
        }
    }
}