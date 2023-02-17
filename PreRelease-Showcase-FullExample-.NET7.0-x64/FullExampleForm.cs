// MurphyDisplay is a .NET Core 7 all in one (2D/3D) display API designed as a debugging/display tool.
// It can be used to easily display camera frames, 3D point clouds, 3D objects, 2D/3D overlays, etc..
// Copyright (C) 2022 Jérémy LEPROU jerem.jlr@gmail.com

using System.ComponentModel;
using Emgu.CV;
using Emgu.CV.Cvb;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using IrrlichtLime.Core;
using MulDisplay;
using MulDisplay.Components2D;
using MulDisplay.Components3D;

namespace FullExample
{
    public partial class FullExampleForm : Form
    {
        //Initializes the main drawing control
        private DrawingControl _mainDrawingControl = new DrawingControl(Driver.Direct3D, ViewMode._3D, false, false, 5, 1f, 4, false, false);
        private bool _firstGauss = true;

        #region Builds basic 2D and 3D scenes with overlays etc

        public FullExampleForm()
        {
            InitializeComponent();
            updateButton.Checked = true;
            //Always refreshes the context, this will use more ressources.
            _mainDrawingControl.DrawingContext.AlwaysRefresh = true;
            //Adds the API drawing control to the panel we added in the form to contain it
            _mainDrawingControl.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(_mainDrawingControl);

            _mainDrawingControl.DrawingContext.BuiltInInfoSize = FontSize.BigSize;

            Build2DScene();
            _mainDrawingControl.ViewMode = ViewMode._3D;
            //3D Camera settings
            _mainDrawingControl.DrawingContext.CameraTranslateSpeed = 200f;
            _mainDrawingControl.DrawingContext.CameraDefaultDistance = 15000;
            _mainDrawingControl.DrawingContext.ResetCamera();
        }

        private void Build2DScene()
        {
            //Sets the viewmode to 2D in order to add overlays and refresh it. Also sets the response mode to synchronous.
            _mainDrawingControl.ViewMode = ViewMode._2D;
            _mainDrawingControl.DrawingContext.ResponseMode = ResponseMode.Synchronous;

            _mainDrawingControl.MoveOnClick = true;
            _mainDrawingControl.DrawingContext.ZoomOnResize = true;
            //Removes all overlays when the 2D picture is modified
            _mainDrawingControl.DrawingContext.RemoveOverlaysOnNewImage = true;
            //Sets the 2D picture
            _mainDrawingControl.DrawingContext.SetBackgroundImage("Media/star1.bmp");
            //Some random 2D overlays
            Random rand = new Random();
            //The image we're going to add on the picture as an overlay
            MulDisplay.Components2D.Image img = new MulDisplay.Components2D.Image(rand.Next(0, 1920), rand.Next(0, 1080), "Media/funnyface.jpg");
            for (int i = 0; i < 500; i++)
            {
                int random = rand.Next(0, 3);
                //Adds a circle as a 2D overlay
                if (random == 0)
                {
                    _mainDrawingControl.DrawingContext.Overlays2D.Add(new Circle(rand.Next(0, 1920), rand.Next(0, 1080), Color.Red, 50, 50, 180));
                }
                //Adds a rectangle as a 2D overlay
                else if (random == 1)
                {
                    MulDisplay.Components2D.Rectangle rect = new MulDisplay.Components2D.Rectangle(rand.Next(0, 1920), rand.Next(0, 1080), Color.Yellow, 50, 50);
                    rect.Fill = true;
                    rect.AlphaValue = rand.Next(0, 255);
                    _mainDrawingControl.DrawingContext.Overlays2D.Add(rect);
                }
                //Adds an image as a 2D overlay
                else if (random == 2)
                {
                    //Copying the image overlay from an existing image overlay will not copy the image data itself meaning you can have 1000 different image overlays using the same original image, it will only be stored once in the ram
                    MulDisplay.Components2D.Image img2 = (MulDisplay.Components2D.Image)img.Copy();
                    img2.Position = new Vector2Df(rand.Next(0, 1920), rand.Next(0, 1080));
                    img2.RotationCenter = img2.Position;
                    img2.Rotation = rand.Next(0, 360);
                    img2.Width = 144;
                    img2.Height = 81;
                    _mainDrawingControl.DrawingContext.Overlays2D.Add(img2);
                }
            }
            //Big triangle
            List<Vector2Df> positions = new List<Vector2Df>()
                    {
                        new Vector2Df(100, 100),
                        new Vector2Df(1700, 300),
                        new Vector2Df(900, 950),
                        new Vector2Df(100, 100),
                    };
            Polygon polygon = new Polygon(positions, Color.Orange, 2);
            _mainDrawingControl.DrawingContext.Overlays2D.Add(polygon);

            _mainDrawingControl.DrawingContext.Overlays2D.Add(new Cross(100, 100, Color.Blue));
            _mainDrawingControl.DrawingContext.Overlays2D.Add(new Cross(1700, 300, Color.Green));
            _mainDrawingControl.DrawingContext.Overlays2D.Add(new Cross(900, 950, Color.Purple));

            //Refreshes the 2D picture with its overlays
            _mainDrawingControl.DrawingContext.BuildAndRefresh();
            //Sets the zoom on the whole picture
            _mainDrawingControl.DrawingContext.ZoomOn(0, 0, _mainDrawingControl.DrawingContext.BackgroundImageSize.Width, _mainDrawingControl.DrawingContext.BackgroundImageSize.Height);
        }

        //3D Scene building
        private void Build3DScene()
        {
            Data3D data;
            //Block the scene in order to be able to do anything 
            //The scene has to be blocked before removing and adding new Data3D
            _mainDrawingControl.DrawingContext.BlockScene();
            _mainDrawingControl.DrawingContext.Datas3D.RemoveAll();

            //Add a red cube
            StaticCuboid cube = _mainDrawingControl.DrawingContext.Overlays3D.AddCuboid(500, 500, 250, System.Drawing.Color.Red);
            cube.SetColor(255, 0, 0, 80);
            cube.Position = new Vector3Df(0, -450, 0);
            cube.Rotation = new Vector3Df(-90f, 0f, 0);
            cube.Name = "Red Cube";

            //Load and add the airplane
            data = _mainDrawingControl.DrawingContext.Datas3D.Add("Media/Airplane/Airplane.obj", "Airplane");
            data.Rotation = new Vector3Df(-90f, 180f, 0);
            data.Scale = new Vector3Df(2, 2, 2);
            data.Position = new Vector3Df(0, -1000, 0);

            //Load and add the skull and 2 overlays
            data = _mainDrawingControl.DrawingContext.Datas3D.Add("Media/skull.ply", "Skull");
            data.Rotation = new Vector3Df(0f, -90f, -90f);
            data.Position = new Vector3Df(2500, 2500, 2500);
            //These are 2D overlays in a 3D environment, they always face the camera
            //These overlays are linked to the data, you move the data, it will move the overlays
            data.Overlays3D.AddOverlay2D3D(new Cross2D3D(0, 0, 10, Color.Green, 10, 10, 2));
            data.Overlays3D.AddOverlay2D3D(new Text2D3D("Skull", 0, 0, 10, Color.Red));


            //Load a cloud point obtained from 3D cameras
            data = _mainDrawingControl.DrawingContext.Datas3D.Add("Media/face.ply", "Face");
            data.Scale = new Vector3Df(2f, 2f, 2f);
            data.Rotation = new Vector3Df(90f, -90f, 0);
            data.Position = new Vector3Df(-500, 2500, 2500);
            data.DrawBox = true;

            //The moving grip
            data = _mainDrawingControl.DrawingContext.Datas3D.Add("Media/hutchinson.obj", "Grip");
            data.RecalculateNormals(true, true);

            data.Position = new Vector3Df(0, -50, 0);

            //These overlays are linked to the grip, they will automatically be moved with it
            //2D overlays in 3D
            Cross2D3D cross = new Cross2D3D(0, 0, 0, Color.Green, 20, 20, 2);
            cross.Attribute = "I'm the grip cross !";
            data.Overlays3D.AddOverlay2D3D(cross);
            data.Overlays3D.AddOverlay2D3D(new Text2D3D("Grip", 0, 0, 0, Color.Blue));
            data.DrawBox = true;

            //The yellow arrow of the grip
            StaticArrow arrow = data.Overlays3D.AddArrow(30, 30, 75, 50, 5, 10, Color.Yellow);
            arrow.Rotation = new Vector3Df(180, 0, 0);

            //Gaussian 3D generation
            List<IrrlichtLime.Video.Vertex3D> vertices = new List<IrrlichtLime.Video.Vertex3D>();
            List<uint> indices = new List<uint>();
            GetGaussian(vertices, indices);

            data = _mainDrawingControl.DrawingContext.Datas3D.Add(vertices, indices, "Gauss");
            data.BackFaceCulling = false;
            data.DrawBox = true;
            data.Rotation = new Vector3Df(-90f, 0f, 0);
            data.Position = new Vector3Df(0, -300, 0);

            //We can clear and use the same List to create and add the big bounding box
            vertices.Clear();
            vertices.Add(new IrrlichtLime.Video.Vertex3D(5000, 5000, 5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));
            vertices.Add(new IrrlichtLime.Video.Vertex3D(-5000, 5000, 5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));
            vertices.Add(new IrrlichtLime.Video.Vertex3D(5000, -5000, 5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));
            vertices.Add(new IrrlichtLime.Video.Vertex3D(5000, 5000, -5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));
            vertices.Add(new IrrlichtLime.Video.Vertex3D(-5000, 5000, -5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));
            vertices.Add(new IrrlichtLime.Video.Vertex3D(-5000, -5000, 5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));
            vertices.Add(new IrrlichtLime.Video.Vertex3D(5000, -5000, -5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));
            vertices.Add(new IrrlichtLime.Video.Vertex3D(-5000, -5000, -5000, 0, 0, 0, IrrlichtLime.Video.Color.SolidCyan));

            Data3D bigBox = _mainDrawingControl.DrawingContext.Datas3D.Add(vertices, "BigBox");
            bigBox.PointCloudSize = 5;
            bigBox.Overlays3D.AddOverlay2D3D(new Text2D3D("The BigBox !", 5000, 5000, -5000, Color.Purple));
            //Box lines
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, 5000, 5000), new Vector3Df(-5000, 5000, 5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(-5000, 5000, 5000), new Vector3Df(-5000, 5000, -5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(-5000, 5000, -5000), new Vector3Df(5000, 5000, -5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, 5000, -5000), new Vector3Df(5000, 5000, 5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, -5000, 5000), new Vector3Df(-5000, -5000, 5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(-5000, -5000, 5000), new Vector3Df(-5000, -5000, -5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(-5000, -5000, -5000), new Vector3Df(5000, -5000, -5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, -5000, -5000), new Vector3Df(5000, -5000, 5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, 5000, 5000), new Vector3Df(5000, -5000, 5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(-5000, 5000, 5000), new Vector3Df(-5000, -5000, 5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, 5000, -5000), new Vector3Df(5000, -5000, -5000), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(-5000, 5000, -5000), new Vector3Df(-5000, -5000, -5000), Color.Green);

            //Scene overlays
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Cross2D3D(-2500, 2500, -2500, Color.Yellow, 10, 10, 3));
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Text2D3D("Sphere", -2500, 2500, -2500, Color.Red));
            StaticSphere sphere = _mainDrawingControl.DrawingContext.Overlays3D.AddSphere(1000, 70, 70, Color.FromArgb(80, 0, 0, 255));
            sphere.Position = new Vector3Df(-2500, 2500, -2500);

            //Animated meshes showcase
            //Blue Ninja
            data = _mainDrawingControl.DrawingContext.Datas3D.Add("Media/ninja.b3d", "BlueNinja");
            data.SetFrameLoop(0, 157);
            data.AnimationSpeed = 20f;
            data.Position = new Vector3Df(-360, -900, -950);
            data.Rotation = new Vector3Df(0, 210, 0);
            data.Scale = new Vector3Df(50, 50, 50);
            //Red Ninja
            data = _mainDrawingControl.DrawingContext.Datas3D.Add("Media/ninja.b3d", "RedNinja");
            data.SetTexture(0, "Media/nskinrd.jpg");
            data.SetFrameLoop(0, 157);
            data.AnimationSpeed = 20f;
            data.Position = new Vector3Df(-700, -875, -1500);
            data.Rotation = new Vector3Df(0, 30, 0);
            data.Scale = new Vector3Df(50, 50, 50);

            //Maya
            data = _mainDrawingControl.DrawingContext.Datas3D.Add("Media/Maya/maya.obj", "Maya");
            data.Position = new Vector3Df(3000, 2500, -3000);
            data.Scale = new Vector3Df(500, 500, 500);
            data.Rotation = new Vector3Df(0, 90f, 0);

            //Lines
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(3000, -3000, -4000), new Vector3Df(3000, -2500, -2500), Color.Orange);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Cross2D3D(3000, -3000, -4000, Color.Red, 10, 10, 2));
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(3000, -2500, -2500), new Vector3Df(3000, -3500, -1000), Color.Orange);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Cross2D3D(3000, -2500, -2500, Color.Red, 10, 10, 2));
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(3000, -3500, -1000), new Vector3Df(3000, -2500, 500), Color.Orange);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Cross2D3D(3000, -3500, -1000, Color.Red, 10, 10, 2));
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(3000, -2500, 500), new Vector3Df(3000, -3500, 2000), Color.Orange);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Cross2D3D(3000, -2500, 500, Color.Red, 10, 10, 2));
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Cross2D3D(3000, -3500, 2000, Color.Red, 10, 10, 2));

            //Moving cubes
            StaticCuboid redMovingCube = _mainDrawingControl.DrawingContext.Overlays3D.AddCuboid(300, 600, 300, Color.Red);
            StaticCuboid blueMovingCube = _mainDrawingControl.DrawingContext.Overlays3D.AddCuboid(300, 600, 300, Color.Blue);
            redMovingCube.Position = new Vector3Df(3000, -3000, 3000);
            blueMovingCube.Position = new Vector3Df(3000, -3000, 3500);
            new Task(() => cubeAnimator(redMovingCube, blueMovingCube)).Start();

            //Axis
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, 0, 5000), new Vector3Df(5100, 0, 5100), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Text2D3D("0", 5120, 60, 5120, Color.GreenYellow, FontSize.SmallSize));
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, 2500, 5000), new Vector3Df(5100, 2500, 5100), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Text2D3D("2500", 5120, 2560, 5120, Color.GreenYellow, FontSize.SmallSize));
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, 5000, 5000), new Vector3Df(5100, 5000, 5100), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Text2D3D("5000", 5120, 5060, 5120, Color.GreenYellow, FontSize.SmallSize));
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, -2500, 5000), new Vector3Df(5100, -2500, 5100), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Text2D3D("-2500", 5120, -2440, 5120, Color.GreenYellow, FontSize.SmallSize));
            _mainDrawingControl.DrawingContext.Overlays3D.AddLine(new Vector3Df(5000, -5000, 5000), new Vector3Df(5100, -5000, 5100), Color.Green);
            _mainDrawingControl.DrawingContext.Overlays3D.AddOverlay2D3D(new Text2D3D("-5000", 5120, -4940, 5120, Color.GreenYellow, FontSize.SmallSize));

            //Default value anyway
            _mainDrawingControl.DrawingContext.SpecularLightIntensity = 0.2f;

            //Release the scene
            _mainDrawingControl.DrawingContext.ReleaseScene();

            //Set the reset camera values
            _mainDrawingControl.DrawingContext.SetCameraResetTarget(bigBox, 15000);
            _mainDrawingControl.DrawingContext.SetCameraTarget(bigBox, 15000);
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void cubeAnimator(StaticCuboid red, StaticCuboid blue)
        {
            int sign = 1;
            while (_mainDrawingControl.DrawingContext.IsRunning)
            {
                red.Position = new Vector3Df(red.Position.X, red.Position.Y + (10 * sign), red.Position.Z);
                if (red.Position.Y <= -3500 || red.Position.Y >= -2500)
                    sign = -sign;
                blue.Position = new Vector3Df(blue.Position.X, blue.Position.Y - (10 * sign), blue.Position.Z);
                Thread.Sleep(25);
            }
        }
        #endregion

        #region Methods to create a randomized gaussian (coded to simulate a point cloud that could be obtained with cameras), it has pretty much nothing to do with the API

        class Gaussian2D
        {
            public float xc;
            public float yc;
            public float var;
            public float factor;
        }

        //Methods to create a randomized gaussian cloud point to simulate something that could be obtained with cameras
        private void GetGaussian(List<IrrlichtLime.Video.Vertex3D> vertices, List<uint> indices)
        {
            int csizex = 500;
            int csizey = 500;
            float[] cloud = null;
            cloud = new float[3 * csizex * csizey];
            Random random = new Random();
            List<Gaussian2D> gaussians = new List<Gaussian2D>();

            for (int i = 0; i < 100; ++i)
            {
                Gaussian2D gaussian = new Gaussian2D();
                gaussian.xc = (float)random.Next(-csizex / 2, csizex / 2);
                gaussian.yc = (float)random.Next(-csizey / 2, csizey / 2);
                gaussian.var = (float)random.Next(10, 16);//100
                gaussian.factor = (float)random.Next(50, 60);//100
                gaussians.Add(gaussian);
            }

            for (int x = -csizex / 2, index = 0; x < csizex / 2; ++x)
            {
                for (int y = -csizey / 2; y < csizey / 2; ++y, index += 3)
                {
                    if (false && random.NextDouble() < 0.1)
                    {
                        cloud[index + 0] = cloud[index + 1] = cloud[index + 2] = float.NaN;
                    }

                    else
                    {
                        cloud[index + 2] = 0f;

                        foreach (Gaussian2D gaussian in gaussians)
                        {
                            cloud[index + 2] += (float)(gaussian.factor * Math.Exp(-(double)((x - gaussian.xc) * (x - gaussian.xc) + (y - gaussian.yc) * (y - gaussian.yc)) / (2 * gaussian.var * gaussian.var)));
                        }

                        cloud[index + 0] = (float)x;
                        cloud[index + 1] = (float)y;
                    }
                }
                //To avoid Gauss generation taking too much CPU
                if (!_firstGauss && x % 5 == 0)
                    Thread.Sleep(1);
            }
            GetMapVertices(cloud, csizex, csizey, ref vertices, ref indices);
            if (_firstGauss)
                _firstGauss = false;
        }

        /// <summary>

        /// Convertion d'une couleur HSV vers RGB.

        /// </summary>

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);
            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));



            if (hi == 0) return Color.FromArgb(255, v, t, p);
            else if (hi == 1) return Color.FromArgb(255, q, v, p);
            else if (hi == 2) return Color.FromArgb(255, p, v, t);
            else if (hi == 3) return Color.FromArgb(255, p, q, v);
            else if (hi == 4) return Color.FromArgb(255, t, p, v);
            else return Color.FromArgb(255, v, p, q);
        } // ColorFromHSV  

        unsafe private void GetMapVertices(float[] pointsXYZ, int width, int height, ref List<IrrlichtLime.Video.Vertex3D> vertices, ref List<uint> indices)
        {
            uint[] tabindices = new uint[width * height];
            if (indices == null) indices = new List<uint>();
            if (vertices == null) vertices = new List<IrrlichtLime.Video.Vertex3D>();
            fixed (float* cloud = pointsXYZ)
            {
                // Recherche des extremas pour la gestion des fausses couleurs
                float zmin = float.MaxValue;
                float zmax = float.MinValue;
                {
                    float* pixel = cloud;
                    float* pend = pixel + 3 * width * height;
                    for (; pixel < pend; pixel += 3)
                    {
                        if (float.IsNaN(*(pixel + 2))) continue;
                        if (zmin > *(pixel + 2)) zmin = *(pixel + 2);
                        if (zmax < *(pixel + 2)) zmax = *(pixel + 2);
                    }
                }
                // Stockage des vertices
                {
                    int radius = 5;
                    float* row = cloud;
                    float* rend = row + 3 * width * height;
                    for (int pixindex = 0, pixrow = 0; row < rend; row += 3 * width, ++pixrow)
                    {
                        float* pixel = row;
                        float* cend = row + 3 * width;
                        for (int pixcol = 0; pixel < cend; pixel += 3, ++pixindex, ++pixcol)
                        {
                            tabindices[pixindex] = uint.MaxValue;
                            if (float.IsNaN(*pixel)) continue;
                            if (float.IsNaN(*(pixel + 1))) continue;
                            if (float.IsNaN(*(pixel + 2))) continue;
                            if ((pixrow <= radius) || (pixrow >= height - radius)) continue;
                            if ((pixcol <= radius) || (pixcol >= width - radius)) continue;

                            IrrlichtLime.Video.Vertex3D vertex = new IrrlichtLime.Video.Vertex3D(*(pixel + 0), *(pixel + 1), *(pixel + 2));
                            // Calcul de la couleur
                            float hue = 270f * (*(pixel + 2) - zmin) / (zmax - zmin);
                            System.Drawing.Color color = ColorFromHSV(hue, 1, 0.5);
                            vertex.Color = new IrrlichtLime.Video.Color(color.R, color.G, color.B);
                            // Calcul de la normale
                            double u1 = *(pixel - 3 * radius + 0) - *(pixel + 0);
                            double u2 = *(pixel - 3 * radius + 1) - *(pixel + 1);
                            double u3 = *(pixel - 3 * radius + 2) - *(pixel + 2);
                            double v1 = *(pixel - 3 * radius * width + 0) - *(pixel + 0);
                            double v2 = *(pixel - 3 * radius * width + 1) - *(pixel + 1);
                            double v3 = *(pixel - 3 * radius * width + 2) - *(pixel + 2);
                            double w1 = u2 * v3 - u3 * v2;
                            double w2 = u3 * v1 - u1 * v3;
                            double w3 = u1 * v2 - u2 * v1;
                            double norm = -Math.Sqrt(w1 * w1 + w2 * w2 + w3 * w3);
                            vertex.Normal = new Vector3Df((float)(w1 / norm), (float)(w2 / norm), (float)(w3 / norm));

                            tabindices[pixindex] = (uint)vertices.Count;
                            vertices.Add(vertex);
                            //Update the vertices instead of making a new Data3D
                            if (!_firstGauss && updateButton.Checked)
                            {
                                //Updating vertices can be done without blocking the scene
                                Data3D gauss = _mainDrawingControl.DrawingContext.Datas3D.GetByName("Gauss");
                                //This part does not affect performance
                                gauss.UpdateVertex(vertices.Count - 1, vertex);
                                _mainDrawingControl.DrawingContext.Refresh();
                            }
                        } // for col
                        //To avoid Gauss generation taking too much CPU
                        if (!_firstGauss && pixrow % 3 == 0)
                            Thread.Sleep(1);
                    } // for row
                }

                if (_firstGauss || !updateButton.Checked)
                {
                    // Stockage des indices
                    {
                        int index = 0;
                        float* row = cloud;
                        float* rend = row + 3 * width * height - 3 * width;
                        for (; row < rend; row += 3 * width)
                        {
                            float* col0 = row;
                            float* col1 = row + 3;
                            float* col2 = row + 3 * width;
                            float* col3 = row + 3 * width + 3;
                            float* cend = row + 3 * width - 3;

                            for (; col0 < cend; col0 += 3, col1 += 3, col2 += 3, col3 += 3, ++index)
                            {
                                // Les 2 points communs aux 2 triangles
                                if (tabindices[index + 0] == uint.MaxValue) continue;
                                if (tabindices[index + width + 1] == uint.MaxValue) continue;
                                // Triangle supérieur
                                if (tabindices[index + width] != uint.MaxValue)
                                {
                                    indices.Add(tabindices[index + 0]);
                                    indices.Add(tabindices[index + width]);
                                    indices.Add(tabindices[index + width + 1]);
                                }
                                // Triangle inférieur
                                if (tabindices[index + 1] != uint.MaxValue)
                                {
                                    indices.Add(tabindices[index + 0]);
                                    indices.Add(tabindices[index + 1]);
                                    indices.Add(tabindices[index + width + 1]);
                                }
                            } // for col
                            if (!_firstGauss && index % 3 == 0)
                                Thread.Sleep(1);
                        } // for row
                    }
                }
            } // fixed
        }

        #endregion

        #region Uses the previous methods to generate gaussian cloud points and refresh/add it to the scene
        //Generates a new gaussian using the gaussian methods
        private void UpdateGaussian(int x, int z, List<IrrlichtLime.Video.Vertex3D> vertices, List<uint> indices)
        {
            if (vertices.Count > 0)
            {
                if (updateButton.Checked)
                {
                    //Blocking the scene to recalculate the bounding box is not necessary either but it ensures the BB is correctly updated before being drawn
                    Data3D gauss = _mainDrawingControl.DrawingContext.Datas3D.GetByName("Gauss");
                    _mainDrawingControl.DrawingContext.BlockScene();
                    gauss.RecalculateBoundingBox();
                    _mainDrawingControl.DrawingContext.ReleaseScene();
                }
                //Remove the previous Data3D and make a new a one
                else
                {
                    Data3D oldGauss = _mainDrawingControl.DrawingContext.Datas3D.GetByName("Gauss");
                    //Blocking the scene isn't necessary either here but we can do it to ensure that the Gauss has both been deleted and created again before anything is drawn on the screen
                    _mainDrawingControl.DrawingContext.BlockScene();
                    //_mainDrawingControl.DrawingContext.BlockScene();
                    Data3D newGauss = _mainDrawingControl.DrawingContext.Datas3D.Add(vertices, indices, "Gauss");
                    newGauss.DrawBox = oldGauss.DrawBox;
                    newGauss.Rotation = oldGauss.Rotation;
                    newGauss.Position = oldGauss.Position;
                    _mainDrawingControl.DrawingContext.Datas3D.Remove(oldGauss);
                    _mainDrawingControl.DrawingContext.ReleaseScene();
                }
            }

            Data3D grip = _mainDrawingControl.DrawingContext.Datas3D.GetByName("Grip");
            grip.Position = new Vector3Df(x, grip.Position.Y, z);

            _mainDrawingControl.DrawingContext.Refresh();
        }
        //Generate a new gaussian
        private void GaussianGeneration(object sender, DoWorkEventArgs e)
        {
            vertices = new List<IrrlichtLime.Video.Vertex3D>();
            indices = new List<uint>();
            GetGaussian(vertices, indices);
        }

        //BackgroundWorker that will keep updating the gaussian
        BackgroundWorker gaussianGenerator = new BackgroundWorker();
        //Gaussian vertices&indices to be updated
        List<IrrlichtLime.Video.Vertex3D> vertices = new List<IrrlichtLime.Video.Vertex3D>();
        List<uint> indices = new List<uint>();
        private void GripAnimation(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();
            gaussianGenerator.DoWork += GaussianGeneration;
            while (_mainDrawingControl.DrawingContext.IsRunning)
            {
                //If a new gaussian has been generated then update it in the scene
                if (!gaussianGenerator.IsBusy && _mainDrawingControl.ViewMode == ViewMode._3D)
                {
                    UpdateGaussian(rand.Next(-250, 251), rand.Next(-250, 251), vertices.ToList(), indices.ToList());
                    gaussianGenerator.RunWorkerAsync();
                }
                Thread.Sleep(500);
            }
        }

        #endregion

        #region Button methods and 2D Camera capture/Camera simulation methods

        private void button4_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.SetCameraTarget(_mainDrawingControl.DrawingContext.Datas3D.GetByName("Skull"), 300);
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.SetCameraTarget(_mainDrawingControl.DrawingContext.Datas3D.GetByName("Maya"), 800);
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Gauss").RenderMode = RenderMode.PointCloud;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Gauss").RenderMode = RenderMode.Wireframe;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Skull").RenderMode = RenderMode.PointCloud;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Skull").RenderMode = RenderMode.Wireframe;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Skull").DrawNormals = true;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Skull").DrawNormals = false;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Might be null because we might be creating a new one
            Data3D target = _mainDrawingControl.DrawingContext.Datas3D.GetByName("Gauss");
            if (target != null)
                _mainDrawingControl.DrawingContext.SetCameraTarget(target, 500);
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Skull").RenderMode = RenderMode.Filled;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.Datas3D.GetByName("Gauss").RenderMode = RenderMode.Filled;
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Build3DScene();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.DisassembleOnMove = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.DisassembleOnMove = false;
        }

        private BackgroundWorker gripAnimator = new BackgroundWorker();
        private void button14_Click(object sender, EventArgs e)
        {
            if (!gripAnimator.IsBusy)
            {
                gripAnimator.DoWork += GripAnimation;
                gripAnimator.RunWorkerAsync();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            _mainDrawingControl.DrawingContext.SetCameraTarget(_mainDrawingControl.DrawingContext.Datas3D.GetByName("Face"), 2000);
            _mainDrawingControl.DrawingContext.Refresh();
        }

        private bool _isSimulating = false;
        private Mutex _simulationMutex = new Mutex();
        private BackgroundWorker cameraCapturer = new BackgroundWorker();
        private void CameraCapture(object sender, DoWorkEventArgs e)
        {
            VideoCapture cameraCapture = new VideoCapture();
            BackgroundSubtractor fgDetector;
            Emgu.CV.Cvb.CvBlobDetector blobDetector;
            Emgu.CV.Cvb.CvTracks tracker;

            fgDetector = new Emgu.CV.VideoSurveillance.BackgroundSubtractorMOG2();
            blobDetector = new CvBlobDetector();
            tracker = new CvTracks();

            while (_mainDrawingControl.DrawingContext.IsRunning)
            {
                if (_mainDrawingControl.ViewMode == ViewMode._2D && !_isSimulating)
                {
                    _simulationMutex.WaitOne();
                    Mat frame = cameraCapture.QueryFrame();
                    Mat smoothedFrame = new Mat();
                    CvInvoke.GaussianBlur(frame, smoothedFrame, new Size(3, 3), 1); //filter out noises
                                                                                    //frame._SmoothGaussian(3); 

                    #region use the BG/FG detector to find the forground mask
                    Mat forgroundMask = new Mat();
                    fgDetector.Apply(smoothedFrame, forgroundMask);
                    #endregion

                    CvBlobs blobs = new CvBlobs();
                    blobDetector.Detect(forgroundMask.ToImage<Gray, byte>(), blobs);
                    blobs.FilterByArea(100, int.MaxValue);

                    float scale = (frame.Width + frame.Width) / 2.0f;
                    tracker.Update(blobs, 0.01 * scale, 5, 5);

                    foreach (var pair in tracker)
                    {
                        CvTrack b = pair.Value;
                        //Adding overlays
                        if (apiOverlaysButton.Checked)
                        {
                            //Display API overlays
                            _mainDrawingControl.DrawingContext.Overlays2D.Add(new MulDisplay.Components2D.Rectangle(b.BoundingBox.X, b.BoundingBox.Y, Color.White, b.BoundingBox.Width, b.BoundingBox.Height, 2));
                            _mainDrawingControl.DrawingContext.Overlays2D.Add(new TextPanel(b.Id.ToString(), (float)b.Centroid.X, (float)b.Centroid.Y, Color.White, Color.White, 0, 255, "", 0.75f));
                        }
                        else
                        {
                            //The original OpenCV overlays
                            CvInvoke.Rectangle(frame, b.BoundingBox, new MCvScalar(255.0, 255.0, 255.0), 2);
                            CvInvoke.PutText(frame, b.Id.ToString(), new Point((int)Math.Round(b.Centroid.X), (int)Math.Round(b.Centroid.Y)), FontFace.HersheyPlain, 1.0, new MCvScalar(255.0, 255.0, 255.0));
                        }
                    }

                    //If the movement tracker is empty
                    if (tracker.Keys.Count <= 1)
                    {
                        _mainDrawingControl.DrawingContext.Overlays2D.Add(new TextPanel("Try to move :)", 0, 0, Color.Yellow, Color.Yellow, 0, 255, "MovePanel", 1.2f, -1, false));
                        _mainDrawingControl.DrawingContext.Overlays2D.GetByName("MovePanel").Attribute = "The move panel !";
                    }

                    //Turning off the automatic removing of overlays on new image because we had to do the processing on the frame before copying it (to show OpenCV overlays) and we added our overlays at the same time (because we're lazy) so we don't want to remove them
                    _mainDrawingControl.DrawingContext.RemoveOverlaysOnNewImage = false;
                    //Refreshing the image, the bitmap has to be a new Bitmap to avoid issues between OpenCV and the DisplayAPI
                    _mainDrawingControl.DrawingContext.SetBackgroundImage(new Bitmap(frame.Bitmap));

                    //Turning it back on
                    _mainDrawingControl.DrawingContext.RemoveOverlaysOnNewImage = true;
                    _mainDrawingControl.DrawingContext.BuildAndRefresh();
                    //Removing all overlays now that the frame was built so that we won't keep them on the next frame
                    _mainDrawingControl.DrawingContext.Overlays2D.RemoveAll();

                    //Disposes all the Emgu objects
                    frame.Dispose();
                    smoothedFrame.Dispose();
                    forgroundMask.Dispose();
                    blobs.Dispose();

                    _simulationMutex.ReleaseMutex();
                }
                else
                {
                    Thread.Sleep(500);
                }

            }
            cameraCapture.Dispose();
        }

        //Returns a red circle with a cross inside and a message
        private List<Overlay2D> GetRandomRedCircle(int xmin, int xmax, int ymin, int ymax, string text)
        {
            Random rand = new Random();
            int x = rand.Next(xmin, xmax);
            int y = rand.Next(ymin, ymax);

            List<Overlay2D> redCircle = new List<Overlay2D>
            {
                new Circle(x, y, Color.Red, 40, 40, 128),
                new Cross(x, y, Color.Yellow, 15, 15, 5),
                new TextPanel(text, x, y, Color.Red, Color.Black, 255, 255, "", 1, -1, false)
            };

            return redCircle;
        }

        private BackgroundWorker cameraSimulator = new BackgroundWorker();
        private void CameraSimulation(object sender, DoWorkEventArgs e)
        {
            //Load all the pictures
            string[] imgPaths;
            imgPaths = Directory.GetFiles("Media/animated_hand", @"*.jpg");

            Bitmap[] images = new Bitmap[imgPaths.Length];
            for (int i = 0; i < imgPaths.Length; i++)
            {
                images[i] = new Bitmap(imgPaths[i]);
            }

            //Simulates a camera
            int count = 0;
            while (_mainDrawingControl.DrawingContext.IsRunning)
            {
                List<Overlay2D> every25frameCircle = GetRandomRedCircle(350, 1000, 100, 600, "Every 25 frame");
                if (_mainDrawingControl.ViewMode == ViewMode._2D && _isSimulating)
                {
                    _simulationMutex.WaitOne();
                    for (int i = 0; i < images.Length; i++)
                    {
                        if (!_isSimulating)
                            break;
                        //The pictures are cloned because the display api always calls dispose
                        _mainDrawingControl.DrawingContext.SetBackgroundImage((Bitmap)images[i].Clone());
                        //Purple crosses
                        _mainDrawingControl.DrawingContext.Overlays2D.Add(new Cross(350, 100, Color.Purple, 100, 100, 5));
                        _mainDrawingControl.DrawingContext.Overlays2D.Add(new Cross(1000, 100, Color.Purple, 100, 100, 5));
                        _mainDrawingControl.DrawingContext.Overlays2D.Add(new Cross(350, 600, Color.Purple, 100, 100, 5));
                        _mainDrawingControl.DrawingContext.Overlays2D.Add(new Cross(1000, 600, Color.Purple, 100, 100, 5));
                        //Random red circles
                        if (count == 25)
                        {
                            every25frameCircle = GetRandomRedCircle(350, 1000, 100, 600, "Every 25 frame");
                            count = 0;
                        }
                        else
                        {
                            count++;
                        }
                        //Every frame red circle
                        _mainDrawingControl.DrawingContext.Overlays2D.Add(every25frameCircle);
                        _mainDrawingControl.DrawingContext.Overlays2D.Add(GetRandomRedCircle(350, 1000, 100, 600, "Every frame"));
                        _mainDrawingControl.DrawingContext.BuildAndRefresh();
                        _mainDrawingControl.DrawingContext.LimitFPS = false;
                    }
                    _simulationMutex.ReleaseMutex();
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!cameraSimulator.IsBusy)
            {
                _mainDrawingControl.ViewMode = ViewMode._2D;
                cameraSimulator.DoWork += CameraSimulation;
                cameraSimulator.RunWorkerAsync();
            }
            _isSimulating = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!cameraCapturer.IsBusy)
            {
                _mainDrawingControl.ViewMode = ViewMode._2D;
                cameraCapturer.DoWork += CameraCapture;
                cameraCapturer.RunWorkerAsync();
            }
            _isSimulating = false;
        }
        #endregion
    }
}
