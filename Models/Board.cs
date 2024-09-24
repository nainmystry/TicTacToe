public class Board
{
    public int _size;
    public PlayingPiece[][] board;

    public Board(int size)
    {
        _size = size;
        board = new PlayingPiece[_size][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new PlayingPiece[_size];
        }
    }

    public bool addPiece(int row, int col, PlayingPiece playingPiece)
    {
        if(board[row][col] != null)
        return false;

        board[row][col] = playingPiece;
        return true;
    }     

    public List<(int,int)> getFreeCells()
    {
        List<(int,int)> freeCells = new List<(int, int)>();
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if(board[i][j] == null)
                {
                    freeCells.Add((i,j));
                }   
            }
        }
        return freeCells;
    }

    public void printBoard()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if(board[i][j] != null)
                {
                    Console.Write(board[i][j]._pieceType.ToString());
                }
                else{
                    Console.Write(string.Empty.PadRight(5));
                }
                Console.Write("  |  ");
            }
            Console.WriteLine();
        }
    }
}