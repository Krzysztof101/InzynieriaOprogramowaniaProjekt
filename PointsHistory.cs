using System.Collections.Generic;
using System.Linq;

namespace MazeCreator1
{
    class PointsHistory
    {
        private List<Point3D> previousMoves;
        public PointsHistory()
        {
            previousMoves = new List<Point3D>();
        }
        public List<Point3D> getExtraPoints(Point3D currPosRef,List<Point3D> availibleMovementOptions)
        {
            if(previousMoves.Count()>=2)
            {
                Point3D previousMoveDirection = previousMoves.ElementAt(1).vectorsSubstraction(previousMoves.ElementAt(0));
                bool previousMoveAvalible = false;
                foreach(Point3D itr in availibleMovementOptions)
                {
                    Point3D checkedMove = itr.vectorsSubstraction(currPosRef);
                    if(checkedMove.Equals(previousMoveDirection))
                    {
                        previousMoveAvalible = true;
                        break;
                    }
                }
                List<Point3D> extraPoints = new List<Point3D>();
                if (previousMoveAvalible && previousMoves.Count() <= 3)
                {
                    int loopLimit = 5 - previousMoves.Count();
                    
                    for(int i=0; i<loopLimit; i++)
                    {
                        extraPoints.Add(currPosRef.vectorsAddition(previousMoveDirection));

                    }
                    
                }
                else
                {
                    int loopLimit = previousMoves.Count() - 3;
                    for(int i=0;i<loopLimit;i++)
                    {
                        foreach(Point3D itr in availibleMovementOptions)
                        {
                            if(currPosRef.vectorsAddition(previousMoveDirection).Equals(itr))
                            { continue; }
                            extraPoints.Add(itr.copy());
                        }
                    }
                }
                return extraPoints;
            }
            return new List<Point3D>();
        }
        public void deleteLatestLog()
        {
            if (previousMoves.Count > 0)
                previousMoves.RemoveAt(previousMoves.Count - 1);
        }

        internal void addLog(Point3D currPosRef, Point3D nextPointRef)
        {
            if(previousMoves.Count>=2)
            {
                Point3D currDirection = nextPointRef.vectorsSubstraction(currPosRef);
                Point3D lastDirectionInHistory = previousMoves.Last().vectorsSubstraction(previousMoves.ElementAt(previousMoves.Count - 2));
                if(!currDirection.Equals(lastDirectionInHistory))
                {
                    previousMoves.Clear();
                }
            }
            previousMoves.Add(nextPointRef.copy());
        }
    }

}



/*
            if (previousMoves.Count == 0 || previousMoves.Count > 0 && previousMoves.Last().Equals(transitionVector))
            {
                previousMoves.Add(transitionVector.copy());
            }
            //else if( previousMoves.Count >0 && !(previousMoves.Last().Equals(transitionVector)))
            else
            {
                previousMoves.Clear();
                previousMoves.Add(transitionVector.copy());
            }
            */

/*
            int listSize = previousMoves.Count;
            List<Point3D> extraPoints = new List<Point3D>();
            //if(listSize > 0 && availibleMovementOptions.Contains(previousMoves.Last()))
            if (listSize > 0)
            {
                for (int k = 0; k < availibleMovementOptions.Count; k++)
                {
                    //sprawdzic metode Contains - czy ona sprawdza tylko referencje obiektow, czy moze wywoluje metode equals
                    if (availibleMovementOptions.ElementAt(k).Equals(previousMoves.Last()))
                    {
                        switch (listSize)
                        {
                            //pierwsze 3 przypadki - zwiekszamy prawdopodobienstwo wygenerowania
                            //takiego samego kierunku jak poprzednio wygenerowany poprzez
                            //wytworzenie listy z takim samym kierunkiem jak poprzednio
                            case 1:
                                for (int i = 0; i < 6; i++)
                                {
                                    extraPoints.Add(previousMoves.Last().copy());
                                }
                                break;
                            case 2:
                                for (int i = 0; i < 4; i++)
                                {
                                    extraPoints.Add(previousMoves.Last().copy());
                                }
                                break;
                            case 3:
                                extraPoints.Add(previousMoves.Last().copy());
                                extraPoints.Add(previousMoves.Last().copy());
                                break;
                            default:
                                //zbyt wiele razy przedtem byl taki sam kierunek - zmniejsz
                                //prawdopodobienstwo ze znowu wylosujemy taki sam kierunek
                                List<Point3D> avalibleMovesWithoutLastMove = new List<Point3D>();
                                //stworz liste bez ostatnio wybranego kierunku
                                for (int i = 0; i < availibleMovementOptions.Count; i++)
                                {
                                    if (!availibleMovementOptions.ElementAt(i).Equals(previousMoves.Last()))
                                    {
                                        avalibleMovesWithoutLastMove.Add(availibleMovementOptions.ElementAt(i).copy());
                                    }
                                    switch (listSize)
                                    {
                                        case 4:
                                            for (int ii = 0; i < avalibleMovesWithoutLastMove.Count; ii++)
                                            {
                                                extraPoints.Add(avalibleMovesWithoutLastMove.ElementAt(ii));
                                            }
                                            break;
                                        case 5:
                                            for (int j = 0; j < 3; j++)
                                            {
                                                for (int ii = 0; i < avalibleMovesWithoutLastMove.Count; ii++)
                                                {
                                                    extraPoints.Add(avalibleMovesWithoutLastMove.ElementAt(ii));
                                                }

                                            }
                                            break;
                                        case 6:
                                            for (int j = 0; j < 5; j++)
                                            {
                                                for (int ii = 0; i < avalibleMovesWithoutLastMove.Count; ii++)
                                                {
                                                    extraPoints.Add(avalibleMovesWithoutLastMove.ElementAt(ii));
                                                }

                                            }
                                            break;
                                        default:
                                            for (int j = 0; j < 7; j++)
                                            {
                                                for (int ii = 0; ii < avalibleMovesWithoutLastMove.Count; ii++)
                                                {
                                                    extraPoints.Add(avalibleMovesWithoutLastMove.ElementAt(ii));
                                                }

                                            }
                                            break;
                                    }
                                }

                                break;
                        }
                    }
                }
            }
            return extraPoints;
            */
