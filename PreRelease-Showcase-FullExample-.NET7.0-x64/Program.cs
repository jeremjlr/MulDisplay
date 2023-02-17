// MurphyDisplay is a .NET Core 7 all in one (2D/3D) display API designed as a debugging/display tool.
// It can be used to easily display camera frames, 3D point clouds, 3D objects, 2D/3D overlays, etc..
// Copyright (C) 2022 Jérémy LEPROU jerem.jlr@gmail.com

namespace FullExample
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FullExampleForm());
        }
    }
}
