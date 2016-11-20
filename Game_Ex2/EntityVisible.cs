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

        public virtual bool IsMovingToLeft(float dest) { return false; }
        public virtual bool IsMovingToRight(float dest) { return false; }
        public virtual bool IsMovingToUp(float dest) { return false; }
        public virtual bool IsMovingToDown(float dest) { return false; }

        public virtual float GetDestination_Left(float distance) { return distance; }
        public virtual float GetDestination_Right(float distance) { return distance; }
        public virtual float GetDestination_Up(float distance) { return distance; }
        public virtual float GetDestination_Down(float distance) { return distance; }

        public virtual void BeginMoveToLeft() { }
        public virtual void BeginMoveToRight() { }
        public virtual void BeginMoveToUp() { }
        public virtual void BeginMoveToDown() { }

        public virtual bool ShouldStopMovingHorizontal(float dest) { return false; }
        public virtual bool ShouldStopMovingVertical(float dest) { return false; }
    }
}
