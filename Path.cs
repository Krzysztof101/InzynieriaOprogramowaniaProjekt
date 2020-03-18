using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCreator1
{
    abstract class Path
    {
        protected Point3D StartPoint { get; set; } 
        protected Point3D EndPoint { get; set;  }
        protected Point3D PointFromNeighbourPath { get; set; }

        public Point3D getEndPoint()
        {
            return EndPoint.copy();
        }
        public Point3D getStartPoint()
        {
            return StartPoint.copy();
        }
        
        protected MazeSpace mySpace;
        protected int Length{ get; set; }
        protected Random rnd;
        private PointsHistory history;

        //metoda znajdujaca punkt startowy dla sciezki
        protected abstract Point3D getStartingPoint();

        //metoda wykrywajaca sytuacje, gdy nie da sie ani zakonczyc wytwarzania sciezki, ani dodac do niej kolejnej komorki
        protected bool deadLockDetected(Point3D currPosRef)
        {

            Point3D[] dirs = Point3D.getDirectionVectors();
            int previousPosValue = mySpace.get(currPosRef) - 1;
            for(int i =0;i<6;i++)
            {
                Point3D neighbourPoint = currPosRef.vectorsAddition(dirs[i]);
                if(mySpace.get(currPosRef)==previousPosValue && !currPosRef.Equals(StartPoint))
                {
                    //pierwszy waunek - pominiecie poprzedniego punktu sciezki
                    //drugi warunek - gdy dopiero zaczelismy generowanie scieki
                    //moze sie zdarzyc sytuacja, ze wylosujemy poczatek akurat obok konca poprzedniej sciezki
                    continue;
                }
                int neighbourVal = mySpace.get(neighbourPoint);
                if(neighbourVal==mySpace.FreeCellValue || 
                    !(neighbourVal >= mySpace.get(StartPoint) && neighbourVal <= mySpace.get(currPosRef) )
                    && neighbourVal != mySpace.BorderValue && neighbourVal != mySpace.getForbiddenCellValue())
                {
                    //jesli komorka jest wolna lub nalezy do innej sciezki tj. nie jest zakazana, nie jest komorka z warstwy
                    //opakowujacej i nie jest komorka z aktualnie generowanej sciezki
                    return false;
                }

            }
            return true;
        }
        
        protected Point3D getNextPoint(Point3D currPos)
        {
            //kierunki
            // 0 +y,  1 +x, 2 -y, 3 -x, 4 +z, 5 -z
            Point3D[] dirs = Point3D.getDirectionVectors();
            List<Point3D> possibleMovementOptions = new List<Point3D>();
            //wyznacz te sasiednie komorki, ktore moga byc kolejnymi komorkami w generowanej sciezce
            for(int i=0;i<6;i++)
            {
                Point3D neighbourPoint = currPos.vectorsAddition(dirs[i]);
                //check if point belongs to path being currently generated
                if((mySpace.get(neighbourPoint)
                    <=mySpace.get(StartPoint) + Length -1
                     && mySpace.get(neighbourPoint) 
                     >= mySpace.get(StartPoint) ) 
                     || mySpace.get(neighbourPoint) == mySpace.getForbiddenCellValue())
                { continue; }
                else if (mySpace.get(neighbourPoint) == mySpace.BorderValue)
                {
                    //check if point is in the border layer of mazeSpace
                    continue;
                }
                else
                {
                    possibleMovementOptions.Add(neighbourPoint);
                }

            }
            //po znalezieniu tych punktow ktore mozna dodac do scieki, zwieksz lub zmniejsz prawdopodobienstwo ze zostanie
            //wylosowany punkt dajacy przesuniecie w tym samym kierunku co przedtem
            //obiekt history zwroci liste z punktami, takimi samymi jak ten ktory przedtem zostal wybrany, jesli
            //sciezka nie szla przez dlugi dystans w tym samym kierunku
            //jesli szla przez dlugi dystans w tym samym kierunku to zwroci liste ze wszystkimi innymi punktami z possibleMovementOptions
            List<Point3D> extraPointsFromHistory = history.getExtraPoints(currPos ,possibleMovementOptions);

            List<Point3D> allPointsToChooseFrom = possibleMovementOptions.Concat(extraPointsFromHistory).ToList();
            int chosenPointNumber = rnd.Next(allPointsToChooseFrom.Count());
            return allPointsToChooseFrom.ElementAt(chosenPointNumber);

        }

        protected abstract bool isEndPoint(Point3D checkedPoint);
        protected void takeAStepBack(Point3D currPosRef)
        {
            
            Point3D previousPos;
            Point3D[] dirs = Point3D.getDirectionVectors();
                for (int i= 0; i < 6; i++)
            {
                previousPos = currPosRef.vectorsAddition(dirs[i]);
                if(mySpace.get(previousPos.X,previousPos.Y,previousPos.Z)==Length-1)
                {
                    mySpace.setForbiddenCellValue(currPosRef.X, currPosRef.Y, currPosRef.Z);
                    Length--;
                    currPosRef.assign(previousPos);
                    history.deleteLatestLog();
                    break;
                }
            }
        }
        
        private bool constructionInProgress()
        {
            //Point3D pointWithDefaultStartingValueInPath = new Point3D(-1, -1, -1);
            //return !EndPoint.Equals(pointWithDefaultStartingValueInPath);
            return EndPoint.X == -1 && EndPoint.Y == -1 && EndPoint.Z == -1;
        }
        private Path()
        { }
        public Path(MazeSpace ms, Random r)
        {
            history = new PointsHistory();
            StartPoint = new Point3D();
            EndPoint = new Point3D();
            StartPoint.set(-1, -1, -1);
            EndPoint.set(-1, -1, -1);
            mySpace = ms;
            Length = 0;
            rnd = r;
      
            //wygenerowanie sciezek nastepuje w konstruktorach klas pochodnych
        }
        public void generatePath()
        {
            StartPoint.assign(getStartingPoint());
            Point3D currentPosition = new Point3D();
            currentPosition.assign(StartPoint);
            Point3D nextPoint = new Point3D();
            nextPoint.assign(getNextPoint(currentPosition));
            while (constructionInProgress())
            {
                if(deadLockDetected(currentPosition))
                {
                    
                    takeAStepBack(currentPosition);
                    nextPoint.assign(getNextPoint(currentPosition));
                }
                else
                {
                    
                    if(isEndPoint(nextPoint))
                    {
                        EndPoint.assign(currentPosition);
                        PointFromNeighbourPath.assign(nextPoint);

                    }
                    else
                    {
                        setNextPathPoint(currentPosition,nextPoint);
                        currentPosition.assign(nextPoint);
                        nextPoint.assign(getNextPoint(currentPosition));
                    }
                }

            }
            //EndPoint = currentPosition.copy();
            //PointFromNeighbourPath = nextPoint.copy();


        }

        private void setNextPathPoint(Point3D currPosRef,Point3D nextPoint)
        {
            Length++;
            mySpace.set(nextPoint, Length);
            history.addLog(currPosRef,nextPoint);
        }
    }

    class MainPath : Path
    {
        public MainPath(MazeSpace ms, Random r) :base(ms,r)
        {
            this.generatePath();
        }

        
        protected override Point3D getStartingPoint()
        {
            //wylosuj jakis punkt na samym dole
            Point3D _startPoint=new Point3D(0,0,0);
            _startPoint.X = rnd.Next(mySpace.DimX);
            _startPoint.Y = rnd.Next(mySpace.DimY);
            return _startPoint;
        }

        protected override bool isEndPoint(Point3D checkedPoint)
        {
            //zobacz czy juz dotarles od samego dolu na sama gore
            return checkedPoint.Z == mySpace.DimZ - 1;
        }

    }

    class DeadEndPath : Path
    {
        public DeadEndPath(MazeSpace ms, Random r) :base(ms, r)
        {
            this.generatePath();
        }
        
        protected override Point3D getStartingPoint()
        {
            //policz ile zostalo wolnych komorek
            int numberOfFreeCells = 0;
            for (int i = 0; i < mySpace.DimX; i++)
            {
                for (int j = 0; j < mySpace.DimY; j++)
                {
                    for (int k = 0; k < mySpace.DimZ; k++)
                    {
                        if(mySpace.get(i,j,k)==mySpace.FreeCellValue)
                        {
                            numberOfFreeCells++;
                        }
                    }

                }
            }
            //wybierz ktoras z tych komorek losujac jej numer
            int numberOfChoseCell = rnd.Next(numberOfFreeCells);
            int t = 0;
            //znajd ta wolna komorke
            for (int i = 0; i < mySpace.DimX; i++)
            {
                for (int j = 0; j < mySpace.DimY; j++)
                {
                    for (int k = 0; k < mySpace.DimZ; k++)
                    {
                        
                        if (mySpace.get(i, j, k) == mySpace.FreeCellValue)
                        {
                            t++;
                            if (t == numberOfChoseCell)
                            {
                                Point3D startingPoint = new Point3D(i, j, k);
                                return startingPoint;
                            }
                        }
                    }

                }
            }
            return new Point3D(-1, -1, -1);
        }

        protected override bool isEndPoint(Point3D checkedPoint)
        {
            if(mySpace.get(checkedPoint.X,checkedPoint.Y, checkedPoint.Z)==mySpace.FreeCellValue)
            {
                return false;
            }
            if(mySpace.get(checkedPoint.X, checkedPoint.Y, checkedPoint.Z) == mySpace.BorderValue)
            {
                return false;
            }
            if(mySpace.get(checkedPoint.X, checkedPoint.Y, checkedPoint.Z) == mySpace.getForbiddenCellValue())
            {
                return false;
            }
            if(mySpace.get(checkedPoint.X, checkedPoint.Y, checkedPoint.Z) 
                >= mySpace.get(StartPoint.X, StartPoint.Y, StartPoint.Z) && 
                mySpace.get(checkedPoint.X,checkedPoint.Y,checkedPoint.Z) <=
                mySpace.get(StartPoint.X, StartPoint.Y, StartPoint.Z) +Length -1)
            {
                return false;
            }
            return true;
        }

    }

}
