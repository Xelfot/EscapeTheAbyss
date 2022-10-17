using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSpawner : MonoBehaviour
{
    [HideInInspector]
    public Room[,] spawnedRooms;
    public Room[] RoomPrefabs;
    public List<Room> soloRooms;
    public Room startRoom;
    public Room exitRoom;
    public Room keyRoom;
    public int roomsSpawned;

    private void Start()
    {
        spawnedRooms = new Room[21,21];
        spawnedRooms[10, 10] = startRoom;
        SpawnDungeon();
    }

    void SpawnDungeon()
    {
        for (int i = 0; i < roomsSpawned; i++)
        {
            CreateRoom();
        }
        ChangeDungeon();
    }

    private void ChangeDungeon()
    {
        if (CountSoloRooms()) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else SetSpecialRooms();
    }

    private void SetSpecialRooms()
    {
        int randIndex = Random.Range(0, soloRooms.Count);
        int secRandIndex = Random.Range(0, soloRooms.Count);

        while (secRandIndex == randIndex)
        {
            secRandIndex = Random.Range(0, soloRooms.Count);
        }

        Room roomToChange = soloRooms[randIndex];
        string tmpDoor = "";
        Room newKeyRoom = Instantiate(keyRoom, roomToChange.transform.position, Quaternion.identity);
        Destroy(roomToChange.gameObject);
        if (roomToChange.DoorD.activeSelf == false) tmpDoor = "DoorD";
        else if (roomToChange.DoorU.activeSelf == false) tmpDoor = "DoorU";
        else if (roomToChange.DoorR.activeSelf == false) tmpDoor = "DoorR";
        else if (roomToChange.DoorL.activeSelf == false) tmpDoor = "DoorL";

        if (tmpDoor == "DoorD") newKeyRoom.DoorD.SetActive(false);
        else if (tmpDoor == "DoorU") newKeyRoom.DoorU.SetActive(false);
        else if (tmpDoor == "DoorR") newKeyRoom.DoorR.SetActive(false);
        else if (tmpDoor == "DoorL") newKeyRoom.DoorL.SetActive(false);



        Room newRoomToChange = soloRooms[secRandIndex];
        Room newExitRoom = Instantiate(exitRoom, newRoomToChange.transform.position, Quaternion.identity);
        Destroy(newRoomToChange.gameObject);

        if (newRoomToChange.DoorD.activeSelf == false) tmpDoor = "DoorD";
        else if (newRoomToChange.DoorU.activeSelf == false) tmpDoor = "DoorU";
        else if (newRoomToChange.DoorR.activeSelf == false) tmpDoor = "DoorR";
        else if (newRoomToChange.DoorL.activeSelf == false) tmpDoor = "DoorL";

        if (tmpDoor == "DoorD") newExitRoom.DoorD.SetActive(false);
        else if (tmpDoor == "DoorU") newExitRoom.DoorU.SetActive(false);
        else if (tmpDoor == "DoorR") newExitRoom.DoorR.SetActive(false);
        else if (tmpDoor == "DoorL") newExitRoom.DoorL.SetActive(false);
    }

    private bool CountSoloRooms()
    {
        int soloRoomsCounting = 0;

        for (int i = 0; i < spawnedRooms.GetLength(0); i++)
        {
            for (int j = 0; j < spawnedRooms.GetLength(1); j++)
            {
                List<Vector2Int> neighbours = new List<Vector2Int>();
                if (spawnedRooms[i, j] != null)
                {
                    if(i != 10 && j != 10)
                    {
                        if (spawnedRooms[i, j + 1] != null) neighbours.Add(Vector2Int.up);
                        if (spawnedRooms[i, j - 1] != null) neighbours.Add(Vector2Int.down);
                        if (spawnedRooms[i - 1, j] != null) neighbours.Add(Vector2Int.right);
                        if (spawnedRooms[i + 1, j] != null) neighbours.Add(Vector2Int.left);
                    }
                }
                if (neighbours.Count == 1 && !soloRooms.Contains(spawnedRooms[i, j]))
                {
                    soloRooms.Add(spawnedRooms[i, j]);
                    soloRoomsCounting++;
                }
            }
        }

        return soloRoomsCounting < 2;
    }

    void CreateRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }
        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

        Vector3 offset = new Vector3(172.5f, 92, 0);

        int limit = 500;
        while (limit-- > 0)
        {
            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));

            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3((position.x - 5) * 34.5f, (position.y - 5) * 18.4f, 0) - offset;
                spawnedRooms[position.x, position.y] = newRoom;
                return;
            }
        }

        Destroy(newRoom.gameObject);
    }

    private bool ConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorU != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.DoorD != null) neighbours.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.DoorU != null) neighbours.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.DoorL != null) neighbours.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.DoorR != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if (selectedDirection == Vector2Int.up)
        {
            room.DoorU.SetActive(false);
            selectedRoom.DoorD.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }

        return true;
    }
}
