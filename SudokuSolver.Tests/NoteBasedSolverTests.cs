using FluentAssertions;
using Xunit;

namespace SudokuSolver.Tests;

public class NoteBasedSolverTests
{
    [Fact]
    public void Solve_GivenAnUnsolvedPuzzleOf1x1Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 0 }
        };

        new NoteBasedSolver(puzzle).Solve();

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

        new NoteBasedSolver(puzzle).Solve();

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

        new NoteBasedSolver(puzzle).Solve();

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

        var solver = new NoteBasedSolver(puzzle);
        solver.Solve();

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
    
    [Fact]
    public void Solve_GivenAnUnsolvedPuzzleOf16x16Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 00, 12, 00, 00, 00, 13, 15, 11, 00, 00, 16, 07, 00, 00, 00, 00 },
            { 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 12, 00, 03, 06, 09 },
            { 00, 00, 00, 00, 00, 00, 12, 00, 00, 00, 14, 00, 15, 00, 00, 00 },
            { 00, 00, 00, 10, 14, 16, 00, 09, 00, 00, 13, 00, 00, 00, 12, 00 },
            { 00, 00, 00, 00, 00, 06, 13, 00, 12, 07, 00, 00, 00, 11, 00, 15 },
            { 00, 00, 00, 00, 00, 14, 00, 00, 00, 00, 00, 09, 00, 01, 00, 00 },
            { 00, 10, 04, 14, 00, 07, 00, 00, 00, 00, 00, 03, 06, 00, 16, 00 },
            { 15, 00, 00, 00, 00, 00, 00, 01, 00, 11, 00, 04, 00, 00, 00, 00 },
            { 10, 13, 05, 06, 00, 12, 00, 04, 00, 01, 03, 00, 11, 00, 09, 00 },
            { 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 11, 00, 00, 00, 00, 07 },
            { 00, 15, 09, 03, 11, 00, 00, 00, 02, 00, 10, 00, 00, 00, 14, 08 },
            { 00, 00, 02, 08, 00, 00, 07, 03, 13, 14, 00, 00, 16, 00, 05, 00 },
            { 00, 06, 00, 11, 02, 15, 00, 00, 00, 10, 00, 08, 12, 00, 04, 00 },
            { 16, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 13, 00, 00, 03, 00 },
            { 00, 00, 10, 15, 00, 01, 16, 08, 00, 00, 09, 00, 14, 06, 00, 00 },
            { 14, 05, 00, 00, 13, 11, 04, 00, 06, 12, 00, 02, 00, 07, 00, 00 }
        };

        var solver = new NoteBasedSolver(puzzle);
        solver.Solve();
    }
}