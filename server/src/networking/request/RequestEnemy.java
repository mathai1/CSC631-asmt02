package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseEnemy;
import utility.DataReader;
import core.NetworkManager;
import utility.Log;

public class RequestEnemy extends GameRequest {
    //private float[] inputs;
    private float x,y;
    // Responses
    private ResponseEnemy responseEnemy;

    public RequestEnemy() {
        responses.add(responseEnemy = new ResponseEnemy());
    }

    @Override
    public void parse() throws IOException {
        //pieceIndex = DataReader.readInt(dataInput);
        x = DataReader.readFloat(dataInput);
        y = DataReader.readFloat(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();
        responseEnemy.setPlayer(player);
        //Log.printf(x + "  "+ y);
        responseEnemy.setData(x, y);
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseEnemy);
    }
}
