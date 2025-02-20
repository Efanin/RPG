using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class Decor
    {
        public List<Prefab> tree = new List<Prefab>();
        public List<Prefab> bush = new List<Prefab>();
        public List<Prefab> house = new List<Prefab>();
        public Decor() 
        {
            for (int i = 0; i < 10000; i++)
            {
                tree.Add(new Prefab(
                     @" /\ " +
                     @"/  \" +
                     @"/  \" +
                     @" || ",
                     new Random().Next(1000),
                     new Random().Next(1000),
                     4,4
                    ));
                bush.Add(new Prefab(
                     @" # "+
                     @"###",
                     new Random().Next(1000),
                     new Random().Next(1000),
                     2, 3
                    ));
            }
            for (int i = 0; i < 2000; i++)
            {
                house.Add(new Prefab(

                     @"  __  " +
                     @" /  \ " +
                     @"/____\" +
                     @"| ██ |" +
                     @"|____|",
                     new Random().Next(1000),
                     new Random().Next(1000),
                     6, 5
                    ));
            }
        }
        public char[,] spawn(char[,] field, List<Prefab> prefab)
        {
            char[,] newField = new char[1000, 1000];
            Array.Copy(field, newField, field.Length);
            for (int n = 0; n < prefab.Count; n++) 
            {
                for (int i = 0; i < prefab[n].size_y; i++)
                {
                    for (int j = 0; j < prefab[n].size_x; j++)
                    {
                        try
                        {
                            newField[prefab[n].x + j, prefab[n].y + i] =
                                prefab[n].mesh[i * prefab[n].size_x + j];
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return newField;
        }



    }
    internal class Prefab
    {
        public string mesh { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }
        public int size_x { get; private set; }
        public int size_y { get; private set; }

        public Prefab(string mesh, int x, int y, int size_x, int size_y)
        {
            this.mesh = mesh;
            this.x = x;
            this.y = y;
            this.size_x = size_x;
            this.size_y = size_y;
        }
    }
}
