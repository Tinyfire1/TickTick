using System;
using Microsoft.Xna.Framework;
using Engine;

class NoDieModifier : SpriteGameObject
{
    Level level;
    protected float bounce;
    Vector2 startPosition;
    int counter = 0;
    public static bool ImmActive = false;
    bool Activated = false;
    private bool Touchable = true;

    public NoDieModifier(Level level, Vector2 startPosition) : base("Sprites/LevelObjects/Modifiers/spr_Immune", TickTick.Depth_LevelObjects)
    {
        this.level = level;
        this.startPosition = startPosition;
        SetOriginToCenter();
        Reset();
    }

    public void Immune()
    {
        Activated = true;
        if (!ImmActive)
        {
            ImmActive = true;
            counter = 0;
        }
        
    }

    public void Checkmodifier(GameTime gameTime, Player player)
    {
        counter += gameTime.ElapsedGameTime.Milliseconds;

        if (ImmActive && counter >= 5000)
        {
            ImmActive = false;
            counter = 0;
            Activated = false;
            Visible = false;
        }
    }
    

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        double t = gameTime.TotalGameTime.TotalSeconds * 3.0f + LocalPosition.X;
        bounce = (float)Math.Sin(t) * 0.2f;
        localPosition.Y += bounce;

        // check if the player collects this water drop
        if (Touchable && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player))
        {
            Immune();
            Touchable = false;
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
        Touchable = true;
    }
}