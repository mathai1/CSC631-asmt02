package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;
/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseMove extends GameResponse {
    private Player player;
    private float x;
    private float y;
    //private int index;

    public ResponseMove() {
        responseCode = Constants.SMSG_MOVE;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        //packet.addInt32(index);
        
        //Log.printf("Player with id %d has moved  to (%a, %a)", player.getID(), x, y);
        packet.addFloat(x);
        packet.addFloat(y);

        return packet.getBytes();
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

    public void setData(float x, float y) {
        this.y = y; 
        this.x = x;
    }
}