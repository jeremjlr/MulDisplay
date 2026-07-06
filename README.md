<img width=150 height=150 src="https://github.com/jeremjlr/MulDisplay/blob/main/MulmulTechnologiesIconReworkedTransparent.png"/><br/>

# MulDisplay - Showcase/example available.
MulDisplay is a .NET all in one (2D/3D) display control with some embedded tools. It can be used to easily display camera frames, 3D point clouds, 3D objects, 2D/3D overlays, etc..

## Table of Contents
<ol>
  <li><a href="#about-the-project">About The Project</a></li>
  <li><a href="#faq">FAQ</a></li>
  <li><a href="#roadmap">Roadmap</a></li>
  <li><a href="#licensing">Licensing</a></li>
  <li><a href="#contact">Contact</a></li>
</ol>

## About The Project
The control uses a custom drawing context embedded in a WinForms panel HWND.<br/>
This allows for optimized and efficient drawing.<br/>

It is designed to be used with only a few lines of codes with either WindowsForms or WPF.<br/>
The purpose of this tool is to encapsulate as much 2D/3D as possible in order to have a simple, lightweight and extremely easy-to-use control.<br/>
The goal is to provide a quick and easy way to display things in order to either visualize or simply debug algorithms.<br/>

NuGet : https://www.nuget.org/packages/MulDisplay<br/>
Examples :  https://github.com/jeremjlr/MulDisplay/releases<br/>
Documentation : https://jeremjlr.github.io/MulDisplay/index.html<br/>

You can easily switch from 3D to 2D using the right click menu.<br/>
You can use the mouse left click/middle click/wheel to move the camera.<br/>
Double click to go fullscreen.<br/>

<b>I highly recommend checking out the [examples](https://github.com/jeremjlr/MulDisplay/releases) to understand how to use the control</b> but you can get started very quickly, it only requires a WindowsForms panel, whether it's native WindowsForms or embedded in a WPF App :

```C#
DrawingControl myDrawingControl = new DrawingControl(Driver.Direct3D, ViewMode._3D, false, false, 5, 1f, 4, false, false);
myDrawingControl.Dock = DockStyle.Fill;
myPanel.Controls.Add(myDrawingControl);
```

You can then use `myDrawingControl` and `myDrawingControl.DrawingContext` to use all the control's features.

<p>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen1.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen2.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen3.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen4.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen6.jpg"/><br/>
</p>

## FAQ
<b>I'm getting errors when trying to run examples.</b><br/>
Make sure to have at least DirectX 9.0c/OpenGL4.5, the correct .NET version and Microsoft Visual C++ Redistributable Package installed.<br/>

<b>.NET Core ? .NET Framework ?</b><br/>
MulDisplay is being developed with .NET 10 but is compatible with multiple previous .NET versions.<br/>
I recommend upgrading your .NET version as I do not guarantee that future versions will also be compatible with older versions.<br/>

## Roadmap
<ul>
  <li>Upgrade the engine to the latest Irrlicht release</li>
  <li>More supported formats (or better support of formats and their variants in general) (current MulDisplay prefered formats are .ply and .obj)</li>
  <li>Fix of known &amp; reported bugs</li>
  <li>Add new features (depending on demands, if any)</li>
</ul>

## Licensing
MulDisplay is provided free of charge for use in personal and commercial projects.<br/>
Redistribution, modification, reverse engineering, or rehosting of the package is prohibited without explicit permission.<br/>
Any mention of the author or the project is welcome.<br/>

Libraries used by MulDisplay :<br/>
<ul>
  <li>IrrlichtLime under the Zlib License, see https://github.com/greenya/irrlichtlime.</li>
  <li>Irrlicht under the Zlib/libpng License, see https://sourceforge.net/projects/irrlicht/ or https://irrlicht.sourceforge.io/.</li>
</ul>

## Contact
If you want to reach out to me for any reason, have any question or suggestion, feel free. - jerem.jlr@gmail.com - www.github.com/jeremjlr
