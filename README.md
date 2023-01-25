# MurphyDisplay git was closed and the project was renamed to MulDisplay. It isn't available anymore until further notice.
MulDisplay is a .NET 7 all in one (2D/3D) display API designed as a debugging/display tool. It can be used to easily display camera frames, 3D point clouds, 3D objects, 2D/3D overlays, etc..

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
It is developped with Visual Studio 2022 and .NET 7.0, previous versions were using Framework 4.8.<br/>
Everything should be ready to be built in one click.<br/>

You can easily switch from 3D to 2D using the right click menu.<br/>
You can use the mouse left click/middle click/wheel to move the camera.<br />
Double click to go fullscreen.

I recommend checking the examples to understand how to use the API but you can get started very quickly, it only requires a WindowsForms panel, whether it's native WinForms or embedded in a WPF App with the following code : 

```C#
DrawingControl myDrawingControl = new DrawingControl(Driver.Direct3D, ViewMode._3D, false, false, 5, 1f, 4, false, false);
myDrawingControl.Dock = DockStyle.Fill;
myPanel.Controls.Add(myDrawingControl);
```

You can then use myDrawingControl and myDrawingControl.DrawingContext to use all the API's features.

<p>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen2.png"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen1.png"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/PointCloud.png"/><br/>
</p>

## Roadmap
<ul>
  <li>The project is currently being reworked.</li>
  <li>A NuGet version will be released with the new project. As well as examples on this repository.</li>
  <li>Adding more supported formats.</li>
</ul>

## FAQ
<b>I'm getting errors when trying to run examples.</b><br/>
Make sure you have DirectX 9.0c/OpenGL, .NET 7.0 (or .NET Framework 4.8) and <a href="https://docs.microsoft.com/en-US/cpp/windows/latest-supported-vc-redist?view=msvc-160">Microsoft Visual C++ Redistributable Package</a> installed.<br/>
Also make sure to build the whole solution at least once in either x86 or x64.

<b>.NET Core ? .NET Framework ?</b><br/>
The project has now been switched to .NET 7.0 but I'll keep releasing .NET Framework 4.8 and .NET Core 3.1 versions as well.

## License
As the project is being reworked, licensing is subject to changes.<br/>

Libraries used by MulDisplay :<br/>
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
