# MurphyDisplay (v0.4) - MurphyDisplay will be switched to .NET CORE 7 (from Framework 4.8) starting on Dec. 2022 
MurphyDisplay is a .NET Core 7 all in one (2D/3D) display API designed as a debugging/display tool. It can be used to easily display camera frames, 3D point clouds, 3D objects, 2D/3D overlays, etc..

## Table of Contents
<ol>
  <li><a href="#about-the-project">About The Project</a></li>
  <li><a href="#roadmap">Roadmap</a></li>
  <li><a href="#faq">FAQ</a></li>
  <li><a href="#license">License</a></li>
  <li><a href="#known-bugs">Known bugs</a></li>
  <li><a href="#contact">Contact</a></li>
</ol>

## About The Project
This project was mainly designed to serve as a debugging tool in robotics and such.<br/>
The goal is to provide a quick and easy way to display things in order to visualize and debug algorithms.<br/>
It is developped with Visual Studio 2022 and .NET Core 7.0, previous versions were using Framework 4.8.<br/>
Everything should be ready to be built in one click.<br/>

You can easily switch from 3D to 2D using the right click menu.<br/>
You can use the mouse left click/middle click/wheel to move the camera.<br />
Double click to go fullscreen.

I recommend checking the examples to understand how to use the API but you can get started very quickly, it only requires a WindowsForms panel, whether it's native WinForms or embedded in a WPF App with the following code : 

```C#
DrawingControl myDrawingControl = new DrawingControl(Driver.Direct3D, ViewMode._3D, false, false, 5, 1f, 4, 250, false);
myDrawingControl.Dock = DockStyle.Fill;
myPanel.Controls.Add(myDrawingControl);
```

You can then use myDrawingControl and myDrawingControl.DrawingContext to use all the API's features.

<p>
            <img width=480 height=270 src="https://github.com/jeremjlr/MurphyDisplay/blob/master/Media/Screenshots/Screen2.png"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MurphyDisplay/blob/master/Media/Screenshots/Screen1.png"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MurphyDisplay/blob/master/Media/Screenshots/PointCloud.png"/><br/>
</p>

## Roadmap
<ul>
  <li>Nothing big planned at the moment besides chasing bugs.</li>
</ul>

## FAQ
<b>I'm getting errors when trying to run examples.</b><br/>
Make sure you have DirectX 9.0c/OpenGL, .NET Core 7.0 (or .NET Framework 4.8) and <a href="https://docs.microsoft.com/en-US/cpp/windows/latest-supported-vc-redist?view=msvc-160">Microsoft Visual C++ Redistributable Package</a> installed.<br/>
Also make sure to build the whole solution at least once in either x86 or x64.

<b>.NET Core ? .NET Framework ?</b><br/>
The project has now been switched to .NET Core 7.0 but previous versions are still usable with Framework 4.8 if needed. Also, even if developped with .NET Core, the project might still remain compatible with .NET Framework 4.8 as long as you manually switch it and rebuild.

## License
MurphyDisplay is now available under the LGPL-2.1 License which allows commercial or private use. Only modifications made to the library itself must be published under LGPL.<br/>
Emgu CV is only used in some of the examples and isn't used at all in any of the MurphyDisplay source code.<br/>

Libraries used by MurphyDisplay :<br/>
<ul>
  <li>IrrlichtLime under the Zlib License, see https://github.com/greenya/irrlichtlime.</li>
  <li>Irrlicht under the Zlib/libpng License, see https://sourceforge.net/projects/irrlicht/ or https://irrlicht.sourceforge.io/.</li>
</ul>

## Known bugs

<ul>
  <li>The small XYZ reference bottom right corner is sometimes incorrect.</li>
</ul>


## Contact
If you have any question or suggestion feel free to reach out to me at jerem.jlr@gmail.com.
