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

        new NoteBasedSolver(puzzle).Solve();
            
        var expected = new[,]
        {
            { 05, 12, 06, 04, 03, 13, 15, 11, 09, 02, 16, 07, 01, 14, 08, 10 },
            { 11, 14, 13, 16, 01, 08, 10, 07, 15, 05, 04, 12, 02, 03, 06, 09 },
            { 02, 09, 01, 07, 06, 04, 12, 05, 03, 08, 14, 10, 15, 16, 11, 13 },
            { 08, 03, 15, 10, 14, 16, 02, 09, 11, 06, 13, 01, 07, 05, 12, 04 },
            { 03, 01, 16, 05, 04, 06, 13, 02, 12, 07, 08, 14, 09, 11, 10, 15 },
            { 06, 07, 11, 13, 10, 14, 08, 12, 05, 16, 15, 09, 04, 01, 02, 03 },
            { 09, 10, 04, 14, 05, 07, 11, 15, 01, 13, 02, 03, 06, 08, 16, 12 },
            { 15, 08, 12, 02, 16, 03, 09, 01, 10, 11, 06, 04, 05, 13, 07, 14 },
            { 10, 13, 05, 06, 08, 12, 14, 04, 07, 01, 03, 16, 11, 15, 09, 02 },
            { 04, 16, 14, 12, 15, 02, 06, 13, 08, 09, 11, 05, 03, 10, 01, 07 },
            { 07, 15, 09, 03, 11, 05, 01, 16, 02, 04, 10, 06, 13, 12, 14, 08 },
            { 01, 11, 02, 08, 09, 10, 07, 03, 13, 14, 12, 15, 16, 04, 05, 06 },
            { 13, 06, 07, 11, 02, 15, 03, 14, 16, 10, 05, 08, 12, 09, 04, 01 },
            { 16, 04, 08, 01, 12, 09, 05, 06, 14, 15, 07, 13, 10, 02, 03, 11 },
            { 12, 02, 10, 15, 07, 01, 16, 08, 04, 03, 09, 11, 14, 06, 13, 05 },
            { 14, 05, 03, 09, 13, 11, 04, 10, 06, 12, 01, 02, 08, 07, 15, 16 }
        };
        puzzle.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Solve_GivenAnotherUnsolvedPuzzleOf16x16Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 01, 00, 00, 00, 00, 00, 12, 11, 04, 00, 07, 09, 00, 06, 00, 00 },
            { 00, 00, 12, 00, 10, 00, 14, 00, 16, 00, 01, 00, 05, 00, 00, 00 },
            { 00, 00, 00, 00, 00, 00, 16, 00, 00, 00, 00, 11, 14, 00, 02, 04 },
            { 00, 00, 04, 00, 08, 00, 00, 00, 00, 00, 13, 00, 00, 00, 15, 00 },
            { 14, 00, 00, 04, 00, 16, 09, 00, 00, 13, 00, 03, 00, 15, 00, 00 },
            { 13, 03, 02, 00, 00, 00, 00, 12, 09, 00, 14, 06, 00, 00, 00, 00 },
            { 10, 00, 00, 09, 07, 00, 00, 13, 00, 00, 11, 16, 00, 00, 08, 05 },
            { 00, 01, 00, 00, 02, 00, 11, 00, 00, 05, 00, 00, 00, 00, 09, 14 },
            { 00, 00, 00, 07, 00, 00, 00, 00, 00, 15, 00, 00, 00, 04, 10, 08 },
            { 16, 15, 00, 00, 00, 00, 10, 08, 00, 00, 00, 13, 06, 00, 07, 11 },
            { 00, 00, 10, 11, 00, 00, 00, 00, 12, 00, 00, 00, 09, 00, 14, 13 },
            { 09, 00, 00, 00, 14, 00, 13, 00, 00, 11, 00, 00, 00, 00, 16, 12 },
            { 00, 00, 00, 00, 00, 00, 06, 00, 00, 00, 00, 00, 00, 00, 13, 00 },
            { 00, 00, 00, 08, 13, 11, 00, 14, 00, 07, 15, 00, 00, 00, 04, 00 },
            { 02, 13, 00, 01, 15, 00, 00, 00, 14, 08, 00, 00, 11, 10, 00, 16 },
            { 15, 00, 05, 00, 00, 08, 00, 16, 00, 00, 06, 00, 00, 01, 00, 00 }
        };

        new NoteBasedSolver(puzzle).Solve();
            
        var expected = new[,]
        {
            { 01, 16, 08, 15, 05, 02, 12, 11, 04, 14, 07, 09, 13, 06, 03, 10 },
            { 06, 07, 12, 02, 10, 13, 14, 04, 16, 03, 01, 15, 05, 08, 11, 09 },
            { 05, 09, 03, 13, 06, 01, 16, 15, 08, 12, 10, 11, 14, 07, 02, 04 },
            { 11, 14, 04, 10, 08, 09, 07, 03, 05, 06, 13, 02, 12, 16, 15, 01 },
            { 14, 12, 11, 04, 01, 16, 09, 05, 07, 13, 08, 03, 10, 15, 06, 02 },
            { 13, 03, 02, 05, 04, 15, 08, 12, 09, 10, 14, 06, 16, 11, 01, 07 },
            { 10, 06, 15, 09, 07, 14, 03, 13, 02, 01, 11, 16, 04, 12, 08, 05 },
            { 08, 01, 07, 16, 02, 10, 11, 06, 15, 05, 12, 04, 03, 13, 09, 14 },
            { 03, 02, 13, 07, 11, 12, 05, 09, 06, 15, 16, 14, 01, 04, 10, 08 },
            { 16, 15, 14, 12, 03, 04, 10, 08, 01, 09, 05, 13, 06, 02, 07, 11 },
            { 04, 08, 10, 11, 16, 06, 15, 01, 12, 02, 03, 07, 09, 05, 14, 13 },
            { 09, 05, 01, 06, 14, 07, 13, 02, 10, 11, 04, 08, 15, 03, 16, 12 },
            { 07, 04, 09, 03, 12, 05, 06, 10, 11, 16, 02, 01, 08, 14, 13, 15 },
            { 12, 10, 16, 08, 13, 11, 01, 14, 03, 07, 15, 05, 02, 09, 04, 06 },
            { 02, 13, 06, 01, 15, 03, 04, 07, 14, 08, 09, 12, 11, 10, 05, 16 },
            { 15, 11, 05, 14, 09, 08, 02, 16, 13, 04, 06, 10, 07, 01, 12, 03 }
        };
        puzzle.Should().BeEquivalentTo(expected);
    }
    
    [Fact(Skip = "Not working yet")]
    public void Solve_GivenAnUnsolvedPuzzleOf25x25Size_SolvesIt()
    {
        var puzzle = new[,]
        {
            { 14, 00, 22, 00, 21, 00, 00, 01, 03, 00, 00, 00, 00, 00, 19, 00, 00, 07, 00, 02, 15, 00, 08, 08, 00 },
            { 00, 00, 00, 01, 00, 02, 00, 00, 19, 00, 14, 08, 12, 00, 00, 00, 00, 23, 00, 25, 00, 04, 00, 00, 00 },
            { 08, 02, 00, 00, 00, 05, 00, 00, 14, 00, 13, 10, 00, 04, 21, 00, 15, 00, 00, 00, 24, 18, 06, 00, 00 },
            { 00, 13, 23, 00, 00, 15, 00, 00, 00, 22, 20, 07, 00, 00, 18, 06, 00, 16, 00, 21, 02, 00, 01, 03, 00 },
            { 00, 19, 00, 06, 05, 00, 00, 25, 13, 11, 00, 00, 01, 15, 03, 08, 00, 00, 12, 00, 16, 00, 00, 20, 00 },
            { 19, 06, 00, 00, 00, 00, 22, 00, 00, 00, 04, 01, 00, 00, 00, 00, 00, 00, 23, 00, 08, 00, 21, 00, 15 },
            { 00, 00, 18, 11, 00, 00, 00, 00, 20, 02, 00, 00, 10, 17, 06, 00, 21, 12, 08, 01, 23, 00, 24, 05, 14 },
            { 00, 00, 00, 00, 04, 00, 00, 21, 00, 00, 05, 08, 00, 00, 00, 00, 03, 00, 00, 15, 00, 00, 22, 00, 17 },
            { 00, 24, 14, 08, 00, 00, 00, 15, 11, 17, 21, 13, 03, 00, 00, 05, 00, 00, 18, 00, 00, 00, 19, 01, 00 },
            { 00, 00, 01, 21, 15, 06, 00, 00, 00, 00, 00, 22, 20, 19, 00, 00, 00, 10, 00, 13, 03, 07, 00, 11, 16 },
            { 00, 16, 00, 00, 00, 13, 17, 06, 18, 00, 25, 00, 24, 08, 00, 00, 00, 11, 15, 10, 19, 00, 02, 00, 03 },
            { 00, 20, 00, 08, 24, 19, 10, 00, 00, 00, 11, 00, 00, 00, 00, 00, 00, 00, 00, 00, 05, 00, 14, 00, 00 },
            { 18, 00, 05, 03, 13, 00, 11, 00, 00, 23, 00, 04, 00, 10, 00, 14, 00, 00, 20, 00, 01, 16, 25, 00, 08 },
            { 00, 00, 17, 00, 11, 00, 00, 00, 00, 00, 00, 00, 00, 00, 07, 00, 00, 00, 25, 04, 21, 08, 00, 15, 00 },
            { 25, 00, 04, 00, 19, 24, 12, 07, 00, 00, 00, 20, 18, 00, 02, 00, 08, 03, 05, 08, 00, 00, 00, 06, 00 },
            { 05, 18, 00, 23, 01, 25, 00, 02, 00, 00, 00, 03, 17, 20, 00, 00, 00, 00, 00, 24, 07, 13, 04, 00, 00 },
            { 00, 22, 03, 00, 00, 00, 18, 00, 00, 08, 00, 00, 06, 01, 13, 07, 19, 08, 00, 00, 00, 21, 10, 24, 00 },
            { 07, 00, 24, 00, 00, 04, 00, 00, 01, 00, 00, 00, 00, 02, 22, 00, 00, 14, 00, 00, 20, 00, 00, 00, 00 },
            { 20, 08, 21, 00, 02, 11, 15, 23, 24, 00, 07, 16, 25, 00, 00, 22, 04, 00, 00, 00, 00, 05, 12, 00, 00 },
            { 15, 00, 13, 00, 14, 00, 06, 00, 00, 00, 00, 00, 00, 23, 04, 00, 00, 00, 10, 00, 00, 00, 00, 25, 18 },
            { 00, 11, 00, 00, 17, 00, 04, 00, 00, 15, 23, 24, 08, 00, 00, 18, 14, 05, 00, 00, 10, 25, 00, 19, 00 },
            { 00, 12, 06, 00, 18, 21, 00, 24, 00, 25, 19, 00, 00, 22, 17, 10, 00, 00, 00, 11, 00, 00, 08, 08, 00 },
            { 00, 00, 07, 04, 10, 00, 00, 00, 17, 00, 16, 02, 00, 06, 25, 00, 08, 00, 00, 12, 00, 00, 00, 21, 05 },
            { 00, 00, 00, 24, 00, 10, 00, 11, 00, 00, 00, 00, 07, 05, 01, 00, 20, 00, 00, 17, 00, 23, 00, 00, 00 },
            { 00, 15, 08, 00, 22, 08, 00, 05, 00, 00, 10, 00, 00, 00, 00, 00, 24, 25, 00, 00, 18, 00, 17, 00, 01 },
        };

        new NoteBasedSolver(puzzle).Solve();
            
        var expected = new[,]
        {
            { 01, 00, 00, 00, 00, 00, 12, 11, 04, 00, 07, 09, 00, 06, 00, 00 },
            { 00, 00, 12, 00, 10, 00, 14, 00, 16, 00, 01, 00, 05, 00, 00, 00 },
            { 00, 00, 00, 00, 00, 00, 16, 00, 00, 00, 00, 11, 14, 00, 02, 04 },
            { 00, 00, 04, 00, 08, 00, 00, 00, 00, 00, 13, 00, 00, 00, 15, 00 },
            { 14, 00, 00, 04, 00, 16, 09, 00, 00, 13, 00, 03, 00, 15, 00, 00 },
            { 13, 03, 02, 00, 00, 00, 00, 12, 09, 00, 14, 06, 00, 00, 00, 00 },
            { 10, 00, 00, 09, 07, 00, 00, 13, 00, 00, 11, 16, 00, 00, 06, 05 },
            { 00, 01, 00, 00, 02, 00, 11, 00, 00, 05, 00, 00, 00, 00, 09, 14 },
            { 00, 00, 00, 07, 00, 00, 00, 00, 00, 15, 00, 00, 00, 04, 10, 06 },
            { 16, 15, 00, 00, 00, 00, 10, 06, 00, 00, 00, 13, 06, 00, 07, 11 },
            { 00, 00, 10, 11, 00, 00, 00, 00, 12, 00, 00, 00, 09, 00, 14, 13 },
            { 09, 00, 00, 00, 14, 00, 13, 00, 00, 11, 00, 00, 00, 00, 16, 12 },
            { 00, 00, 00, 00, 00, 00, 06, 00, 00, 00, 00, 00, 00, 00, 13, 00 },
            { 00, 00, 00, 06, 13, 11, 00, 14, 00, 07, 15, 00, 00, 00, 04, 00 },
            { 02, 13, 00, 01, 15, 00, 00, 00, 14, 06, 00, 00, 11, 10, 00, 16 },
            { 15, 00, 05, 00, 00, 06, 00, 16, 00, 00, 06, 00, 00, 01, 00, 00 }
        };
        puzzle.Should().BeEquivalentTo(expected);
    }
}
