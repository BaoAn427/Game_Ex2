using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Ex2
{
    class Global
    {
        public static ContentManager _Content;
        private static MouseManagement _MouseManagement = new MouseManagement();
        private static TextureManagement _TextureManagement = new TextureManagement();

        public static Camera2D _Camera = new Camera2D();
        private static bool _bDrag = false;
        private static bool _bFloat = false;

        private static Vector2 _DifferenceVector;
        private static Vector2 _BackupDifferenceVector;

        private static Vector2 _Velocity_Zero;
        private static Vector2 _Accelerator;
        private static float _K1 = 1;
        private static float _K2 = 0.05f;
        private static float _Epsilon = 0.01f;
        private static float _ScaleFactor = 1;
        private static float _ScaleFactor_ZoomIn_Ratio = 0.5f;
        private static float _ScaleFactor_ZoomOut_Ratio = 2f;

        //------------------------------ MOUSE STATE ------------------------------

        public static bool Is_LeftMouse_Click_Begin()
        {
            return _MouseManagement.Is_LeftClickBegin();
        }

        public static bool Is_LeftMouse_Click_End()
        {
            return _MouseManagement.Is_LeftClickEnd();
        }

        public static bool Is_LeftMouse_Pressed()
        {
            return _MouseManagement.Is_LeftPressed();
        }


        public static bool Is_Scroll_Up()
        {
            return _MouseManagement.Is_ScrollUp();
        }

        public static bool Is_Scroll_Down()
        {
            return _MouseManagement.Is_ScrollDown();
        }


        //------------------------------ DRAG ------------------------------

        public static bool IsDragging()
        {
            return _bDrag;
        }

        public static void BeginDragging()
        {
            _bDrag = true;
        }

        public static void Drag()
        {
            _DifferenceVector = _MouseManagement.GetMousePositionDifference();
            _TextureManagement.TranslateBaseMap(_Camera, _DifferenceVector);
        }

        public static void EndDragging()
        {
            _DifferenceVector = _MouseManagement.GetMousePositionDifference();
            _TextureManagement.TranslateBaseMap(_Camera, _DifferenceVector);
            _BackupDifferenceVector = _DifferenceVector;
            _bDrag = false;
        }


        //------------------------------ FLOAT ------------------------------

        public static bool IsFloating()
        {
            return _bFloat;
        }

        public static void BeginFloating()
        {
            _Velocity_Zero = _K1 * _DifferenceVector;
            _Accelerator = -_K2 * _Velocity_Zero;
            _bFloat = true;       
        }

        public static void NotFloatedYet()
        {
            _bFloat = false;
        }

        public static void EndFloating()
        {
            _DifferenceVector = _Velocity_Zero;
            _TextureManagement.TranslateBaseMap(_Camera, _DifferenceVector);
            _Velocity_Zero += _Accelerator;
            if(IsEpsilon())
                _bFloat = false;
        }
        
        private static bool IsEpsilon()
        {
            return _Velocity_Zero.Length() <= _Epsilon;
        }


        //------------------------------ ZOOM ------------------------------

        public static void ZoomIn()
        {
            Vector2 center = new Vector2(_MouseManagement.GetCurrentX(), _MouseManagement.GetCurrentY());
            _ScaleFactor *= _ScaleFactor_ZoomIn_Ratio;
            _TextureManagement.ZoomBaseMap(_Camera, center, _ScaleFactor);
        }

        public static void ZoomOut()
        {
            Vector2 center = new Vector2(_MouseManagement.GetCurrentX(), _MouseManagement.GetCurrentY());
            _ScaleFactor *= _ScaleFactor_ZoomOut_Ratio;
            _TextureManagement.ZoomBaseMap(_Camera, center, _ScaleFactor);
        }


        //------------------------------ GENERAL ------------------------------

        public static void LoadTilingMap()
        {
            _TextureManagement.LoadTilingMap("BaseMap02");
            _Camera._RotZ = 0;
        }

        public static void UpdateEntityInvisible(GameTime gameTime)
        {
            _Camera.Update(gameTime);
            _MouseManagement.Update(gameTime);
        }

        public static void UpdateEntityVisible(GameTime gameTime)
        {
            _TextureManagement.UpdateTexture(gameTime);
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _TextureManagement.DrawTexture(gameTime, spriteBatch);
        }
    }
}
