using System;
using System.Collections.Generic;

using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Engine
{
    public class Camera
    {
        public Vector2 cameraPosition;
        public Rectangle cameraView;
        private static Camera instance;
        private Camera() {
            cameraView = new Rectangle((int)cameraPosition.X, (int)cameraPosition.Y, 1424, 1424);
        }
        // Public static method to get the singleton instance
        public static Camera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Camera();
                }
                return instance;
            }
        }
    }
}
