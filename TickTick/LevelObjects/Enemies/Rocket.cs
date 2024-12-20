﻿using System.Diagnostics;
using Engine;
using Microsoft.Xna.Framework;

/// <summary>
/// Represents a rocket enemy that flies horizontally through the screen.
/// </summary>
class Rocket : AnimatedGameObject
{
    Level level;
    Vector2 startPosition;
    const float speed = 500;

    public Rocket(Level level, Vector2 startPosition, bool facingLeft) 
        : base(TickTick.Depth_LevelObjects)
    {
        this.level = level;

        LoadAnimation("Sprites/LevelObjects/Rocket/spr_rocket@3", "rocket", true, 0.1f);
        PlayAnimation("rocket");
        SetOriginToCenter();

        sprite.Mirror = facingLeft;
        if (sprite.Mirror)
        {
            velocity.X = -speed;
            this.startPosition = startPosition + new Vector2(2*speed, 0);
        }
        else
        {
            velocity.X = speed;
            this.startPosition = startPosition - new Vector2(2 * speed, 0);
        }
        Reset();
    }

    public override void Reset()
    {
        // go back to the starting position
        LocalPosition = startPosition;
        Visible = true;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        // if the rocket has left the screen, reset it
        if (sprite.Mirror && BoundingBox.Right < level.BoundingBox.Left)
            Reset();
        else if (!sprite.Mirror && BoundingBox.Left > level.BoundingBox.Right)
            Reset();
        
        // check if the player jumps on the rocket
        if (Visible && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player) )
        {
            if (IsHitFromTop(level.Player))
            {
                Visible = false;
                ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_watercollected");
            }
        }

        // if the rocket touches the player, the player dies
        if (Visible && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player))
            if (!IsHitFromTop(level.Player))
            {
                level.Player.Die();
            }
    }
}
