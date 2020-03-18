using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCreator1
{
    class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z{ get; set;}

        internal Point3D(int x=0, int y=0, int z=0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        //metoda wytwarzajaca tablice z wersorami
        //indeks 0 - do przodu, 1 - w prawo, 2 - do tylu, 3 - w lewo, 4 - do gory, 5 - w dol
        public static Point3D[] getDirectionVectors()
        {
            Point3D[] vectorsArray = new Point3D[6];
            for(int i=0;i<6;i++)
            {
                vectorsArray[i] = new Point3D();
                //vectorsArray[i].set(1, 1, 1);
            }
            vectorsArray[0].set(0, 1, 0);
            vectorsArray[1].set(1, 0, 0);
            vectorsArray[2].set(0, -1, 0);
            vectorsArray[3].set(-1, 0, 0);
            vectorsArray[4].set(0, 0, 1);
            vectorsArray[5].set(0, 0, -1);
            return vectorsArray;

        }

        //metoda zwraca nowy obiekt punkt majacy wsporzedne bedace wynikiem dodawania wspolrzednych argumentow 
        public Point3D vectorsAddition(Point3D vec2)
        {
            Point3D result = new Point3D();
            result.set(X + vec2.X, Y + vec2.Y, Z + vec2.Z);
            return result;
        }
        public Point3D vectorsSubstraction(Point3D vec2)
        {
            Point3D result = new Point3D();
            result.set(X - vec2.X, Y - vec2.Y, Z - vec2.Z);
            return result;
        }
        public void set(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public Point3D assign(Point3D other)
        {
            X = other.X;
            Y = other.Y;
            Z = other.Z;
            return this;
        }
        public bool Equals(Point3D other)
        {
            return this.X == other.X && this.Y == other.Y && this.Z == other.Z;

        }
        public Point3D copy()
        {
            return new Point3D(this.X, this.Y, this.Z);
        }
    }
}
