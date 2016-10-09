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
        private const int _HEIGHT_WATER = 0;
        private const int _HEIGHT_ICE = 122;
        private const int _HEIGHT_HIGHLAND = 131;
        private const int _HEIGHT_GRASS = 222;


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
            float scale = 0.04f;
            MapTiling mapTiling = new MapTiling(strBaseMap, 0, 0, 64, 64, scale);
            _lMapSrite.Add(mapTiling);
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
    }
}
