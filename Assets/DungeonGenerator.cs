using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    private int[,] dungeonGrid;

    public GameObject roomPrefab;
    public GameObject corridorPrefab;

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        dungeonGrid = new int[width, height];

        // Simple Dungeon Generation Logic
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                dungeonGrid[x, y] = Random.Range(0, 2);  // 0 = empty, 1 = room
            }
        }

        // Visualize Dungeon
        VisualizeDungeon();
        CreateCorridors();  // Add this to create corridors
    }

    void VisualizeDungeon()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (dungeonGrid[x, y] == 1)
                {
                    Vector3 position = new Vector3(x * 3, 0, y * 3);
                    Instantiate(roomPrefab, position, Quaternion.identity);
                }
            }
        }
    }

    // Method to create corridors between rooms
    void CreateCorridors()
    {
        for (int x = 0; x < width - 1; x++)
        {
            for (int y = 0; y < height - 1; y++)
            {
                if (dungeonGrid[x, y] == 1 && dungeonGrid[x + 1, y] == 1)
                {
                    Vector3 corridorPos = new Vector3((x + 0.5f) * 3, 0, y * 3);
                    Instantiate(corridorPrefab, corridorPos, Quaternion.identity);  // Connect rooms horizontally
                }

                if (dungeonGrid[x, y] == 1 && dungeonGrid[x, y + 1] == 1)
                {
                    Vector3 corridorPos = new Vector3(x * 3, 0, (y + 0.5f) * 3);
                    Instantiate(corridorPrefab, corridorPos, Quaternion.identity);  // Connect rooms vertically
                }
            }
        }
    }
}