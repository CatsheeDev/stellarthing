using ImGuiNET;
using ClickableTransparentOverlay;
using System.Numerics; 

namespace Starry.Editor;

public class Program : Overlay
{
    bool check = false;
    int fuckoff = 0;
    string bbbbbbb = string.Empty; 

    protected override void Render()
    {
        ImGui.Begin("Starry Editor");
        ImGui.Text("i hate you"); 
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Editor"); 
        Program editor = new Program();

        editor.Start().Wait();
    }
}