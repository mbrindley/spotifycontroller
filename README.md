Spotify Controller
==================

A Windows application for controlling Spotify, designed for use with the [Griffin PowerMate](http://store.griffintechnology.com/laptops/powermate).

![Griffin PowerMate](https://raw.github.com/mbrindley/spotifycontroller/master/Images/powermate.png)

## Usage ##

| Action | Trigger |
| ------------- | ------------- |
| Turn volume up | Rotate PowerMate clockwise |
| Turn volume down | Rotate PowerMate counter-clockwise |
| Play/Pause | Press PowerMate's button |
| Skip to next track | Press PowerMate's button and rotate clockwise |
| Go back to previous track | Press PowerMate's button and rotate counter-clockwise |
| Switch playback devices (eg speakers to headphones) | Press and hold PowerMate's button |


## Credits ##

Thanks to [Dave Amenta](http://www.daveamenta.com/) for the [C++ source code](http://www.daveamenta.com/2011-05/programmatically-or-command-line-change-the-default-sound-playback-device-in-windows-7/) to list and toggle audio playback devices in Windows.

Also thanks to [Bjørge Næss](https://github.com/bjoerge) for the inspiration and application command codes from [pytify.py](https://code.google.com/p/pytify/source/browse/trunk/pytify.py)

## Installation ##

Compile SpotifyControl.sln, copy the output to somewhere sensible (eg C:\Program Files\SpotifyControl\).

Open the PowerMate Editor and select your PowerMate device.

Under Global Setting, ensure the following actions are set:

**Turned clockwise**

	Raise System Volume 

**Turned counter-clockwise**

	Lower System Volume

**Pressed & turned clockwise**

	Opens an Application, File, or Web Address
	File: "C:\Path To SpotifyControl\SpotifyControl.exe" next

**Pressed & turned counter-clockwise**

	Opens an Application, File, or Web Address
	File: "C:\Path To SpotifyControl\SpotifyControl.exe" prev

**Pressed**

	Opens an Application, File, or Web Address
	File: "C:\Path To SpotifyControl\SpotifyControl.exe" playpause


**Pressed and held**

	Opens an Application, File, or Web Address
	File: "C:\Path To SpotifyControl\SpotifyControl.exe" toggleinput 1 2

The last two parameters are important, they're the device ID that you want to switch to after holding down the PowerMate's button. In my case, I toggle between device 1 and 2, which switches from my display speakers to my headphones (plugged into my sound card). If you're using a single playback device, this feature won't be of any use to you. You can see which playback devices you have by going to

	Control Panel\Hardware and Sound\Manage Audio Devices

A typical configuration will look like this:

![Windows Audio Manager](https://raw.github.com/mbrindley/spotifycontroller/master/Images/manage_audio.png)

In this example, "Speakers" has a device ID of 0, "LED Display" is 1 and the second set of speakers is 2. I've plugged my headphones into my second set of speakers so I can switch between display speakers and my headphones using the PowerMate.

If you're unsure of the device IDs for your playback devices, you can run the included utility application (created by [Dave Amenta](http://www.daveamenta.com/2011-05/programmatically-or-command-line-change-the-default-sound-playback-device-in-windows-7/)) to list playback devices and their IDs:

	SpotifyControl\PlaybackDevicePicker\EndPointController.exe

	Audio Device 0: Speakers (Display Audio)
	Audio Device 1: LED Cinema-2 (NVIDIA High Definition Audio)
	Audio Device 2: Speakers (Realtek High Definition Audio)
