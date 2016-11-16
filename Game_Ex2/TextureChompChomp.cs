using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Ex2
{
    public class TextureChompChomp : EntityVisible
    {
        protected string _Name;
        protected ModelSprite2D _Center = new ModelSprite2D();
        protected ModelSprite2D _ToLeft = new ModelSprite2D();
        protected ModelSprite2D _ToRight = new ModelSprite2D();
        protected ModelSprite2D _ToUp = new ModelSprite2D();
        protected ModelSprite2D _ToDown = new ModelSprite2D();
        protected int _Width;
        protected int _Height;
        protected int _Left;
        protected int _Top;
        protected float _Scale;
        protected float _Depth;

        public TextureChompChomp() { }

        public TextureChompChomp(int row, int col, int width, int height)
        {
            _Left = row * TextureManagement.GetSideSquareMap();
            _Top = col * TextureManagement.GetSideSquareMap();
            if (width <= 0)
                _Width = TextureManagement.GetSideSquareMap();
            else
                _Width = width;
            if (height <= 0)
                _Height = TextureManagement.GetSideSquareMap();
            else
                _Height = height;

            _Scale = 2.5f;
            _Depth = 0.1f;

            _Name = "ChompChomp";
            _Center = GenerateSprite("Center");
            _ToLeft = GenerateSprite("Left", 3);
            _ToRight = GenerateSprite("Right", 3);
            _ToUp = GenerateSprite("ComeIn", 3);
            _ToDown = GenerateSprite("ComeOut", 3);
        }
               

        private List<Texture2D> LoadTexture(string strResourceName)
        {
            List<Texture2D> lTexture = new List<Texture2D>();
            string realResourceName = _Name + "_" + strResourceName;
            lTexture.Add(Global._Content.Load<Texture2D>(realResourceName));
            return lTexture;
        }

        private List<Texture2D> LoadTexture(string strResourceName, int n)
        {
            string realResourceName;
            List<Texture2D> lTexture = new List<Texture2D>();
            for (int i = 0; i < n; ++i)
            {
                realResourceName = _Name + "_" + strResourceName + "_0" + (i + 1).ToString();
                lTexture.Add(Global._Content.Load<Texture2D>(realResourceName));
            }
            return lTexture;
        }


        private ModelSprite2D GenerateSprite(string strResourceName)
        {
            ModelSprite2D sprite = new ModelSprite2D(_Name, LoadTexture(strResourceName), _Left, _Top, _Scale, _Depth, TextureManagement.GetSideSquareMap());
            return sprite;
        }

        private ModelSprite2D GenerateSprite(string strResourceName, int n)
        {
            ModelSprite2D sprite = new ModelSprite2D(_Name, LoadTexture(strResourceName, n), _Left, _Top, _Scale, _Depth, TextureManagement.GetSideSquareMap());
            return sprite;
        }


        public override void Update(GameTime gameTime)
        {
            _Center.Update(gameTime);
            _ToLeft.Update(gameTime);
            _ToRight.Update(gameTime);
            _ToUp.Update(gameTime);
            _ToDown.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            _Center.Draw(gameTime, param);
            _ToLeft.Draw(gameTime, param);
            _ToRight.Draw(gameTime, param);
            _ToUp.Draw(gameTime, param);
            _ToDown.Draw(gameTime, param);
        }
    }
}
