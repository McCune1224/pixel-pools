using Godot;
using System;

public partial class Main : Node
{
    [Export] PackedScene BallScene;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Resource[] ballImages = new Resource[17];

        for (int i = 0; i < 17; i++)
        {
            ballImages[i] = GD.Load($"res://assets/aesprites/ball1.svg");
        }
        NewGame(ballImages);
    }

    public void NewGame(Resource[] ballImages)
    {
        GenerateBalls(ballImages);
    }




    public void GenerateBalls(Resource[] ballImages)
    {
        int currBallIndex = 0;
        int diag = 24;
        int rows = 5;
        for (int cols = 0; cols < 5; cols++)
        {
            for (int i = 0; i < rows; i++)
            {
                var b = BallScene.Instantiate<RigidBody2D>();
                this.AddChild(b);
                // Vector2 spawnPos = new Vector2(250 + (cols * (diagOffest)), 267 + (rows * ((diagOffest))));
                Vector2 spawnPos = new Vector2(400 + (cols * diag), 350 + rows);
                b.Position = spawnPos;

                //FIXME: Dynamic Sprite/Texture Loading... [ball 1, ball 2....]
                // var t = b.GetNode<Sprite2D>("res://assets/aesprites/template_ball.svg");
                currBallIndex++;
            }
            rows--;
        }

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
