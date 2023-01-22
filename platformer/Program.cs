using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1200, 900, "Vinterprojekt");
Raylib.SetTargetFPS(60);

Texture2D ninja = Raylib.LoadTexture("ninja.png");

Rectangle player = new Rectangle(0, 820, ninja.width, ninja.height);

float speed = 5f;
string currentScene = "start"; //scenes start, game, end

while(Raylib.WindowShouldClose() == false)
{
    //logik
    if(currentScene == "game")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)  || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            player.x += speed * 2;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            player.x -= speed * 2;
        }

    }

    else if (currentScene == "start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }

    else if (currentScene == "end")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }

    //grafik

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "game")
    {
        Raylib.DrawTexture(ninja, (int)player.x, (int)player.y, Color.WHITE);
    }

    else if (currentScene == "start")
    {
        Raylib.DrawText("Welcome to Dumb Ninja. In this game you play as a dumb Ninja", 100, 200, 32, Color.BLACK);
        Raylib.DrawText("Press ENTER to start", 250, 370, 32, Color.BLACK);
    }
    else if (currentScene == "end")
    {
        Raylib.DrawText("GAME OVER", 350, 300, 32, Color.BLACK);
        Raylib.DrawText("Press ENTER to play again", 300, 400, 32, Color.BLACK);
    }

    Raylib.EndDrawing();
}