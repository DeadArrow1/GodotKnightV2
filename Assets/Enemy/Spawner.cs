using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maxSpawnTime;

    public Transform linestart, lineend;


    private float _timeUntilSpawn;

    [SerializeField]
    public GameData gamedata;

    private bool spawnCompleted;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spawnCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamedata.encounterStarted == true && spawnCompleted == false) 
        {
            SpawnEnemies();
            spawnCompleted = true;
        }
       
    }
    private void SpawnEnemies()
    {
        int enemiesCount = 5 + gamedata.AreaLevel;
        gamedata.countEnemiesInEncounter = enemiesCount;
        for (int i = 0; i < enemiesCount; i++)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        float xRange = lineend.position.x - linestart.position.x;
        float yRange = lineend.position.y - linestart.position.y;




        float side = Random.value;

        Vector2 spawnLocation;
        if (side < 0.25)
        {
            Vector2 leftSide = new Vector2(linestart.position.x, linestart.position.y + (yRange * Random.value));
            spawnLocation = leftSide;
        }
        else if(side < 0.5)
        { 
            Vector2 topSide = new Vector2(linestart.position.x + (xRange * Random.value), lineend.position.y);
            spawnLocation = topSide;
        }
        else if (side < 0.75)
        {
            Vector2 rightSide = new Vector2(lineend.position.x, linestart.position.y + (yRange * Random.value));
            spawnLocation = rightSide;
        }
        else 
        {
            Vector2 botSide = new Vector2(linestart.position.x + (xRange * Random.value), linestart.position.y);
            spawnLocation = botSide;
        }
        //Vector2 spawnLocation = new Vector2(linestart.position.x + (xRange * Random.value), linestart.position.y + (yRange * Random.value));




        
        GameObject spawnInstance = Instantiate(_enemyPrefab);
        spawnInstance.transform.position = spawnLocation;
    }

    private void SetTimeUntilSpawn() 
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maxSpawnTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(linestart.position,lineend.position);
    }


}
