using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.LocalNotification;

namespace BlackHawk.Services.Notifications
{
    public class NotificationService
    {
        private List<TimeSpan> _notificationTimes = new List<TimeSpan>
        {
            TimeSpan.Parse("06:00"),
            TimeSpan.Parse("12:00"),
            TimeSpan.Parse("18:00"),
            TimeSpan.Parse("22:00")
        };

        public async Task InitializeAsync()
        {
            try
            {
                await LocalNotificationCenter.Current.RequestNotificationPermissionAsync();
                ScheduleDailyNotifications();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Notification init error: {ex.Message}");
            }
        }

        private void ScheduleDailyNotifications()
        {
            for (int i = 0; i < _notificationTimes.Count; i++)
            {
                var notificationRequest = new NotificationRequest
                {
                    NotificationId = 1000 + i,
                    Title = "BlackHawk OSINT",
                    Description = GetDailyMessage(i),
                    ReturningData = "black_hawk_notification",
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            _notificationTimes[i].Hours, _notificationTimes[i].Minutes, 0),
                        NotifyRepeatInterval = TimeSpan.FromDays(1)
                    }
                };

                LocalNotificationCenter.Current.SendNotification(notificationRequest);
            }
        }

        public async Task SendNotificationAsync(string title, string message, int delaySeconds = 0)
        {
            try
            {
                var notificationRequest = new NotificationRequest
                {
                    NotificationId = new Random().Next(2000, 9999),
                    Title = title,
                    Description = message
                };

                if (delaySeconds > 0)
                {
                    notificationRequest.Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = DateTime.Now.AddSeconds(delaySeconds)
                    };
                }

                await LocalNotificationCenter.Current.SendNotificationAsync(notificationRequest);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Send notification error: {ex.Message}");
            }
        }

        private string GetDailyMessage(int timeIndex)
        {
            return timeIndex switch
            {
                0 => "Günaydın! BlackHawk ile güne başla",
                1 => "Öğle saati: Son haberler ve gelişmeler",
                2 => "Akşam araştırması: Yeni bulguları kontrol et",
                3 => "Gece özeti: Günün önemli olayları",
                _ => "BlackHawk'a hoş geldiniz"
            };
        }
    }
}
