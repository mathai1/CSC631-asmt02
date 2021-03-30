using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestEnemy: NetworkRequest
{
	public RequestEnemy()
	{
		request_id = Constants.CMSG_ENEMY;
	}

	public void send(float x, float y)
	{
		packet = new GamePacket(request_id);
		//packet.addInt32(pieceIndex);
		packet.addFloat32(x);
		packet.addFloat32(y);
	}
}

