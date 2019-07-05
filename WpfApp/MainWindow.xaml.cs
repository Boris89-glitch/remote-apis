using DemoLibrary;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNumber = 0;
        private int currentNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitClient();
            nextImageButton.IsEnabled = false;
        }
        private async Task LoadImage(int imageNumber = 0) //load image to wpf
        {
            var comic =  await ComicProcessor.LoadComicAsync(imageNumber);
            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
            }
            currentNumber = comic.Num;

            var uri = new Uri(comic.Img);
            comicImage.Source = new BitmapImage(uri);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }
        

        private async void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
                currentNumber--;
                nextImageButton.IsEnabled = true;
                await LoadImage(currentNumber);
        }

        private void SunInformationButton_Click(object sender, RoutedEventArgs e)
        {
            SunInfo sunInfo = new SunInfo();
            sunInfo.Show();
        }

        private async void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
                currentNumber++;
                previousImageButton.IsEnabled = true;
                await LoadImage(currentNumber);
            if (currentNumber == maxNumber)
            {
                nextImageButton.IsEnabled = false;
            }
        }
    }
}
