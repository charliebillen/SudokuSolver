using System.Collections;

namespace SudokuSolver;

public class NoteBasedSolver
{
    private class Notes : IEnumerable<KeyValuePair<(int, int), HashSet<int>>>
    {
        private readonly Dictionary<(int, int), HashSet<int>> _notes = new();

        public IEnumerable<HashSet<int>> Values => _notes.Values;

        public HashSet<int> this[int row, int col]
        {
            get => GetOrCreate((row, col));
            set => _notes[(row, col)] = value;
        }

        private HashSet<int> GetOrCreate((int, int) key)
        {
            if (!_notes.ContainsKey(key))
                _notes[key] = new HashSet<int>();
                
            return _notes[key];
        }

        public IEnumerator<KeyValuePair<(int, int), HashSet<int>>> GetEnumerator() 
            => _notes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => ((IEnumerable)_notes).GetEnumerator();
    }
    
    private readonly int[,] _puzzle;
    private readonly int _size;
    private readonly int _sqrSize;
    private readonly Notes _notes;

    public NoteBasedSolver(int[,] puzzle)
    {
        _puzzle = puzzle;
        _size = puzzle.GetLength(0);
        _sqrSize = (int)Math.Sqrt(_size);
        _notes = new Notes();
    }

    public bool Solve()
    {
        var complete = false;
        do
        {
            BuildNotes();
            ApplyNotes();
            complete = _notes.Values.All(n => n.Count == 1);
        } while (!complete);

        return complete;
    }

    private void BuildNotes()
    {
        for (var row = 0; row < _size; row++)
        {
            for (var col = 0; col < _size; col++)
            {
                var cellValue = _puzzle[row, col];
                if (cellValue > 0)
                {
                    _notes[row, col].Add(cellValue);
                }
                else
                {
                    _notes[row, col] = GetAllowedValues(row, col);;
                }
            }
        }
    }

    private void ApplyNotes()
    {
        foreach (var ((row, col), values) in _notes)
        {
            if (values.Count == 1)
                _puzzle[row, col] = values.First();
        }
    }

    private HashSet<int> GetAllowedValues(int row, int col) 
        => Enumerable.Range(1, _size).Where(g => IsValidGuess(g, row, col)).ToHashSet();

    private bool IsValidGuess(int guess, int row, int col)
    {
        var squareStartRow = row - row % _sqrSize;
        var squareStartCol = col - col % _sqrSize;

        for (var i = 0; i < _size; i++)
        {
            // check cols in same row
            if (_puzzle[row, i] == guess)
                return false;

            // check rows in same col
            if (_puzzle[i, col] == guess)
                return false;

            // check subgrid
            var squareRow = squareStartRow + i / _sqrSize;
            var squareCol = squareStartCol + i % _sqrSize;
            if (_puzzle[squareRow, squareCol] == guess)
                return false;
        }

        return true;
    }
}
