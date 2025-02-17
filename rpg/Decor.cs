using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class Decor
    {
        private string tree =
            @" /\ " +
            @"/  \" +
            @"/  \" +
            @" || ";
        private int x;
        private int y;
        private int width;
        private int height;

        public void Spawn(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;  
        }
        public char[,] FieldTree(char[,] field,int player_x,int player_y)
        {
            if(Math.Abs(player_x-x) < width/2 && 
                Math.Abs(player_y - y) < height / 2)
            {
                char[,] newField = new char[1000, 1000];
                Array.Copy(field, newField, field.Length);
                for(int i = 0; i < 4; i++)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        newField[y + i, x + j] = tree[i * 4 + j]; 
                    }
                }
                return newField;
            }
            return field;
        }
    }
}
