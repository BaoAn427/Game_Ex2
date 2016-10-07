using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Ex2
{
    public abstract class EntityVisible : GameEntity
    {
        protected Model _MainModel;
        public virtual void Draw(GameTime gameTime, object helper)
        {
            _MainModel.Draw(gameTime, helper);
        }
    }
}
