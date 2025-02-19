﻿using System;
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
        private string meshPlayer =
            @"☻" +
            @"┴";
        private int height;
        private int width;
        Decor decor = new();
        char[,] newfield;
        public Display()
        { 
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                    field[i, j] = ' ';
            newfield = new char[1000, 1000];
            Array.Copy(decor.spawn(field, decor.bush), field, field.Length);
            Array.Copy(decor.spawn(field, decor.tree), field, field.Length);
            Array.Copy(decor.spawn(field, decor.house), field, field.Length);
            Array.Copy(field, newfield, field.Length);


            for (int i = 0; i < 1000000; i++)
            {
                ani.Add(new Prefab(
                     @"♀",
                     new Random().Next(1000),
                     new Random().Next(1000),
                     1, 1
                    ));
            }
            }
        public void Render()
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            int point_x = x - width/2;
            int point_y = y - height/2;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width/2; j++)
                {
                    try
                    {
                        Console.SetCursorPosition(j, i);
                        /*if (j == width / 2 && i == height / 2)
                            Console.Write(meshPlayer[0]);
                        else if (j == width / 2 && i == (height / 2) + 1)
                            Console.Write(meshPlayer[1]);
                        else*/
                            Console.Write(newfield[point_x + j, point_y + i]);
                    }
                    catch (Exception ex) { }
                }
            }
        }
        public void Render2()
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            int point_x = x - width / 2;
            int point_y = y - height / 2;
            for (int i = 0; i < height; i++)
            {
                for (int j = width / 2; j < width; j++)
                {
                    try
                    {
                        Console.SetCursorPosition(j, i);
                        /*if (j == width / 2 && i == height / 2)
                            Console.Write(meshPlayer[0]);
                        else if (j == width / 2 && i == (height / 2) + 1)
                            Console.Write(meshPlayer[1]);
                        else*/
                        Console.Write(newfield[point_x + j, point_y + i]);
                    }
                    catch (Exception ex) { }
                }
            }
        }
        public void up() => y--;
        public void down() => y++;
        public void left() => x--;
        public void right() => x++;

        public List<Prefab> ani = new List<Prefab>();
        public void animal()
        {
            Array.Copy(field, newfield, field.Length);
            for (int i = 0; i < 1000000; i++)
            {
                try
                {
                    newfield[ani[i].x, ani[i].y] = ani[i].mesh[0];
                    ani[i].x++;
                    ani[i].y++;
                }
                catch (Exception ex) { }
                
            }
        }
    }
}
