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

        public static void SwitchPlaybackDevice()
        {
            // Find our current default playback device
            var baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var regKey = baseKey.CreateSubKey(@"Software\SpotifyControl", RegistryKeyPermissionCheck.ReadWriteSubTree);
            var device = (int)regKey.GetValue("PlaybackDevice", 1);

            // In this case, it's either 1 (display speakers) or 2 (internal sound card aka headphones)
            Process.Start(new ProcessStartInfo(@"PlaybackDevicePicker\EndPointController.exe", device.ToString())
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            });

            regKey.SetValue("PlaybackDevice", device == 1 ? 2 : 1);
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