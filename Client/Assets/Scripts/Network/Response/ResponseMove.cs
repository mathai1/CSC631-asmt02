﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseMoveEventArgs : ExtendedEventArgs
{
	public int user_id { get; set; } // The user_id of whom who sent the request
	public float x { get; set; } // The x coordinate of the target location
	public float y { get; set; } // The y coordinate of the target location
	public float angle { get; set; }

	public ResponseMoveEventArgs()
	{
		event_id = Constants.SMSG_MOVE;
	}
}

public class ResponseMove : NetworkResponse
{
	private int user_id;
	private float x;
	private float y;
	private float angle;

	public ResponseMove()
	{
		
	}

	public override void parse()
	{
		user_id = DataReader.ReadInt(dataStream);
		x = DataReader.ReadFloat(dataStream);
		y = DataReader.ReadFloat(dataStream);
		angle = DataReader.ReadFloat(dataStream);
		
	}

	public override ExtendedEventArgs process()
	{
		ResponseMoveEventArgs args = new ResponseMoveEventArgs
		{
			user_id = user_id,
			x = x,
			y = y,
			angle = angle
		};

		return args;
	}
}
