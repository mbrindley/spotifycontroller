Spotify Controller
==================

Windows application for controlling Spotify, designed for use with the [Griffin PowerMate](http://store.griffintechnology.com/laptops/powermate).

![Griffin PowerMate](http://store.griffintechnology.com/media/catalog/product/p/o/powermate-3.jpg)


## Usage ##

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

