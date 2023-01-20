using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 800, "Vinterprojekt");
Raylib.SetTargetFPS(60);

string currentScene = "start"; //scenes start, game, end

while(Raylib.WindowShouldClose() == false)
{
    //logik
    if(currentScene == "game")
    {

    }

    else if (currentScene == "start")
    {

    }

    //grafik

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "game")
    {

    }

    else if (currentScene == "start")
    {
        Raylib.DrawText("Press ENTER to start", 250, 370, 32, Color.BLACK);
    }
    else if (currentScene == "end")
    {
        Raylib.DrawText("GAME OVER", 350, 370, 32, Color.BLACK);
    }

    Raylib.EndDrawing();
}

Console.WriteLine("Hello, World!");