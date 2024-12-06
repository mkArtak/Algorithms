using Xunit;

namespace AM.Core.Algorithms.Puzzles.Tests;

public class RobotCleaningVacuumTests
{
    [Fact]
    public void NumberOfCleanRooms_ReturnsOneForSingleRoom()
    {
        int[][] roomsMap = [[0]];

        var sut = new RobotCleaningVacuum();
        Assert.Equal(1, sut.NumberOfCleanRooms(roomsMap));
    }

    [Fact]
    public void NumberOfCleanRooms_Succeeds()
    {
        int[][] roomsMap = [[0, 0, 0], [1, 1, 0], [0, 0, 0]];

        var sut = new RobotCleaningVacuum();
        Assert.Equal(7, sut.NumberOfCleanRooms(roomsMap));
    }
    
    [Fact]
    public void NumberOfCleanRooms_SucceedsForSingleBlockedRoom()
    {
        int[][] roomsMap = [[0, 1, 0], [1, 0, 0], [0, 0, 0]];

        var sut = new RobotCleaningVacuum();
        Assert.Equal(1, sut.NumberOfCleanRooms(roomsMap));
    }
}
