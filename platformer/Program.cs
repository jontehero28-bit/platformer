global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(1200, 400, "Vinterprojekt");
Raylib.SetTargetFPS(60);

Texture2D ninja = Raylib.LoadTexture("ninja.png");

Rectangle player = new Rectangle(50, 320, ninja.width, -ninja.height);

List<Obstacle> Obstacles = new List<Obstacle>();
List<Rectangle> projectiles  = new List<Rectangle>();

float speed = 5f;
int groundY = 320;
int roofY = 0;
int timer = 0;
int spawnTime = 2*60;
int obstaclePosition = 0;

Boolean dead = false; //if dead = true game is over.
Boolean jump = false; //ifall jump är false, man kan hoppa
string currentScene = "start"; //scenes start, game, end


//_________________________________________________________________

while(Raylib.WindowShouldClose() == false)
{
    //logik__________________________________________________________
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

        if   (Raylib.IsKeyPressed(KeyboardKey.KEY_UP) || Raylib.IsKeyPressed(KeyboardKey.KEY_W))
        {
            if (jump == false)
            {
                player.y = roofY;
                jump = true;
            }

                if (player.y == roofY)
                {
                    jump = false;
                }
        }
        else if   (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN) || Raylib.IsKeyPressed(KeyboardKey.KEY_S))
        {
            if (jump == false)
            {
                player.y = groundY;
                jump = true;
            }
            if (player.y == groundY)   
            {
                jump = false;
            } 
        } //__________________________________________________________________
        
        if (player.x > 1200 - player.width)//gör så jag kan inte gå itanför spelet.
        {
            player.x = 1200 - player.width;
        }
        else if (player.x < 0)
        {
            player.x = 0;
        } //------------------------------------------------------------------ 

        timer++;
        if (timer == spawnTime)
        {
            Obstacles.Add(new Obstacle(1200 - 70, obstaclePosition));//placerar ut obstacles.
            if (obstaclePosition == 200)
            {
                obstaclePosition = 0;
            }
            else
            {
            obstaclePosition += 200;
            }
            spawnTime += 1*60;
        }

        foreach (Obstacle o in Obstacles)//raderar obstacles när de går utanför scenen.
        {
            o.Update();
        }
        Obstacles.RemoveAll(o => o.obstacle.x < 0);
        //________________________________________________
        
        

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

    //grafik_________________________________________________________________

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "game")
    {
        Raylib.DrawTexture(ninja, (int)player.x, (int)player.y, Color.WHITE);
        
        foreach (Obstacle o in Obstacles)
        {
            o.Draw();
        }
    }

    else if (currentScene == "start")
    {
        Raylib.DrawText("Welcome to Dumb Ninja. In this game you play as a dumb Ninja", 200, 100, 32, Color.BLACK);
        Raylib.DrawText("Press ENTER to start", 250, 300, 32, Color.BLACK);
        
    }
    else if (currentScene == "end")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText("GAME OVER", 350, 300, 32, Color.BLACK);
        Raylib.DrawText("Press ENTER to play again", 300, 400, 32, Color.BLACK);
    }

    Raylib.EndDrawing();
}