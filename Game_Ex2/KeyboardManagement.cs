using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Ex2
{
    class KeyboardManagement : EntityInvisible
    {
        protected KeyboardState _PreviousState;
        protected KeyboardState _CurrenState;

        public bool IsToRight()
        {
            return (IsTypeThisKey(Keys.Right));
        }

        public bool IsToLeft()
        {
            return (IsTypeThisKey(Keys.Left));
        }

        public bool IsToUp()
        {
            return (IsTypeThisKey(Keys.Up));
        }

        public bool IsToDown()
        {
            return (IsTypeThisKey(Keys.Down));
        }

        private bool IsTypeThisKey(Keys key)
        {
            return (_PreviousState.IsKeyDown(key) && _CurrenState.IsKeyUp(key));
        }

        public override void Update(GameTime gameTime)
        {
            _PreviousState = _CurrenState;
            _CurrenState = Keyboard.GetState();
            base.Update(gameTime);
        }
    }
}
