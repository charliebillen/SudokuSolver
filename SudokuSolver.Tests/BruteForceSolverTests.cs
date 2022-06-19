using FluentAssertions;
using Xunit;

namespace SudokuSolver.Tests;

public class BruteForceSolverTests
{
    [Fact]
    public void Solve_GivenAnUnsolvedPuzzleOf1x1Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 0 }
        };

        BruteForceSolver.Solve(puzzle);

        var expected = new[,]
        {
            { 1 }
        };
        puzzle.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Solve_GivenAnUnsolvedPuzzleOf2x2Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 1, 0 },
            { 2, 1 }
        };

        BruteForceSolver.Solve(puzzle);

        var expected = new[,]
        {
            { 1, 2 },
            { 2, 1 }
        };
        puzzle.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Solve_GivenAnUnsolvedPuzzleOf4x4Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 0, 0, 0, 3 },
            { 2, 0, 1, 0 },
            { 0, 0, 0, 1 },
            { 0, 0, 4, 0 }
        };

        BruteForceSolver.Solve(puzzle);

        var expected = new[,]
        {
            { 1, 4, 2, 3 },
            { 2, 3, 1, 4 },
            { 4, 2, 3, 1 },
            { 3, 1, 4, 2 }
        };
        puzzle.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Solve_GivenAnUnsolvedPuzzleOf9x9Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 8, 0, 0, 0, 0, 0, 0, 5, 0 },
            { 0 ,0, 5, 9, 2, 0, 0, 0, 0 },
            { 0, 3, 6, 0, 0, 4, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 2, 3, 0 },
            { 1, 0, 0, 0, 0, 0, 4, 0, 0 },
            { 0, 4, 3, 0, 5, 0, 0, 7, 0 },
            { 2, 0, 8, 0, 6, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 6, 2 },
            { 0, 0, 1, 0, 0, 0, 8, 0, 4 }
        };

        BruteForceSolver.Solve(puzzle);

        var expected = new[,]
        {
            { 8, 2, 4, 6, 1, 7, 9, 5, 3 },
            { 7 ,1, 5, 9, 2, 3, 6, 4, 8 },
            { 9, 3, 6, 5, 8, 4, 7, 2, 1 },
            { 5, 8, 9, 7, 4, 1, 2, 3, 6 },
            { 1, 7, 2, 3, 9, 6, 4, 8, 5 },
            { 6, 4, 3, 8, 5, 2, 1, 7, 9 },
            { 2, 5, 8, 4, 6, 9, 3, 1, 7 },
            { 4, 9, 7, 1, 3, 8, 5, 6, 2 },
            { 3, 6, 1, 2, 7, 5, 8, 9, 4 }
        };
        puzzle.Should().BeEquivalentTo(expected);
    }
}
