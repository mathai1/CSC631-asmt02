using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseEnemyEventArgs : ExtendedEventArgs
{
	public int user_id { get; set; } // The user_id of whom who sent the request
	public float x { get; set; } // The x coordinate of the target location
	public float y { get; set; } // The y coordinate of the target location
	//public float angle { get; set; }

	public ResponseEnemyEventArgs()
	{
		event_id = Constants.SMSG_ENEMY;
	}
}

public class ResponseEnemy : NetworkResponse
{
	private float x;
	private float y;
	//private float angle;

	public ResponseEnemy()
	{
		
	}

	public override void parse()
	{
		//user_id = DataReader.ReadInt(dataStream);
		x = DataReader.ReadFloat(dataStream);
		y = DataReader.ReadFloat(dataStream);
		//angle = DataReader.ReadFloat(dataStream);
		
	}

	public override ExtendedEventArgs process()
	{
		ResponseEnemyEventArgs args = new ResponseEnemyEventArgs
		{
			x = x,
			y = y
		};

		return args;
	}
}

