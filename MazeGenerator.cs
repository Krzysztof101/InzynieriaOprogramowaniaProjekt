using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MazeCreator1
{

    class MazeGenerator
    {
        Random rnd;
        MazeSpace mySpace;

        //pomocnicza metoda do wytworzenia tablicy z wartosciami-numerami krokow zrobionych przy tworzeniu poszczzegolnych
        //sciezek
        public int[,,] getMazeInRawForm()
        {
            int[,,] rawMaze = new int[mySpace.DimX, mySpace.DimY, mySpace.DimZ];
            for(int i=0;i<mySpace.DimX;i++)
            {
                for(int j=0; j<mySpace.DimY;j++)
                {
                    for(int k=0;k<mySpace.DimZ;k++)
                    {
                        rawMaze[i, j, k] = mySpace.get(i, j, k);
                    }
                }
            }
            return rawMaze;

        }
        private MazeGenerator()
        {
        }
        public MazeGenerator(int x, int y, int z, DifficultyLevel diffLev, Random r)
        {
            mySpace = new MazeSpace(x, y, z);
            Path mainPath1 = new MainPath(mySpace, rnd);
            List<Path> mazePaths = new List<Path>();
            rnd = r;
            mazePaths.Add(mainPath1);
            Point3D lastPoint = mazePaths.Last().getEndPoint();
            int lastPointValue = mySpace.get(lastPoint.X, lastPoint.Y, lastPoint.Z);
            //generowanie sciezek-slepych zaulkow
            while(lastPointValue < mySpace.capacity())
            {
                DeadEndPath nextPath = new DeadEndPath(mySpace, rnd);
                mazePaths.Add(nextPath);
                lastPoint = mazePaths.Last().getEndPoint();
                lastPointValue = mySpace.get(lastPoint.X, lastPoint.Y, lastPoint.Z);
                mySpace.doForbiddenCellsCleanUp();
            }
        
            //to jest jeszcze do napisania
            //polaczenie sciezek w ktorych koniec jednej jest poczatkiem innej
            //zbadanie czy poziom trudnosci odpowiada poziomowi trudnosci wybranego przez gracza
            //ewentualne uproszczenie lub skomplikowanie labiryntu
        

        }




    }

    class MazeSpace
    {
        private int[,,] mazeTable;
        private int borderValue;
        private int freeCellValue;
        private int forbiddenCellValue;
        

        // konstruktory
        private MazeSpace(int dimX, int dimY, int dimZ, int bordValue, int freeCellVal, int forbCellVal)
        {
            mazeTable = new int[dimX + 2, dimY + 2, dimZ + 2];
            borderValue = bordValue;
            freeCellValue = freeCellVal;
            forbiddenCellValue = forbCellVal;
            //ustawienie wartosci obrzeznej na dolnym i gornym boku przestrzeni
            for (int i = 0; i < dimX + 2; i++)
            {
                for (int j = 0; j < dimY + 2; j++)
                {
                    mazeTable[i, j, 0] = borderValue;
                    mazeTable[i, j, dimZ + 1] = borderValue;

                }

            }
            //ustawienie wartosci obrzeznej na przednim i tylnym boku przestrzeni
            for (int i = 0; i < dimY + 2; i++)
            {
                for (int j = 1; j < dimZ + 1; j++)
                {
                    mazeTable[i, 0, j] = borderValue;
                    mazeTable[i, dimY + 1, j] = borderValue;

                }

            }
            //ustawienie wartosci obrzeznej na lewym i prawym boku labiryntu
            for (int i = 1; i < dimY + 1; i++)
            {
                for (int j = 1; j < dimZ + 1; j++)
                {
                    mazeTable[0, i, j] = borderValue;
                    mazeTable[dimX + 1, i, j] = borderValue;
                }

            }
            //ustawienie wewnatrz przestrzeni wartosci
            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    for (int k = 0; k < dimZ; k++)
                        set(i, j, k, freeCellVal);
                }
            }
        }
        public MazeSpace(int dimX, int dimY, int dimZ) : this(dimX, dimY, dimZ, dimX * dimY * dimZ + 2, dimX * dimY * dimZ + 1, dimX*dimY*dimZ +3)
        { }
        public MazeSpace() : this(20, 20, 20)
        { }

        //metody
        public int get(int x, int y, int z)
        {
            return mazeTable[x + 1, y + 1, z + 1];
        }
        
        public int get(Point3D p)
        {
            return get(p.X, p.Y, p.Z);
        }
        public void set(Point3D p, int val)
        {
            set(p.X, p.Y, p.Z, val);
        }
        
        void set(int x, int y, int z, int val)
        {
            mazeTable[x + 1, y + 1, z + 1] = val;
        }
        public int BorderValue
        {
            get { return borderValue; }
        }
        public int FreeCellValue
        {
            get { return freeCellValue; }
        }
        public int getForbiddenCellValue()
        {
            return forbiddenCellValue;
        }
        public void setForbiddenCellValue(int x, int y, int z)
        {
            if(x>0 && x<mazeTable.GetLength(0) -2 && y>0  && y<mazeTable.GetLength(1) -2 && z>0 && z<mazeTable.GetLength(2) -2)
            {
                mazeTable[x, y, z] = forbiddenCellValue;
            }
        }
        public int DimX
        {
            get { return mazeTable.GetLength(0) - 2; }
        }
        public int DimY
        {
            get { return mazeTable.GetLength(1) - 2; }
        }
        public int DimZ
        {
            get { return mazeTable.GetLength(2) - 2; }
        }

        public int capacity()
        {
            return DimX * DimY * DimZ;
        }

        internal void doForbiddenCellsCleanUp()
        {
            for(int i=0;i<DimX;i++)
            {
                for(int j=0;j<DimY;j++)
                {
                    for(int k=0;k<DimZ;k++)
                    {
                        if(this.get(i,j,k)==this.getForbiddenCellValue())
                        {
                            this.set(i, j, k, FreeCellValue);
                        }
                    }
                }
            }
        }
    }
}
