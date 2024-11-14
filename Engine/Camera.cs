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
        public Point WorldSize;
        public Point WindowSize;
        public Point DefaultWindowSize;
        public Point DefaultWorldSize;
        private Camera() {

            DefaultWindowSize = new Point(1022, 586);
            DefaultWorldSize = new Point(1440, 825);
            WindowSize = DefaultWindowSize;
            WorldSize = DefaultWorldSize;
            cameraView = new Rectangle((int)cameraPosition.X, (int)cameraPosition.Y, WindowSize.X, WindowSize.Y);
            

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
