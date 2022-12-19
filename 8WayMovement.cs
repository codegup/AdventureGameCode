using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export] public int speed = 200;
	public Vector2 position = new Vector2();
	private AnimatedSprite advMan;

	public void getInput()
	{
		position = new Vector2();

		bool move_Right = Input.IsActionPressed("ui_right");
		bool move_Left = Input.IsActionPressed("ui_left");
		bool move_Up = Input.IsActionPressed("ui_up");
		bool move_Down = Input.IsActionPressed("ui_down");
		GD.Print("RIGHT: " + move_Right);
		GD.Print("DOWN: " + move_Down);


		if (move_Right && move_Up)
		{
			position.x += 1;
			position.y += -1;
			advMan.FlipH = false;
			advMan.Play("run");
		}
		else if (move_Right && move_Down)
		{
			position.x += 1;
			position.y += 1;
			advMan.FlipH = false;
			advMan.Play("run");
		}
		else if (move_Left && move_Up)
		{
			position.x += -1;
			position.y += -1;
			advMan.FlipH = true;
			advMan.Play("run");

		}
		else if (move_Left && move_Down)
		{
			position.x += -1;
			position.y += 1;
			advMan.FlipH = true;

		}
		else if (move_Down)
		{
			position.y += 1;
			advMan.Play("run");

		}
		else if (move_Right)
		{
			position.x += 1;
			advMan.FlipH = false;
			advMan.Play("run");

		} else if (move_Left) {
			position.x += -1;
			advMan.FlipH = true;
			advMan.Play("run");
		} else if (move_Up) {
			position.y += -1;
			advMan.Play("run");
		}
		else
		{
			advMan.Play("idle");
		}


		position = position.Normalized();

		position = position.Normalized() * speed;


	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		advMan = GetNode<AnimatedSprite>("adventureMan");

	}
	public override void _PhysicsProcess(float delta)
	{
		getInput();
		position = MoveAndSlide(position);

		var axisX = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		var axisY = Input.GetActionStrength("ui_up") - Input.GetActionStrength("ui_down");

		GD.Print("CURRENT POSITION: " + "(" + axisX + "," + axisY + ")");

	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }

}
