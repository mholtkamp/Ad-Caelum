using UnityEngine;
using System.Collections;

public class Room{

	public int x,y,width,height;
	
	public Room()
	{
		x = 0;
		y = 0;
		width = 0;
		height = 0;
	}
	
	public Room(int x,int y,int width,int height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}
	
	public static bool isInsideMap(Room room,int width,int height)
	{
		if(room.x < 1)
			return false;
		if(room.x + room.width > width-1)
			return false;
		if(room.y < 1)
			return false;
		if(room.y + room.height > height-1)
			return false;
		
		return true;
	}
	
	public static bool overlapsRoom(Room room1, Room room2)
	{
		if(room1.x + room1.width < room2.x)
			return false;
		if(room1.x > room2.x + room2.width)
			return false;
		if(room1.y + room1.height < room2.y)
			return false;
		if(room1.y > room2.y + room2.height)
			return false;
		
		return true;
	}
}
