namespace SudokuSolver;

public class BruteForceSolver
{
    private readonly int[,] _puzzle;
    private readonly int _puzzleSize;
    private readonly int _squareSize;

    public int Backtracks = 0;

    public BruteForceSolver(int[,] puzzle)
    {
        _puzzle = puzzle;
        _puzzleSize = _puzzle.GetLength(0);
        _squareSize = (int)Math.Sqrt(_puzzleSize);
    }

    public bool Solve(int row = 0, int col = 0)
    {
        if (row == _puzzleSize - 1 && col == _puzzleSize)
            return true;

        if (col == _puzzleSize)
            return Solve(row + 1, 0);

        if (_puzzle[row, col] > 0)
            return Solve(row, col + 1);

        for (var g = 1; g <= _puzzleSize; g++)
        {
            if (!IsValidGuess(g, row, col)) 
                continue;
            
            _puzzle[row,col] = g;
    
            if (Solve(row, col + 1))
                return true;
        }

        Backtracks++;
        _puzzle[row, col] = 0;
        return false;
    }

    private bool IsValidGuess(int guess, int row, int col)
    {
        var squareStartRow = row - row % _squareSize;
        var squareStartCol = col - col % _squareSize;

        for (var i = 0; i < _puzzleSize; i++)
        {
            // check cols in same row
            if (_puzzle[row, i] == guess)
                return false;

            // check rows in same col
            if (_puzzle[i, col] == guess)
                return false;

            // check subgrid
            var squareRow = squareStartRow + i / _squareSize;
            var squareCol = squareStartCol + i % _squareSize;
            if (_puzzle[squareRow, squareCol] == guess)
                return false;
        }

        return true;
    }
}
