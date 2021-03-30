package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;

public class ResponseEnemy extends GameResponse {

    private Player player;
    private float x;
    private float y;
    //private int index;

    public ResponseEnemy() {
        responseCode = Constants.SMSG_ENEMY;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        packet.addFloat(x);
        packet.addFloat(y);

        return packet.getBytes();
    }

    public void setPlayer(Player player) {
        this.player = player;
    }
    public void setData(float x, float y) {
        this.y = y ; 
        this.x = x ;
    }
}
