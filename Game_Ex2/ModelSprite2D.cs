using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Ex2
{
    public class ModelSprite2D : Model
    {
        private string _Name;
        private List<Texture2D> _lTexture;    // List of Texture
        private int _nTexture;               // Length of List of Texture
        private int _iTexture;               // Pointer for element in List of Texture
        private float _Left;
        private float _Top;
        private float _Width;
        private float _Height;
        private float _Depth;
        private float _Scale;
        private float _DELAY = 120;


        public ModelSprite2D() { }
        
        public ModelSprite2D(string name, List<Texture2D> lTexture, float left, float top, float width, float height, float scale, float depth)
        {
            _Name = name;

            _lTexture = lTexture;
            _nTexture = _lTexture.Count;
            _iTexture = 0;

            _Left = left;
            _Top = top;


            if (width == 0)
                _Width = _lTexture[0].Width;
            else
                _Width = width;

            if (height == 0)
                _Height = _lTexture[0].Height;
            else
                _Height = height;

            _Scale = scale;

            if (depth > 1)
                _Depth = 1;
            else
                _Depth = depth;
        }

        public ModelSprite2D(string name, List<Texture2D> lTexture, float left, float top, float scale, float depth, float side)
        {
            _Name = name;

            _lTexture = lTexture;
            _nTexture = _lTexture.Count;
            _iTexture = 0;
            
            _Scale = scale;
            if (depth > 1)
                _Depth = 1;
            else
                _Depth = depth;

            _Width = _lTexture[0].Width * _Scale;
            _Height = _lTexture[0].Height * _Scale;

            _Left = left + (side / 2 - _Width / 2);
            _Top = top + (side / 2 - _Height / 2);
        }


        public override void Update(GameTime gameTime)
        {
            _iTexture = ((int)(gameTime.TotalGameTime.TotalMilliseconds / _DELAY)) % _nTexture;
        }


        public override void Draw(GameTime gameTime, object helper)
        {
            SpriteBatch spriteBatch = (SpriteBatch)helper;
            spriteBatch.Draw(_lTexture[_iTexture], new Vector2(_Left, _Top), null, Color.White, 0f, Vector2.Zero, _Scale, SpriteEffects.None, _Depth);
            //spriteBatch.Draw(_lTexture[_iTexture], new Vector2(_Left, _Top), null, null, null, 0, null, null, SpriteEffects.None, _Depth);
        }


        public void MoveToLeft()
        {
            _Left -= 2.0f;
        }

        public void MoveToRight()
        {
            _Left += 2.0f;
        }

        public void MoveToUp()
        {
            _Top -= 2.0f;
        }

        public void MoveToDown()
        {
            _Top += 2.0f;
        }


        public bool IsMovingToLeft(float dest)
        {
            bool res = (_Left > dest);
            if(!res)
                Global.UnlockMove();
            return res;
        }

        public bool IsMovingToRight(float dest)
        {
            return (_Left < dest);
        }

        public bool IsMovingToUp(float dest)
        {
            return (_Top > dest);
        }

        public bool IsMovingToDown(float dest)
        {
            return (_Top < dest);
        }


        public float GetDestination_Left(float distance)
        {
            return (_Left - distance);
        }

        public float GetDestination_Right(float distance)
        {
            return (_Left + distance);
        }

        public float GetDestination_Up(float distance)
        {
            return (_Top - distance);
        }

        public float GetDestination_Down(float distance)
        {
            return (_Top + distance);
        }


        public bool ShouldStopMovingHorizontal(float dest)
        {
            return (_Left == dest);
        }

        public bool ShouldStopMovingVertical(float dest)
        {
            return (_Top == dest);
        }
    }
}
