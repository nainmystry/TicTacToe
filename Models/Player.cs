public class Player
{
    public string _name;
    public PlayingPiece _playingPiece;
    
    public Player(string name, PlayingPiece playingPiece)
    {
        _name = name;
        _playingPiece = playingPiece;
    }

    public string getName(){
        return _name;
    }

    public void setName(string name)
    {
        _name = name;
    }

    public PlayingPiece getPlayingPiece(){
        return _playingPiece;
    }

     public void setPlayingPiece(PlayingPiece playingPiece) {
        _playingPiece = playingPiece;
    }

}