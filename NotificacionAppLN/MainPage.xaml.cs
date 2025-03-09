using Plugin.LocalNotification;

namespace NotificacionAppLN
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnScheduleNotificationClicked(object sender, EventArgs e)
        {
            var selectedDate = datePicker.Date;
            var selectedTime = timePicker.Time;

            var notificationTime = new DateTime(
                selectedDate.Year,
                selectedDate.Month,
                selectedDate.Day,
                selectedTime.Hours,
                selectedTime.Minutes,
                selectedTime.Seconds
            );

            if (notificationTime > DateTime.Now)
            {
                ScheduleNotification(notificationTime);
                DisplayAlert("Éxito", "Notificación programada.", "OK");
            }
            else
            {
                DisplayAlert("Error", "La fecha y hora deben ser futuras.", "OK");
            }
        }

        private void ScheduleNotification(DateTime notificationTime)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 100, // ID único para la notificación
                Title = "Recordatorio",
                Description = "¡Es hora!",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = notificationTime // Hora programada
                }
            };

            // Programar la notificación
            LocalNotificationCenter.Current.Show(notification);
        }
    }

}
