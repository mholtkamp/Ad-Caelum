/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class DunGen: MonoBehaviour {

	public const int MAP_WIDTH = 30;
	public const int MAP_HEIGHT = 30;
	public int[,] map = new int[MAP_WIDTH,MAP_HEIGHT];
	
	int minRooms;
	int maxRooms;
	int minRoomSize;
	int maxRoomSize;
	
	int enemyCount;
	int enemyMin;
	int enemyMax;
	
	int chestCount;
	
	enum Enemies {	TridentGhost,
					Beamo,
					Torpedo};
	
	public int selectedClass;
	public int difficulty;
	selectedClassScript css;
	
	
	
	void Start () 
	{
	    css = (selectedClassScript) GameObject.Find ("selectedClass").GetComponent(typeof(selectedClassScript));	
		selectedClass = css.selectedClass;
		difficulty = css.difficulty;
		//map = new int[MAP_WIDTH,MAP_HEIGHT];
		
		//Number of rooms
		//minRooms = (MAP_WIDTH * MAP_HEIGHT)/300;
		//maxRooms = (MAP_WIDTH * MAP_HEIGHT)/150;

		
		
		setGenParameters();
		int numRooms = Random.Range (minRooms,maxRooms);
		
		//Create Rooms
		List<Room> roomList = new List<Room>();
		
		bool ok = false;
		bool overlaps = false;
		for(int i = 0; i < numRooms; i++)
		{
			ok = false;
			while(!ok)
			{
				overlaps = false;
				Room candRoom = new Room();
				candRoom.x = Random.Range(0,MAP_WIDTH);
				candRoom.y = Random.Range(0,MAP_HEIGHT);
				candRoom.width = Random.Range(minRoomSize,maxRoomSize);
				candRoom.height = Random.Range(minRoomSize,maxRoomSize);
				
				//Room outside map?
				if(!Room.isInsideMap (candRoom,MAP_WIDTH,MAP_HEIGHT))
					continue;
				
				//Room overlapping other room?
				for(int j = 0; j < roomList.Count;j++)
				{
					if(Room.overlapsRoom(candRoom,roomList[j]))
					{
						overlaps = true;
						break;
					}
				}
				if(!overlaps)
				{
					ok = true;
					roomList.Add (candRoom);
					addRoomToMap(candRoom);
				}
			}
		}
		

		int numConnections = numRooms;
		List<Room> connectedRooms = new List<Room>();
		
		
		for(int i = 0; i < numConnections; i++)
		{
			Room roomA = roomList[i];
			Room roomB = null;
			bool found = false;
			while(!found)
			{
				roomB = roomList[Random.Range (0,roomList.Count - 1)];
				if(roomB != roomA)
					found = true;
			}
			
			int aX = Random.Range (roomA.x,roomA.x + roomA.width);
			int aY = Random.Range (roomA.y,roomA.y + roomA.height);
			int bX = Random.Range (roomB.x,roomB.x + roomB.width);
			int bY = Random.Range (roomB.y,roomB.y + roomB.height);
			
			while((aX != bX) || (aY != bY))
			{
				if(aX != bX)
				{
					if(bX > aX)
						aX++;
					else
						aX--;
				}
				else
				{
					if(bY > aY)
						aY++;
					else
						aY--;
				}
				map[aX,aY] = 1;
			}
			
		}
		//outputMapFile ();
		createTiles();
		createWalls();
		if(selectedClass == 0)// do the warrior 
		  spawnCharacter();
		if(selectedClass == 1)// do the archer
		  spawnCharacterArcher();
		else if(selectedClass == 2)// do the wizard
			spawnWizardCharacter();
		spawnEnemies();
		spawnChests ();
		instantiateHUD ();
		
		
		

	}
	
	void spawnCharacter()
	{
		int x,y;
		x = 0;
		y = 0;
		bool found = false;
		while(!found)
		{
			x = Random.Range(1,MAP_WIDTH);
			y = Random.Range (1,MAP_HEIGHT);
			if(map[x,y] == 1)
				found = true;
		}
		GameObject chara = (GameObject) Instantiate(Resources.Load ("Character"));
		chara.transform.position = new Vector3((float)x,0.3f,(float)y);
		chara.name = "Character";
	}
	
	void spawnCharacterArcher()
	{
		int x,y;
		x = 0;
		y = 0;
		bool found = false;
		while(!found)
		{
			x = Random.Range(1,MAP_WIDTH);
			y = Random.Range (1,MAP_HEIGHT);
			if(map[x,y] == 1)
				found = true;
		}
		GameObject chara = (GameObject) Instantiate(Resources.Load ("CharacterArcher"));
		chara.transform.position = new Vector3((float)x,0.3f,(float)y);
		chara.name = "Character";
	}
	
	void spawnWizardCharacter()
	{
		int x,y;
		x = 0;
		y = 0;
		bool found = false;
		while(!found)
		{
			x = Random.Range(1,MAP_WIDTH);
			y = Random.Range (1,MAP_HEIGHT);
			if(map[x,y] == 1)
				found = true;
		}
		GameObject chara = (GameObject) Instantiate(Resources.Load ("CharacterWizard"));
		chara.transform.position = new Vector3((float)x,0.3f,(float)y);
		chara.name = "Character";
	}
	
	void instantiateHUD()
	{
		(GameObject.Instantiate (Resources.Load ("SpellBarHUD"))).name = "SpellBarHUD";
		(GameObject.Instantiate (Resources.Load ("GUI"))).name = "GUI";
		(GameObject.Instantiate (Resources.Load ("ConjBar"))).name = "ConjBar";
		(GameObject.Instantiate (Resources.Load ("ItemWheel"))).name = "ItemWheel";


	}
	
	void createTiles()
	{
		for(int i = 0; i < MAP_WIDTH; i++)
		{
			for(int j = 0; j < MAP_HEIGHT; j++)
			{
				if(map[i,j] == 1)
				{
					GameObject newTile = (GameObject) Instantiate(Resources.Load ("Tile"));
					newTile.transform.position = new Vector3((float)i,0,(float)j);
				}
			}
		}
	}
	
	void createWalls()
	{
		bool isWall = false;
		for(int i = -1; i <= MAP_WIDTH; i++)
		{
			for(int j = -1; j <= MAP_HEIGHT; j++)
			{
				if((i >= 0)&&(i < MAP_WIDTH)&&(j >= 0)&&(j < MAP_HEIGHT)&&(map[i,j] == 0))
					{
					isWall = false;
					if((j != -1)&&(j != MAP_HEIGHT))
					{
						if((i+1 >= 0) &&(i+1 < MAP_WIDTH))
						{
							if(map[i+1,j] == 1)
								isWall = true;
						}
						if((i-1 >= 0) &&(i-1 < MAP_WIDTH))
						{
							if(map[i-1,j] == 1)
								isWall = true;
						}
					}
					if((i != -1) &&(i != MAP_WIDTH))
					{
						if((j+1 >= 0) &&(j+1 < MAP_HEIGHT))
						{
							if(map[i,j+1] == 1)
								isWall = true;
						}
						if((j-1 >= 0) &&(j-1 < MAP_HEIGHT))
						{
							if(map[i,j-1] == 1)
								isWall = true;
						}
					}
					if(isWall)
					{
						GameObject newWall = (GameObject) Instantiate(Resources.Load ("Wall"));
						newWall.transform.position = new Vector3((float)i,0,(float)j);
					}
				}
				
			}
		}
	
	}
	
	
	void addRoomToMap(Room room)
	{
		for(int i = 0; i < room.width;i++)
		{
			for(int j = 0; j < room.height; j++)
			{
				map[room.x + i, room.y + j] = 1;
			}
		}
	}
	
	void outputMapFile()
	{
		string path = @"c:\users\Martin\Desktop\map.txt";
		File.WriteAllText(path, "");
		
		for(int i = MAP_WIDTH - 1; i >= 0; i--)
		{
			for(int j = 0; j < MAP_HEIGHT; j++)
			{
				File.AppendAllText(path,""+map[j,i] + " ");
			}
			File.AppendAllText (path,System.Environment.NewLine);
		}
	}
	
	private void spawnChests()
	{
		for(int i = 0; i < chestCount; i++)
		{
			GameObject newChest = (GameObject) Instantiate (Resources.Load ("treasure"));
			bool posFound = false;
			while(!posFound)
			{
				int xPos =	Random.Range (0,MAP_WIDTH);
				int yPos =  Random.Range (0,MAP_HEIGHT);
				if(map[xPos,yPos] == 1)
				{
					posFound = true;
					newChest.transform.position = new Vector3(xPos,0.228f,yPos);
				}
				
			}
		}
	}
	
	private void setGenParameters()
	{
		if(Application.loadedLevelName.Equals ("lvl1"))
		{
			minRooms = 8;
			maxRooms = 14;
			minRoomSize = 4;
			maxRoomSize = 8;
			
			enemyCount = 12;
			enemyMin = 0;
			enemyMax = 2;
			
			chestCount = Random.Range (1,5);
			
		}
	}
	
	private void spawnEnemies()
	{
		for(int i = 0; i < enemyCount; i++)
		{
			Enemies en = (Enemies) Random.Range (enemyMin,enemyMax+1);
			GameObject newEnemy = null;
			bool posFound = false;
			
			if(en == Enemies.TridentGhost)
				newEnemy = (GameObject) Instantiate (Resources.Load ("TridentGhost"));
			else if(en == Enemies.Beamo)
				newEnemy = (GameObject) Instantiate (Resources.Load ("beamo"));
			else if(en == Enemies.Torpedo)
				newEnemy = (GameObject) Instantiate (Resources.Load ("TorpedoParent"));
			
			while(!posFound)
			{
				int xPos =	Random.Range (0,MAP_WIDTH);
				int yPos =  Random.Range (0,MAP_HEIGHT);
				if(map[xPos,yPos] == 1)
				{
					posFound = true;
					newEnemy.transform.position = new Vector3(xPos,0.3f,yPos);
				}
				
			}
			
		}
	}
	
	public int getMapValue(int xx, int yy)
	{
		return map[xx,yy];	
	}
	
}
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class DunGen : MonoBehaviour {

	int mapWidth = 30;
	int mapHeight = 30;
	public int[,] map;
	
	int minRooms;
	int maxRooms;
	int minRoomSize;
	int maxRoomSize;
	
	int enemyCount;
	int enemyMin;
	int enemyMax;
	
	int chestCount;
	
	enum Enemies {	TridentGhost,
					Beamo,
					Torpedo,
					CasterGhost};
	
	levelHolderScript lh;
	public int selectedClass;
	public int difficulty;
	selectedClassScript css;
	int charx,chary;
	
	
	void Start () 
	{
		lh = GameObject.Find ("LevelHolder").GetComponent(typeof(levelHolderScript)) as levelHolderScript;
	    css = (selectedClassScript) GameObject.Find ("selectedClass").GetComponent(typeof(selectedClassScript));	
		selectedClass = css.selectedClass;
		setGenParameters();
		map = new int[mapWidth,mapHeight];
		
		//Number of rooms
		//minRooms = (MAP_WIDTH * MAP_HEIGHT)/300;
		//maxRooms = (MAP_WIDTH * MAP_HEIGHT)/150;

		
		//Room sizes
		/*
		int widthRoot = (int) Mathf.Sqrt((float)MAP_WIDTH*2.0f);
		int heightRoot = (int) Mathf.Sqrt ((float) MAP_HEIGHT*2.0f);
		int minRoomWidth = (int) (MAP_WIDTH * 0.5f)/widthRoot;
		int maxRoomWidth = (int) (MAP_WIDTH * 2.0f)/widthRoot;
		int minRoomHeight = (int) (MAP_HEIGHT * 0.5f)/heightRoot;
		int maxRoomHeight = (int) (MAP_HEIGHT * 2.0f)/heightRoot;
		*/
		

		int numRooms = Random.Range (minRooms,maxRooms);
		
		//Create Rooms
		List<Room> roomList = new List<Room>();
		
		bool ok = false;
		bool overlaps = false;
		for(int i = 0; i < numRooms; i++)
		{
			ok = false;
			while(!ok)
			{
				overlaps = false;
				Room candRoom = new Room();
				candRoom.x = Random.Range(0,mapWidth);
				candRoom.y = Random.Range(0,mapHeight);
				candRoom.width = Random.Range(minRoomSize,maxRoomSize);
				candRoom.height = Random.Range(minRoomSize,maxRoomSize);
				
				//Room outside map?
				if(!Room.isInsideMap (candRoom,mapWidth,mapHeight))
				{
					continue;
				}
				
				//Room overlapping other room?
				for(int j = 0; j < roomList.Count;j++)
				{
					if(Room.overlapsRoom(candRoom,roomList[j]))
					{
						overlaps = true;
					}
				}
				
				if(!overlaps)
				{
					ok = true;
					roomList.Add (candRoom);
					addRoomToMap(candRoom);
				}
				
			}

		}
		
		/*
		for(int i =0; i < roomList.Count; i++)
		{
			GameObject newTile = (GameObject) Instantiate(Resources.Load ("Tile"));
			newTile.transform.localScale = new Vector3((float)roomList[i].width,0.01f,(float)roomList[i].height);
			newTile.transform.position = new Vector3((float)roomList[i].x + roomList[i].width/2,0f,(float)roomList[i].y + roomList[i].height/2);
			print (roomList[i].x + " " + roomList[i].y + " " + roomList[i].width + " " + roomList[i].height);
			
		}
		*/
		int numConnections = numRooms;
		List<Room> connectedRooms = new List<Room>();
		
		
		for(int i = 0; i < numConnections; i++)
		{
			Room roomA = roomList[i];
			Room roomB = null;
			bool found = false;
			while(!found)
			{
				roomB = roomList[Random.Range (0,roomList.Count - 1)];
				if(roomB != roomA)
					found = true;
			}
			
			int aX = Random.Range (roomA.x,roomA.x + roomA.width);
			int aY = Random.Range (roomA.y,roomA.y + roomA.height);
			int bX = Random.Range (roomB.x,roomB.x + roomB.width);
			int bY = Random.Range (roomB.y,roomB.y + roomB.height);
			
			while((aX != bX) || (aY != bY))
			{
				if(aX != bX)
				{
					if(bX > aX)
						aX++;
					else
						aX--;
				}
				else
				{
					if(bY > aY)
						aY++;
					else
						aY--;
				}
				map[aX,aY] = 1;
			}
			
		}
		//outputMapFile ();
		createTiles();
		createWalls();
		if(selectedClass == 0)// do the warrior 
		  spawnCharacter();
		else if(selectedClass == 1)// do the archer
		  spawnCharacterArcher();
		else if(selectedClass == 2)// do the wizard
			spawnWizardCharacter();
		spawnEnemies();
		spawnChests ();
		spawnStairCase();
		instantiateHUD ();
		
		
		

	}
	
	void spawnCharacter()
	{
		int x,y;
		x = 0;
		y = 0;
		bool found = false;
		while(!found)
		{
			x = Random.Range(1,mapWidth);
			y = Random.Range (1,mapHeight);
			if(map[x,y] == 1)
				found = true;
		}
		charx = x;
		chary = y;
		GameObject chara = (GameObject) Instantiate(Resources.Load ("Character"));
		chara.transform.position = new Vector3((float)x,0.3f,(float)y);
		chara.name = "Character";
	}
	
	
	void spawnCharacterArcher()
	{
		int x,y;
		x = 0;
		y = 0;
		bool found = false;
		while(!found)
		{
			x = Random.Range(1,mapWidth);
			y = Random.Range (1,mapHeight);
			if(map[x,y] == 1)
				found = true;
		}
		GameObject chara = (GameObject) Instantiate(Resources.Load ("CharacterArcher"));
		chara.transform.position = new Vector3((float)x,0.3f,(float)y);
		chara.name = "Character";
	}
	
	void spawnWizardCharacter()
	{
		int x,y;
		x = 0;
		y = 0;
		bool found = false;
		while(!found)
		{
			x = Random.Range(1,mapWidth);
			y = Random.Range (1,mapHeight);
			if(map[x,y] == 1)
				found = true;
		}
		GameObject chara = (GameObject) Instantiate(Resources.Load ("CharacterWizard"));
		chara.transform.position = new Vector3((float)x,0.3f,(float)y);
		chara.name = "Character";
	}
	
	void instantiateHUD()
	{
		(GameObject.Instantiate (Resources.Load ("SpellBarHUD"))).name = "SpellBarHUD";
		(GameObject.Instantiate (Resources.Load ("GUI"))).name = "GUI";
		(GameObject.Instantiate (Resources.Load ("ConjBar"))).name = "ConjBar";
		(GameObject.Instantiate (Resources.Load ("ItemWheel"))).name = "ItemWheel";


	}
	
	void createTiles()
	{
		for(int i = 0; i < mapWidth; i++)
		{
			for(int j = 0; j < mapHeight; j++)
			{
				if(map[i,j] == 1)
				{
					GameObject newTile = (GameObject) Instantiate(Resources.Load ("Tile"));
					newTile.transform.position = new Vector3((float)i,0,(float)j);
				}
			}
		}
	}
	
	void createWalls()
	{
		bool isWall = false;
		for(int i = -1; i <= mapWidth; i++)
		{
			for(int j = -1; j <= mapHeight; j++)
			{
				if((i >= 0)&&(i < mapWidth)&&(j >= 0)&&(j < mapHeight)&&(map[i,j] == 0))
					{
					isWall = false;
					if((j != -1)&&(j != mapHeight))
					{
						if((i+1 >= 0) &&(i+1 < mapWidth))
						{
							if(map[i+1,j] == 1)
								isWall = true;
						}
						if((i-1 >= 0) &&(i-1 < mapWidth))
						{
							if(map[i-1,j] == 1)
								isWall = true;
						}
					}
					if((i != -1) &&(i != mapWidth))
					{
						if((j+1 >= 0) &&(j+1 < mapHeight))
						{
							if(map[i,j+1] == 1)
								isWall = true;
						}
						if((j-1 >= 0) &&(j-1 < mapHeight))
						{
							if(map[i,j-1] == 1)
								isWall = true;
						}
					}
					if(isWall)
					{
						GameObject newWall = (GameObject) Instantiate(Resources.Load ("Wall"));
						newWall.transform.position = new Vector3((float)i,0,(float)j);
					}
				}
				
			}
		}
	
	}
	
	
	void addRoomToMap(Room room)
	{
		for(int i = 0; i < room.width;i++)
		{
			for(int j = 0; j < room.height; j++)
			{
				map[room.x + i, room.y + j] = 1;
			}
		}
	}
	
	void outputMapFile()
	{
		string path = @"c:\users\Martin\Desktop\map.txt";
		File.WriteAllText(path, "");
		
		for(int i = mapWidth - 1; i >= 0; i--)
		{
			for(int j = 0; j < mapHeight; j++)
			{
				File.AppendAllText(path,""+map[j,i] + " ");
			}
			File.AppendAllText (path,System.Environment.NewLine);
		}
	}
	
	private void spawnChests()
	{
		for(int i = 0; i < chestCount; i++)
		{
			GameObject newChest = (GameObject) Instantiate (Resources.Load ("treasure"));
			bool posFound = false;
			while(!posFound)
			{
				int xPos =	Random.Range (0,mapWidth);
				int yPos =  Random.Range (0,mapHeight);
				if(map[xPos,yPos] == 1)
				{
					posFound = true;
					newChest.transform.position = new Vector3(xPos,0.228f,yPos);
				}
				
			}
		}
	}
	
	private void spawnStairCase()
	{
		GameObject stairs = (GameObject) Instantiate(Resources.Load ("staircase"));
		bool posFound = false;
		while(!posFound)
		{
			int xPos = Random.Range (0,mapWidth);
			int yPos = Random.Range (0,mapHeight);
			if((Mathf.Abs(xPos - charx) < 10) || (Mathf.Abs (yPos - chary) < 10))
				continue;
			if(map[xPos,yPos] == 1)
			{
				posFound = true;
				stairs.transform.position = new Vector3(xPos,0.005f,yPos);	
			}
		}
		
	}
	
	private void setGenParameters()
	{
		if(lh.level == 1)
		{
			mapWidth = 30;
			mapHeight = 30;
			
			minRooms = 8;
			maxRooms = 14;
			minRoomSize = 4;
			maxRoomSize = 8;
			
			if(difficulty == 1)
				enemyCount = 12;
			else if(difficulty == 2)
				enemyCount = 14;
			else
				enemyCount = 18;
		//	enemyCount *= (difficulty/2);
			enemyMin = 0;
			enemyMax = 3;
			
			chestCount = Random.Range (1,5);
			
		}
		else if(lh.level == 2)
		{
			mapWidth = 40;
			mapHeight = 40;
			
			minRooms = 10;
			maxRooms = 16;
			minRoomSize = 4;
			maxRoomSize = 10;
			
			if(difficulty == 1)
				enemyCount = 20;
			else if(difficulty == 2)
				enemyCount = 24;	
			else
				enemyCount = 28;
		//	enemyCount *= (difficulty/2);
			enemyMin = 0;
			enemyMax = 3;
			
			chestCount = Random.Range (1,5);
			
		}
		else if(lh.level == 3)
		{
			mapWidth = 47;
			mapHeight = 47;
			
			minRooms = 15;
			maxRooms = 20;
			minRoomSize = 4;
			maxRoomSize = 10;
			
			enemyCount = 30;
		//	enemyCount *= (difficulty/2);
			enemyMin = 0;
			enemyMax = 3;
			
			chestCount = Random.Range (1,5);
			
		}
		else if(lh.level == 4)
		{
			mapWidth = 55;
			mapHeight = 55;
			
			minRooms = 20;
			maxRooms = 25;
			minRoomSize = 4;
			maxRoomSize = 10;
			
			enemyCount = 40;
		//	enemyCount *= (difficulty/2);
			enemyMin = 0;
			enemyMax = 3;
			
			chestCount = Random.Range (1,5);
			
		}
		else if(lh.level == 5)
		{
			mapWidth = 60;
			mapHeight = 60;
			
			minRooms = 25;
			maxRooms = 30;
			minRoomSize = 4;
			maxRoomSize = 10;
			
			enemyCount = 50;
		//	enemyCount *= (difficulty/2);
			enemyMin = 0;
			enemyMax = 3;
			
			chestCount = Random.Range (1,5);
			
		}
		else
		{
			mapWidth = 30;
			mapHeight = 30;
			
			minRooms = 8;
			maxRooms = 14;
			minRoomSize = 4;
			maxRoomSize = 8;
			
			enemyCount = 12;
			enemyMin = 0;
			enemyMax = 3;
			
			chestCount = Random.Range (1,5);
		}
	}
	
	private void spawnEnemies()
	{
		for(int i = 0; i < enemyCount; i++)
		{
			Enemies en = (Enemies) Random.Range (enemyMin,enemyMax+1);
			GameObject newEnemy = null;
			bool posFound = false;
			
			if(en == Enemies.TridentGhost)
				newEnemy = (GameObject) Instantiate (Resources.Load ("TridentGhost"));
			else if(en == Enemies.Beamo)
				newEnemy = (GameObject) Instantiate (Resources.Load ("beamo"));
			else if(en == Enemies.Torpedo)
				newEnemy = (GameObject) Instantiate (Resources.Load ("TorpedoParent"));
			else if(en == Enemies.CasterGhost)
				newEnemy = (GameObject) Instantiate (Resources.Load ("casterghost"));
			
			while(!posFound)
			{
				int xPos =	Random.Range (0,mapWidth);
				int yPos =  Random.Range (0,mapHeight);
				if(map[xPos,yPos] == 1)
				{
					posFound = true;
					newEnemy.transform.position = new Vector3(xPos,0.3f,yPos);
				}
				
			}
			
		}
	}

	public int getMapValue(int xx, int yy)
	{
		return map[xx,yy];	
	}
	
	void clearMap()
	{
		for(int i = 0; i < mapWidth;i++)
		{
			for(int j = 0; j < mapHeight; j++)
			{
				map[i,j] = 0;	
			}
		}
	}
	
	
}
