public class Obstacle

{
    public Rectangle obstacle;
    int obstacleSpeed = 15;
    public Obstacle(int obstacleX, int obstacleY)
    {
         obstacle = new Rectangle(obstacleX, obstacleY, 70, 200);
    }

    public void Update()
    {
        obstacle.x -= obstacleSpeed;
    }
    public void Draw()
    {
        Raylib.DrawRectangle((int)obstacle.x, (int)obstacle.y, (int)obstacle.width, (int)obstacle.height, Color.BLACK);

    }
}
