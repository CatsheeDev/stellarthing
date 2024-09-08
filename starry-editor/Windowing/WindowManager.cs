using ImGuiNET;
using Silk.NET.Windowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryEditor.Windowing
{
    public class WindowManager
    {
        private static IWindow? _window;

        public static void CreateWindow()
        {
            _window = Silk.NET.Windowing.Window.Create(WindowOptions.Default with
            {
                Title = "Starry Editor",
                UpdatesPerSecond = 60,
                WindowState = WindowState.Maximized,
            });

            _window.Load += () =>
            {
                imguiController = new ImGuiController(
                    _gl = _window.CreateOpenGL(),
                    _window,
                    _input = _window.CreateInput()
                );

                IO = ImGui.GetIO();
                IO.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard | ImGuiConfigFlags.ViewportsEnable | ImGuiConfigFlags.DpiEnableScaleViewports | ImGuiConfigFlags.DockingEnable;
            };

            _window.FramebufferResize += s =>
            {
                _gl.Viewport(s);
            };

            _window.Render += (dt) =>
            {
                _delta = (float)dt;
                imguiController?.Update(_delta);

                _gl?.ClearColor(0, 0, 0, 0);
                _gl?.Clear((uint)ClearBufferMask.ColorBufferBit);

                OnUpdate();
                imguiController?.Render();
            };

            _window.Closing += () =>
            {
                imguiController?.Dispose();
            };

            _window.Run();
        }
    }
}
