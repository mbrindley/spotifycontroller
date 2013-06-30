using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyControl
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage:\n\tspotifycontrol.exe command");
                return;
            }
            switch (args[0])
            {
                case "playpause":
                    Controller.PlayPause();
                    break;
                case "next":
                    Controller.NextTrack();
                    break;
                case "prev":
                    Controller.PreviousTrack();
                    break;
                case "toggledevice":
                    Controller.SwitchPlaybackDevice();
                    break;
            }
        }
    }
}
