public class Game
{
    LinkedList<Player> players;
    Board board;

    public void initializeGame(){
        players = new LinkedList<Player>();

        PlayingPieceX playingPieceX = new PlayingPieceX();
        Player p1 = new Player("Player1", playingPieceX);

        PlayingPieceO playingPieceO = new PlayingPieceO();
        Player p2 = new Player("Player2", playingPieceO);

        players.AddLast(p1);
        players.AddLast(p2);

        board = new Board(3);
    }

    public string startGame()
    {
        bool noWinner = true;
        while(noWinner)
        {
            Player player = players.First();
            players.RemoveFirst();

            board.printBoard();
            List<(int,int)> freeIndex = board.getFreeCells();
            if(freeIndex.Count == 0)
            {
                noWinner = false;
                break;
            }

            Console.WriteLine("Player:" + player._name + " Enter row,column: ");
            String inputIndex = Console.ReadLine();
            var indexes = inputIndex?.Split(",");
            int row = int.Parse(indexes[0]);
            int col = int.Parse(indexes[1]);

            bool pieceAdded = board.addPiece(row, col, player._playingPiece);
            if(!pieceAdded)
            {
                Console.WriteLine("Incorredt possition chosen, try again");
                players.AddFirst(player);
                continue;
            }

            players.AddLast(player);

            bool winner = isWinner(row, col, player._playingPiece);
            if(winner) {
                board.printBoard();
                return player._name;
            }

        }
        return "tie";
    }

    private bool isWinner(int row, int col, PlayingPiece playingPiece)
    {

        bool rowMatch = true;
        bool colMatch = true;
        bool diagonalMatch = true;
        bool antiDiagMatch = true;        

        for(int i=0;i<board._size;i++) {
            if(board.board[row][i] == null || board.board[row][i]._pieceType != playingPiece._pieceType) {
                rowMatch = false;
            }
            if(board.board[i][col] == null || board.board[i][col]._pieceType != playingPiece._pieceType)
            {
                colMatch = false;
            }
        }

        for(int i = 0, j = 0; j < board._size; i++, j++)
        {
            if(board.board[i][j] == null || board.board[i][j]._pieceType != playingPiece._pieceType)
            {
                diagonalMatch = false;
            }
        }

        for(int i = 0, j = board._size - 1; i < board._size; i++, j--)
        {
            if(board.board[i][j] == null || board.board[i][j]._pieceType != playingPiece._pieceType)
            {
                antiDiagMatch = false;
            }
        }

        return rowMatch || colMatch || diagonalMatch || antiDiagMatch;
    }
}