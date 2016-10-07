using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Ex2
{
    class Global
    {
        public static ContentManager _Content;
        public static MouseManagement _MouseManagement = new MouseManagement();
        public static TextureManagement _TextureManagement = new TextureManagement();
    }
}
