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

        public virtual void MoveToLeft() { }
        public virtual void MoveToRight() { }
        public virtual void MoveToUp() { }
        public virtual void MoveToDown() { }

        public virtual void StopCol(float dest) { }
        public virtual void StopRow(float dest) { }

        public virtual bool IsReachLeft(float dest) { return false; }
        public virtual bool IsReachRight(float dest) { return false; }
        public virtual bool IsReachUp(float dest) { return false; }
        public virtual bool IsReachDown(float dest) { return false; }

        public virtual float GetDestionationRow(float dest) { return 0; }
        public virtual float GetDestionationCol(float dest) { return 0; }
    }
}
