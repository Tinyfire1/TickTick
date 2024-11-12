using System;
using Microsoft.Xna.Framework;
using Engine;

class SlowModifier : SpriteGameObject
{
    Level level;
    protected float bounce;
    Vector2 startPosition;
    int counter = 0;
    bool SlowDownActive = false;
    bool Activated = false;
    

    public SlowModifier(Level level, Vector2 startPosition) : base("Sprites/LevelObjects/Modifiers/spr_SLOW", TickTick.Depth_LevelObjects)
    {
        this.level = level;
        this.startPosition = startPosition;
        SetOriginToCenter();
        Reset();
    }

    public void speedModifier(Player player)
    {
        Activated = true;
        if (!SlowDownActive)
        {
            player.walkingSpeed -= 300f;
            SlowDownActive = true;
            counter = 0;
        }
        
    }

    public void Checkmodifier(GameTime gameTime, Player player)
    {
        counter += gameTime.ElapsedGameTime.Milliseconds;

        if (SlowDownActive && counter >= 1000)
        {
            player.walkingSpeed += 300f;
            SlowDownActive = false;
            counter = 0;
            Activated = false;
        }
    }
    

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        double t = gameTime.TotalGameTime.TotalSeconds * 3.0f + LocalPosition.X;
        bounce = (float)Math.Sin(t) * 0.2f;
        localPosition.Y += bounce;

        // check if the player collects this water drop
        if (Visible && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player))
        {
            speedModifier(level.Player);
            Visible = false;
            ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_watercollected");
        }

        if (Activated)
        {
            Checkmodifier(gameTime, level.Player);
        }
        
    }

    public override void Reset()
    {
        localPosition = startPosition;
        Visible = true;
    }
}