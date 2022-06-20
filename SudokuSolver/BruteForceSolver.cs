namespace SudokuSolver;

public static class BruteForceSolver
{
    public static bool Solve(int[,] puzzle, int row = 0, int col = 0)
    {
        var size = puzzle.GetLength(0);

        if (row == size - 1 && col == size)
            return true;

        if (col == size)
            return Solve(puzzle, row + 1, 0);

        if (puzzle[row, col] > 0)
            return Solve(puzzle, row, col + 1);

        for (var g = 1; g <= size; g++)
        {
            if (!IsValidGuess(g, puzzle, row, col)) 
                continue;
            
            puzzle[row,col] = g;
    
            if (Solve(puzzle, row, col + 1))
                return true;

            puzzle[row, col] = 0;
        }

        return false;
    }

    private static bool IsValidGuess(int guess, int[,] puzzle, int row, int col)
    {
        var size = puzzle.GetLength(0);
        
        var subgridSize = (int)Math.Sqrt(size);
        var subgridStartRow = row - row % subgridSize;
        var subgridStartCol = col - col % subgridSize;
        
        for (var i = 0; i < size; i++)
        {
            // check cols in same row
            if (puzzle[row, i] == guess)
                return false;
            
            // check rows in same col
            if (puzzle[i, col] == guess)
                return false;
            
            // check subgrid
            var subgridRow = subgridStartRow + i / subgridSize;
            var subgridCol = subgridStartCol + i % subgridSize;
            if (puzzle[subgridRow, subgridCol] == guess)
                return false;
        }

        return true;
    }
}
