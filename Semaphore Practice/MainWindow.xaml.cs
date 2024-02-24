using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semaphore_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Thread> CreatedThreads { get; set; } = new();
        public ObservableCollection<Thread> WaitingThreads { get; set; } = new();
        public ObservableCollection<Thread> WorkingThreads { get; set; } = new();
        public Semaphore semaphore { get; set; } = new(6, 6 ,"Huseyn");


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        // Creating thread
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                
                semaphore.WaitOne();
                Thread.Sleep(1000);
                semaphore.Release();
            }
            );
            thread.Name = "Thread " + thread.ManagedThreadId;
            CreatedThreads.Add(thread);
        }
        // created thread double click
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            Thread newThread = CreatedThreads.FirstOrDefault(a => a.ManagedThreadId == createdThreadss.SelectedValue as int?);
            CreatedThreads.Remove(newThread);
            WaitingThreads.Add(newThread);
        }


        // Waitng listview double click
        private void ListView_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            Thread newThread = WaitingThreads.FirstOrDefault(a => a.ManagedThreadId == Waitingthreadsss.SelectedValue as int?);
            newThread.Start();
        }
    }
}