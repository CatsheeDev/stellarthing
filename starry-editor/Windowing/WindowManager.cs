using ImGuiNET;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;

namespace StarryEditor.Windowing
{
    public class WindowManager
    {
        //fuck off c#
#pragma warning disable CS8618
        private IWindow MainWindow;
        private ImGuiController MainUIController;
        private IInputContext UIInput;

        private GL OpenGL;
        private ImGuiIOPtr IO;
#pragma warning restore CS8618

        /// <summary>
        /// INTERNAL USE ONLY!!!! Use Time.DeltaTime
        /// </summary>
        public float DeltaTime; 

        public void CreateWindow()
        {
            MainWindow = Window.Create(WindowOptions.Default with
            {
                Title = "Starry Editor",
                UpdatesPerSecond = 60,
                WindowState = WindowState.Maximized,
            });

            MainWindow.Load += () =>
            {
                MainUIController = new ImGuiController(
                    OpenGL = MainWindow.CreateOpenGL(),
                    MainWindow,
                    UIInput = MainWindow.CreateInput()
                );

                IO = ImGui.GetIO();
                IO.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard | ImGuiConfigFlags.ViewportsEnable | ImGuiConfigFlags.DpiEnableScaleViewports | ImGuiConfigFlags.DockingEnable;
            };

            MainWindow.FramebufferResize += s =>
            {
                OpenGL.Viewport(s);
            };

            MainWindow.Render += (dt) =>
            {
                DeltaTime = (float)dt;
                MainUIController?.Update(DeltaTime);

                OpenGL?.ClearColor(0, 0, 0, 0);
                OpenGL?.Clear((uint)ClearBufferMask.ColorBufferBit);

                UpdateWindows();
                MainUIController?.Render();
            };

            MainWindow.Closing += () =>
            {
                MainUIController?.Dispose();
            };

            MainWindow.Run();
        }

        private void UpdateWindows()
        {
            //note to self do magic shit later yawn 
            MainUIController.Render();
        }
    }
}
