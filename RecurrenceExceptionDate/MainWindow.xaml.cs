using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RecurrenceExceptionDate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Meeting> Meetings = new ObservableCollection<Meeting>();

            // Create the new exception date.
            var exceptionDate = new DateTime(2017, 09, 07);
            var recurrenceAppointment = new Meeting()
            {
                From = new DateTime(2017, 09, 01, 10, 0, 0),
                To = new DateTime(2017, 09, 01, 12, 0, 0),
                EventName = "Occurs Daily",
                IsRecursive = true,
                Color = new SolidColorBrush(Color.FromArgb(0xFf, 0xD8, 0x00, 0x73)),
                RecurrenceExceptionDates = new ObservableCollection<DateTime>()
                                {
                                    exceptionDate
                                }
            };

            // Creating recurrence rule
            recurrenceAppointment.RecurrenceRule = "FREQ=DAILY;COUNT=20";

            Meetings.Add(recurrenceAppointment);
            this.schedule.ItemsSource = Meetings;

            schedule.MoveToDate(recurrenceAppointment.From);
        }
    }
}
