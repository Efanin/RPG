using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class Animal
    {
        public string mesh { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public Animal(string mesh, int x, int y)
        {
            this.mesh = mesh;
            this.x = x;
            this.y = y;
        }

        public void Move()
        {
            x += new Random().Next(-1, 2);
            y += new Random().Next(-1, 2);
        }
    }
}
