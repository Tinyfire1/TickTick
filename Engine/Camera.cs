using System;
using System.Collections.Generic;

using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camera
    {
        public Vector2 cameraPosition = new Vector2(200, 0);
        public Rectangle cameraView;
        public void Camera1() {
            cameraView = new Rectangle((int)cameraPosition.X, (int)cameraPosition.Y, 1424, 1424);
        }
    }
}
