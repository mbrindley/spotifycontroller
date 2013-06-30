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
                    if (args.Length < 3)
                        Controller.SwitchPlaybackDevice();
                    else
                    {
                        try
                        {
                            Controller.SwitchPlaybackDevice(int.Parse(args[1]), int.Parse(args[2]));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("One or more arguments was invalid. Device IDs should be whole numbers from 0.");
                        }
                    }
                    break;
            }
        }
    }
}
