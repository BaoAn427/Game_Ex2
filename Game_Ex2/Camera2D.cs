using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Ex2
{
    public class Camera2D : EntityInvisible
    {
        public Matrix _World = Matrix.Identity;
        public Matrix _View = Matrix.Identity;
        public Matrix _Projection = Matrix.Identity;

        public Matrix WVP // W2S
        {
            get { return _World * _View * _Projection; }
        }
        public Matrix InvWVP // S2W
        {
            get { return Matrix.Invert(WVP); }
        }

        public float _TransX = 0;
        public float _TransY = 0;
        public float _TransZ = 0;
        public float _RotX = 0;
        public float _RotY = 0;
        public float _RotZ = 0;
        public float _ScaleX = 1;
        public float _ScaleY = 1;
        public float _ScaleZ = 1f;
        public float _PreTranX = 0;
        public float _PreTranY = 0;
        public float _PreTranZ = 0;


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _View = Matrix.CreateTranslation(_PreTranX, _PreTranY, _PreTranZ) *
                    Matrix.CreateScale(_ScaleX, _ScaleY, _ScaleZ) *
                    Matrix.CreateRotationX(_RotX) * Matrix.CreateRotationY(_RotY) * Matrix.CreateRotationZ(_RotZ) *
                    Matrix.CreateTranslation(_TransX, _TransY, _TransZ);
        }
  

        internal void Zoom(Vector2 Center, float ScaleFactor)
        {
            _PreTranX = -Center.X;
            _PreTranY = -Center.Y;
            _PreTranZ = 0;
            _ScaleX = _ScaleY = ScaleFactor;
            _ScaleZ = 1;
            _TransX = Center.X;
            _TransY = Center.Y;
            _TransZ = 0;
        }


        internal void Translate(float transX, float transY, int transZ)
        {
            _TransX += transX;
            _TransY += transY;
            _TransZ += transZ;
        }

        internal void Translate(Vector2 vector2)
        {
            _TransX += vector2.X;
            _TransY += vector2.Y;
        }
    }
}
