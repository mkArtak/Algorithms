using System;

namespace AM.Core.Algorithms.Puzzles;

public class RobotCleaningVacuum
{
    public int NumberOfCleanRooms(int[][] roomMap)
    {
        // Prepare a storage for memorizing the rooms that were cleaned
        var visitedRooms = new bool[roomMap.Length][];
        for (int i = 0; i < roomMap.Length; i++)
        {
            visitedRooms[i] = new bool[roomMap[i].Length];
        }

        visitedRooms[0][0] = true;

        var roomsCleaned = 1;

        var currentPosition = new Position(0, 0);
        var direction = new Direction(0, 1);

        do
        {
            var nextPosition = GetNextPosition(currentPosition, direction);
            var numberOfTurns = 0;
            while (IsOutOfMap(nextPosition, roomMap) || HasObject(nextPosition, roomMap))
            {
                numberOfTurns++;
                direction = TurnRight(direction);
                nextPosition = GetNextPosition(currentPosition, direction);

                if (numberOfTurns == 4)
                {
                    // no place to go. Give up and return the number of traveled spots
                    return roomsCleaned;
                }
            }

            currentPosition = nextPosition;
            if (!visitedRooms[currentPosition.Row][currentPosition.Col])
            {
                visitedRooms[currentPosition.Row][currentPosition.Col] = true;
                roomsCleaned++;
            }
            else
            {
                // This cell has already been visited. So we just entered a loop and need to stop and break here.
                break;
            }
        } while (true);

        return roomsCleaned;
    }

    private bool HasObject(Position nextPosition, int[][] roomMap) => roomMap[nextPosition.Row][nextPosition.Col] == 1;

    private bool IsOutOfMap(Position nextPosition, int[][] roomMap)
    {
        return nextPosition.Row < 0 || nextPosition.Row >= roomMap.Length
            || nextPosition.Col < 0 || nextPosition.Col >= roomMap[nextPosition.Row].Length;
    }

    private Direction TurnRight(Direction direction)
    {
        return direction switch
        {
            (0, 1) => new Direction(1, 0),
            (1, 0) => new Direction(0, -1),
            (0, -1) => new Direction(-1, 0),
            (-1, 0) => new Direction(0, 1),
            _ => throw new NotSupportedException()
        };
        /*
         * [0,1] => [1,0]
         * [1,0] => [0, -1]
         * [0,-1] => [-1, 0]
         * [-1,0] => [0, 1]]
         * */
    }

    private static Position GetNextPosition(Position current, Direction direction) => new Position(current.Row + direction.RowDirection, current.Col + direction.ColDirection);

    record Position(int Row, int Col);

    record Direction(int RowDirection, int ColDirection);
}
