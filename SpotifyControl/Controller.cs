using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace SpotifyControl
{
    public class Controller
    {
        private const int AppCommand = 0x0319;

        private const int CmdPlayPause = 917504;
        private const int CmdPrevious = 786432;
        private const int CmdNext = 720896;

        public static void PlayPause()
        {
            SendCommand(CmdPlayPause);
        }

        public static void PreviousTrack()
        {
            SendCommand(CmdPrevious);
        }

        public static void NextTrack()
        {
            SendCommand(CmdNext);
        }

        public static void SwitchPlaybackDevice(int deviceId1 = 0, int deviceId2 = 1)
        {
            // Find our current default playback device
            var baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var regKey = baseKey.CreateSubKey(@"Software\SpotifyControl", RegistryKeyPermissionCheck.ReadWriteSubTree);
            var device = (int)regKey.GetValue("PlaybackDevice", deviceId1);
            device = device == deviceId1 ? deviceId2 : deviceId1;   // Toggle which device we're using
            regKey.SetValue("PlaybackDevice", device);

            Process.Start(new ProcessStartInfo(@"PlaybackDevicePicker\EndPointController.exe", device.ToString())
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            });
        }

        private static void SendCommand(int command)
        {
            User32.SendMessage(FindSpotifyWindow(), AppCommand, IntPtr.Zero, new IntPtr(command));
        }

        private static IntPtr FindSpotifyWindow()
        {
            return User32.FindWindow("SpotifyMainWindow", null);
        }
    }
}