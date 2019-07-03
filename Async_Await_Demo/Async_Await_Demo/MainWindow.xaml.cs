using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Async_Await_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttonKlickMich.Click += NochEtwas;
        }

        private async void NochEtwas(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            MessageBox.Show("Ich mache nochetwas");
        }

        // async void       => NUR BEI EVENTHANDLER nutzen
        // async Task       => Alle Methoden ohne Rückgabe
        // async Task<T>    => Alle Methoden MIT Rückgabe
        private async void ButtonKlickMich_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await IchWerfeEineException();
            }
            catch (Exception)
            {

            }
            MessageBox.Show("Start");

            await MachEtwasInEinemTask(); // .ConfigureAwait(false); // => Kontextwechsel auf UI-Thread wird verhindert -> man arbeitet mit dem Thread von dem vorherigen Task gleich weiter (z.B. Performance?)

            textBoxEingabe.Text = "ICH BIN FERTIG";

            string uhrzeit = TaskMitErgebnis().Result; // synchron
            string uhrzeit2 = await TaskMitErgebnis(); // asynchron

            MessageBox.Show("Ende");
            progressBarWert.Value = 0;
        }

        private Task IchWerfeEineException()
        {
            return Task.Run(() =>
            {
                Task.Delay(3000);
                // throw new ArgumentException();
            });
        }

        private Task MachEtwasInEinemTask()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    // Zugriff auf das UI:
                    Dispatcher.Invoke(() => progressBarWert.Value = i);
                    Thread.Sleep(100);
                }
            });
        }

        private Task<string> TaskMitErgebnis()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                return DateTime.Now.ToLongTimeString();
            });
        }
    }
}
