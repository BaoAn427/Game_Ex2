using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Ex2
{
    public class MapScrolling: Map
    {
        protected string _Name;
        protected ModelSprite2D[,] _lFragment;
        protected int _FragmentWidth;
        protected int _FragmentHeight;
        protected int _nRow;
        protected int _nCol;
        protected int _Left;
        protected int _Top;
        protected float _Scale;

        public MapScrolling() { }

        public MapScrolling(string strResourceName, int fragmentWidth, int fragmentHeight, int nRow, int nCol, int left, int top)
        {
            _MainModel = null;
            _Name = strResourceName;
            _FragmentWidth = fragmentWidth;
            _FragmentHeight = fragmentHeight;
            _nRow = nRow;
            _nCol = nCol;
            _Left = left;
            _Top = top;
            CreateListMapFragment();
        }


        private void CreateListMapFragment()
        {
            _lFragment = new ModelSprite2D[_nRow, _nCol];
            for(int i = 0; i < _nRow; i++)
            {
                for(int j = 0; j < _nCol; ++j)
                {
                    string tmp = _Name + i.ToString("00") + j.ToString("00");
                    _lFragment[i, j] = new ModelSprite2D(_Name, TextureManagement.LoadTextureForScrollingMap(tmp),
                                                        _Left, _Top,
                                                        _FragmentWidth, _FragmentHeight, 0, 0);
                }
            }
        }


        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < _nRow; ++i)
                for (int j = 0; j < _nCol; ++j)
                    _lFragment[i, j].Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            for (int i = 0; i < _nRow; ++i)
                for (int j = 0; j < _nCol; ++j)
                    if(IsVisible(i, j))
                        _lFragment[i, j].Draw(gameTime, param);
        }

        private bool IsVisible(int i, int j)
        {
            return true;
        }

        internal void Translate(Vector2 vector)
        {
            _Left += (int)vector.X;
            _Top += (int)vector.Y;
            Global.Translate(vector);
        }
    }
}
