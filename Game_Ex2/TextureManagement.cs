using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Game_Ex2
{
    public class TextureManagement : GameEntity
    {
        //public ContentManager _Content;

        private List<EntityVisible> _lMapSrite = new List<EntityVisible>();
        private TextureChompChomp _ChompChomp;
        private const int _SIDE_SQUARE_MAP = 64;
        private const int _HEIGHT_WATER = 0;
        private const int _HEIGHT_ICE = 122;
        private const int _HEIGHT_HIGHLAND = 131;
        private const int _HEIGHT_GRASS = 222;        

        public static int GetSideSquareMap()
        {
            return _SIDE_SQUARE_MAP;
        }

        public static List<Texture2D> LoadTextureForScrollingMap(string strResourceName)
        {
            List<Texture2D> lTexture = new List<Texture2D>();
            lTexture.Add(Global._Content.Load<Texture2D>(strResourceName));
            return lTexture;
        }


        public static List<Texture2D> LoadTextureForTilingMap(int height)
        {
            List<Texture2D> lTexture = new List<Texture2D>();
            string strResourceName = "Grass";

            if (height < _HEIGHT_ICE)
                strResourceName = "Water";
            else if (height < _HEIGHT_HIGHLAND)
                strResourceName = "Ice";
            else if (height < _HEIGHT_GRASS)
                strResourceName = "Highland";

            lTexture.Add(Global._Content.Load<Texture2D>(strResourceName));
            return lTexture;
        }


        public static Texture2D GetBaseMap(string strBaseMap)
        {
            return Global._Content.Load<Texture2D>(strBaseMap);
        }


        public void LoadTilingMap(string strBaseMap)
        {
            float scale = 1f;
            MapTiling mapTiling = new MapTiling(strBaseMap, 0, 0, _SIDE_SQUARE_MAP, _SIDE_SQUARE_MAP, scale);
            _lMapSrite.Add(mapTiling);
            TextureChompChomp ChompChomp = new TextureChompChomp(4, 1, 0, 0);
            _lMapSrite.Add(ChompChomp);
            _ChompChomp = ChompChomp;
        }

        public void DrawTexture(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int n = _lMapSrite.Count;
            for (int i = 0; i < n; ++i)
                _lMapSrite[i].Draw(gameTime, spriteBatch);
        }


        public void UpdateTexture(GameTime gameTime)
        {
            int n = _lMapSrite.Count;
            for (int i = 0; i < n; ++i)
                _lMapSrite[i].Update(gameTime);
        }


        public void TranslateBaseMap(Camera2D camera, Vector2 vector)
        {
            ((MapTiling)_lMapSrite[0]).Translate(camera, vector);
        }

        public void ZoomBaseMap(Camera2D camera, Vector2 center, float scaleFactor)
        {
            ((MapTiling)_lMapSrite[0]).Zoom(camera, center, scaleFactor);
        }


        public void MoveToLeft()
        {
            _ChompChomp.MoveToLeft();
        }

        public void MoveToRight()
        {
            _ChompChomp.MoveToRight();
        }

        public void MoveToUp()
        {
            _ChompChomp.MoveToUp();
        }

        public void MoveToDown()
        {
            _ChompChomp.MoveToDown();
        }


        public bool IsMovingToLeft(float dest)
        {
            return _ChompChomp.IsMovingToLeft(dest);
        }

        public bool IsMovingToRight(float dest)
        {
            return _ChompChomp.IsMovingToRight(dest);
        }

        public bool IsMovingToUp(float dest)
        {
            return _ChompChomp.IsMovingToUp(dest);
        }

        public bool IsMovingToDown(float dest)
        {
            return _ChompChomp.IsMovingToDown(dest);
        }


        public float GetDestination_Left()
        {
            return _ChompChomp.GetDestination_Left(_SIDE_SQUARE_MAP * 1);
        }

        public float GetDestination_Right()
        {
            return _ChompChomp.GetDestination_Right(_SIDE_SQUARE_MAP * 1);
        }

        public float GetDestination_Up()
        {
            return _ChompChomp.GetDestination_Up(_SIDE_SQUARE_MAP * 1);
        }

        public float GetDestination_Down()
        {
            return _ChompChomp.GetDestination_Down(_SIDE_SQUARE_MAP * 1);
        }


        public void BeginMoveToLeft()
        {
            _ChompChomp.BeginMoveToLeft();
        }

        public void BeginMoveToRight()
        {
            _ChompChomp.BeginMoveToRight();
        }

        public void BeginMoveToUp()
        {
            _ChompChomp.BeginMoveToUp();
        }

        public void BeginMoveToDown()
        {
            _ChompChomp.BeginMoveToDown();
        }

        public bool ShouldStopMovingHorizontal()
        {
            return _ChompChomp.ShouldStopMovingHorizontal(_SIDE_SQUARE_MAP * 1);
        }

        public bool ShouldStopMovingVertial()
        {
            return _ChompChomp.ShouldStopMovingVertical(_SIDE_SQUARE_MAP * 1);
        }
    }
}
