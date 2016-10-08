using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Ex2
{
    public class MapTiling : MapScrolling
    {
        private int[,] _HeightFragment;
        private string _NameBaseMap;


        public MapTiling(string strBaseMap, int left, int top, int fragmentWidth, int fragmentHeight, float scale)
        {
            _MainModel = null;
            _NameBaseMap = strBaseMap;
            _Left = left;
            _Top = top;
            _FragmentWidth = fragmentWidth;
            _FragmentHeight = fragmentHeight;
            _Scale = scale;
            GenerateHeightFragment();
            CreateListMapFragment();
        }


        private void CreateListMapFragment()
        {
            _lFragment = new ModelSprite2D[_nRow, _nCol];
            for (int i = 0; i < _nRow; i++)
            {
                for (int j = 0; j < _nCol; ++j)
                {
                    _lFragment[i, j] = new ModelSprite2D(_Name, TextureManagement.LoadTextureForTilingMap(_HeightFragment[i, j]),
                                                        _Left + j * _FragmentWidth * _Scale, _Top + i * _FragmentHeight * _Scale,
                                                        _FragmentWidth * _Scale, _FragmentHeight * _Scale, _Scale, 0);
                }
            }
        }


        private void GenerateHeightFragment()
        {
            // Get Base Map
            Texture2D baseMap = TextureManagement.GetBaseMap(_NameBaseMap);
            _nRow = baseMap.Height;
            _nCol = baseMap.Width;
            _HeightFragment = new int[_nRow, _nCol];

            // Get Color data of Base Map into lColor array
            Color[] lColor = new Color[_nRow * _nCol];
            baseMap.GetData<Color>(lColor);
            for (int i = 0; i < _nRow; ++i)
            {
                for (int j = 0; j < _nCol; ++j)
                {
                    // Just use data in Red channel
                    _HeightFragment[i, j] = lColor[i * _nCol + j].R;
                }
            }
        }
        
    }
}
