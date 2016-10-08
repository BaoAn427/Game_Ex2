using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Ex2
{
    public class MouseManagement : EntityInvisible
    {
        protected MouseState _PreviousState;
        protected MouseState _CurrentState;


        public bool Is_LeftClickBegin()
        {
            return (_PreviousState.LeftButton == ButtonState.Released &&
                    _CurrentState.LeftButton == ButtonState.Pressed);
        }

        public bool Is_LeftClickEnd()
        {
            return (_PreviousState.LeftButton == ButtonState.Pressed &&
                    _CurrentState.LeftButton == ButtonState.Released);
        }


        public override void Update(GameTime gameTime)
        {
            _PreviousState = _CurrentState;
            _CurrentState = Mouse.GetState();
            base.Update(gameTime);
        }


        public float GetCurrentX()
        {
            return _CurrentState.X;
        }

        public float GetCurrentY()
        {
            return _CurrentState.Y;
        }


        public Vector2 GetMousePositionDifference()
        {
            return new Vector2(_CurrentState.X - _PreviousState.X, _CurrentState.Y - _PreviousState.Y);
        }
    }
}
