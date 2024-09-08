using ImGuiNET;
using Silk.NET.GLFW;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.SDL;
using Silk.NET.Windowing;
using System;
using System.Numerics;
using Vortice.Mathematics;

unsafe class Program
{
    private static Glfw glfw;
    private static GL? _gl = null;
    private static IInputContext? _input;
    private static float _delta;
    private static IWindow? _window;

    private static ImGuiController imguiController;

    private static ImGuiIOPtr IO;

    static void Main(string[] args)
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

    protected static void OnUpdate()
    {
        ImGui.Begin("Window A");
        ImGui.Text("This is Window A");
        ImGui.End();

        ImGui.Begin("Window B");
        ImGui.Text("This is Window B");
        ImGui.End();

        imguiController?.Render();
    }
}
