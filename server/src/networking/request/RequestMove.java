package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseMove;
import utility.DataReader;
import core.NetworkManager;
import utility.Log;

public class RequestMove extends GameRequest {
    //private float[] inputs;
    private float x,y,angle;
    // Responses
    private ResponseMove responseMove;

    public RequestMove() {
        responses.add(responseMove = new ResponseMove());
    }

    @Override
    public void parse() throws IOException {
        //pieceIndex = DataReader.readInt(dataInput);
        x = DataReader.readFloat(dataInput);
        y = DataReader.readFloat(dataInput);
        angle=DataReader.readFloat(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();
        responseMove.setPlayer(player);
        //Log.printf(x + "  "+ y);
        responseMove.setData(x, y,angle);
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseMove);
    }
}