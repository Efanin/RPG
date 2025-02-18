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
                     "#",
                     new Random().Next(1000),
                     new Random().Next(1000),
                     1, 1
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
                                prefab[n].mesh[i * prefab[n].size_y + j];
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return newField;
        }


        /*
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
        */
    }
    public class Prefab
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
