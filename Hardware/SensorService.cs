using System;
using Xamarin.Essentials;

namespace BlackHawk.Hardware
{
    public class SensorService
    {
        public void InitializeAccelerometer()
        {
            if (!Accelerometer.Default.IsSupported)
                return;

            Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Default.Start(SensorSpeed.UI);
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var x = e.Reading.Acceleration.X;
            var y = e.Reading.Acceleration.Y;
            var z = e.Reading.Acceleration.Z;
        }
    }
}
