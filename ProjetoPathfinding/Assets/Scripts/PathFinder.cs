using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPos, Grid.Position toPosition )
	{
		Queue<Grid.Position> queue = new Queue<Grid.Position>();
        HashSet<Grid.Position> path = new HashSet<Grid.Position>();
        List<Grid.Position> returnPath = new List<Grid.Position>();
        Grid.Position[,] Tiles = new Grid.Position[tiles.GetLength(0), tiles.GetLength(1)];
        Tiles[fromPos.x, fromPos.y] = fromPos;
        queue.Enqueue(fromPos);

		while(queue.Count > 0) 
		{
			Grid.Position posDequeued = queue.Dequeue ();
			if(posDequeued.Equals(toPosition)) 
			{
                returnPath.Add(posDequeued);
                while(posDequeued.x != fromPos.x || posDequeued.y != fromPos.y)
                {
                    posDequeued = Tiles[posDequeued.x, posDequeued.y];
                    returnPath.Add(posDequeued);
                }
                returnPath.Reverse();
                break;
            } 
			else 
			{
                if(Tile.InsideGrid(new Grid.Position(posDequeued.x, posDequeued.y + 1), tiles)
                   && !path.Contains(new Grid.Position(posDequeued.x, posDequeued.y + 1)))
                {
                    queue.Enqueue(new Grid.Position(posDequeued.x, posDequeued.y + 1));
                    path.Add(posDequeued);
                    Tiles[posDequeued.x, posDequeued.y + 1] = posDequeued;
                }
                if(Tile.InsideGrid(new Grid.Position(posDequeued.x, posDequeued.y - 1), tiles)
                   && !path.Contains(new Grid.Position(posDequeued.x, posDequeued.y - 1)))
                {
                    queue.Enqueue(new Grid.Position(posDequeued.x, posDequeued.y - 1));
                    path.Add(posDequeued);
                    Tiles[posDequeued.x, posDequeued.y - 1] = posDequeued;
                }
                if(Tile.InsideGrid(new Grid.Position(posDequeued.x + 1, posDequeued.y), tiles)
                   && !path.Contains(new Grid.Position(posDequeued.x + 1, posDequeued.y)))
                {
                    queue.Enqueue(new Grid.Position(posDequeued.x + 1, posDequeued.y));
                    path.Add(posDequeued);
                    Tiles[posDequeued.x + 1, posDequeued.y] = posDequeued;
                }
                if(Tile.InsideGrid(new Grid.Position(posDequeued.x - 1, posDequeued.y), tiles)
                   && !path.Contains(new Grid.Position(posDequeued.x - 1, posDequeued.y)))
                {
                    queue.Enqueue(new Grid.Position(posDequeued.x - 1, posDequeued.y));
                    path.Add(posDequeued);
                    Tiles[posDequeued.x - 1, posDequeued.y] = posDequeued;
                }
			}
        }
        return returnPath;
	}

}
