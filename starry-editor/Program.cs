using ImGuiNET;
using Silk.NET.GLFW;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.SDL;
using Silk.NET.Windowing;
using StarryEditor.Windowing;
using System;
using System.Numerics;
using Vortice.Mathematics;

public class Program
{
#pragma warning disable CS8618
    public static WindowManager MainWindow { get; private set; }
#pragma warning restore CS8618

    static void Main(string[] args)
    {
        //setup window 
        MainWindow = new WindowManager();
        MainWindow.CreateWindow(); 
    }

}
