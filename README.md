<img width=150 height=150 src="https://github.com/jeremjlr/MulDisplay/blob/main/MulmulTechnologiesIconReworkedTransparent.png"/><br/>

# MulDisplay - Showcase/example available.
MulDisplay is a .NET all in one (2D/3D) display API designed as a debugging/display tool. It can be used to easily display camera frames, 3D point clouds, 3D objects, 2D/3D overlays, etc..

## Table of Contents
<ol>
  <li><a href="#about-the-project">About The Project</a></li>
  <li><a href="#roadmap">Roadmap</a></li>
  <li><a href="#faq">FAQ</a></li>
  <li><a href="#license">License</a></li>
  <li><a href="#contact">Contact</a></li>
</ol>

## About The Project
The API uses a custom drawing context embedded in a WinForms panel HWND.<br/>
This bypasses WinForms/Wpf limitations and allows for optimized and efficient drawing.<br/>

Using 3D in .NET WPF or WindowsForms has never been easier, it can done with only a few lines of code.<br/>
The purpose of this tool is to encapsulate as much 2D/3D as possible in order to have a simple, lightweight and extremly easy-to-use API.<br/>
The goal is to provide a quick and easy way to display things in order to either visualize or simply debug algorithms.<br/>
I am open to requests and suggestions for future developpement/improvements.<br/>
It is developped with Visual Studio 2022 and .NET 7.0 but there is also a Framework 4.8 compatible version.<br/>

NuGet : https://www.nuget.org/packages/MulDisplay<br/>
Examples :  https://github.com/jeremjlr/MulDisplay/releases<br/>
Documentation : https://jeremjlr.github.io/MulDisplay/index.html<br/>

You can easily switch from 3D to 2D using the right click menu.<br/>
You can use the mouse left click/middle click/wheel to move the camera.<br/>
Double click to go fullscreen.<br/>

I recommend checking out the examples to understand how to use the API but you can get started very quickly, it only requires a WindowsForms panel, whether it's native WinForms or embedded in a WPF App : 

```C#
DrawingControl myDrawingControl = new DrawingControl(Driver.Direct3D, ViewMode._3D, false, false, 5, 1f, 4, false, false);
myDrawingControl.Dock = DockStyle.Fill;
myPanel.Controls.Add(myDrawingControl);
```

You can then use myDrawingControl and myDrawingControl.DrawingContext to use all the API's features.

<p>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen1.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen2.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen3.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen4.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen5.jpg"/><br/>
            <img width=480 height=270 src="https://github.com/jeremjlr/MulDisplay/blob/main/Screen6.jpg"/><br/>
</p>

## Roadmap
<ul>
  <li>Upgrade the engine to the latest Irrlicht release (That will solve the 32-bit obj mesh loading issue)</li>
  <li>More supported formats (or better support of formats and their variants in general) (current MulDisplay prefered formats are .ply and .obj)</li>
  <li>Have a variant of the API with a more recent/powerful 3D Engine (Ogre3D) => Work in progress</li>
  <li>Fix of known&reported bugs</li>
  <li>Add new features (depending on users' demands) while KEEPING the original idea of the API and keeping it as simple as possible for the user</li>
  <li>MAUI ?</li>
</ul>

## FAQ
<b>I'm getting errors when trying to run examples.</b><br/>
Make sure to have at least DirectX 9.0c/OpenGL4.5, .NET 7.0 (or .NET Framework 4.8) and <a href="https://docs.microsoft.com/en-US/cpp/windows/latest-supported-vc-redist?view=msvc-160">Microsoft Visual C++ Redistributable Package</a> installed.<br/>

<b>.NET Core ? .NET Framework ?</b><br/>
MulDisplay is being developped with .NET 6.0/7.0 but it still has a .NET Framework 4.8 compatible version published on NuGet.

## License
MulDisplay is entirely free for any non-commercial project. If you plan to use MulDisplay in a commercial project, please contact me and let me know.<br/>

Libraries used by MulDisplay :<br/>
<ul>
  <li>IrrlichtLime under the Zlib License, see https://github.com/greenya/irrlichtlime.</li>
  <li>Irrlicht under the Zlib/libpng License, see https://sourceforge.net/projects/irrlicht/ or https://irrlicht.sourceforge.io/.</li>
</ul>

## Contact
If you have any question or suggestion feel about anything, free to reach out to me at contact@mulmul-technologies.com or jerem.jlr@gmail.com.
