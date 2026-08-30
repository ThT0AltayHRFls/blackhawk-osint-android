using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;

namespace BlackHawk;

internal static class AndroidNotificationChannels
{
    internal const string AlertChannelId = "blackhawk_alerts_v2";

    internal static void EnsureCreated(Context context)
    {
        if (Build.VERSION.SdkInt < BuildVersionCodes.O)
        {
            return;
        }

        var manager = context.GetSystemService(Context.NotificationService) as NotificationManager;
        if (manager is null)
        {
            return;
        }

        var channel = new NotificationChannel(
            AlertChannelId,
            "BlackHawk OSINT uyarıları",
            NotificationImportance.High)
        {
            Description = "Yeni OSINT bulguları ve tehdit uyarıları"
        };

        channel.EnableVibration(true);
        channel.SetVibrationPattern(new long[] { 0, 160, 90, 160 });
        channel.SetSound(
            Android.Net.Uri.Parse(
                $"android.resource://{context.PackageName}/raw/blackhawk_alert"),
            new AudioAttributes.Builder()
                .SetUsage(AudioUsageKind.Notification)
                .SetContentType(AudioContentType.Sonification)
                .Build());

        manager.CreateNotificationChannel(channel);
    }
}