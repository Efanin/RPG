using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class Display
    {
        private char[,] field = new char[1000,1000];
        private int x = 500;
        private int y = 500;
        private int height = 25;
        private int width = 110;

        private Decor[] decor = new Decor[10000];
        public Display()
        {
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                    field[i, j] = '.';
            for (int i = 0;i<10000;i++)
            {
                field[
                    new Random().Next(field.GetLength(0)),
                    new Random().Next(field.GetLength(1))] = '#';
                decor[i] = new Decor();
                decor[i].Spawn(
                    new Random().Next(field.GetLength(0)),
                    new Random().Next(field.GetLength(1)),
                    width, height);
            }

        }
        public void Render()
        {
            char[,] newfield = new char[1000,1000];
            Array.Copy(
                decor[0].FieldTree(field, x, y),
                newfield,
                newfield.Length);
            for (int i = 1;i < decor.Length; i++)
               Array.Copy(
               decor[0].FieldTree(newfield, x, y),
               newfield,
               newfield.Length);

            int point_x = x - width/2;
            int point_y = y - height/2;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(j,i);
                    Console.Write(newfield[point_x + j, point_y + i]);
                }
            }
        }
        public void up() => y--;
        public void down() => y++;
        public void left() => x++;
        public void right() => x--;
    }
}
