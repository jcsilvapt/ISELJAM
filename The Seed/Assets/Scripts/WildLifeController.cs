using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildLifeController : MonoBehaviour {

    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public List<Transform> eaglesSpawn;
    public List<Transform> rabbitsSpawn;

    [Header("Settings")]
    public int numberOfEagles = 10;
    public int numberOfRabbits = 10;
    public float timePerEagleSpawn;
    public float timePerRabbitSpawn;

    private float elapsedEagleSpawn;
    private float elapsedRabbitSpawn;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start() {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);

        }
        elapsedEagleSpawn = timePerEagleSpawn;
        elapsedRabbitSpawn = timePerRabbitSpawn;
    }

    private void Update() {
        
        if(elapsedEagleSpawn >= timePerEagleSpawn) {
            SpawnEagles();
            elapsedEagleSpawn = 0f;
        } else {
            elapsedEagleSpawn += Time.deltaTime;
        }

        if(elapsedRabbitSpawn >= timePerRabbitSpawn) {
            SpawnRabbits();
            elapsedRabbitSpawn = 0f;
        } else {
            elapsedRabbitSpawn += Time.deltaTime;
        }

    }

    private void SpawnEagles() {
        for (int i = 0; i < numberOfEagles; i++) {
            Transform spawnPosition = eaglesSpawn[Random.Range(0, eaglesSpawn.Count - 1)];
            SpawnFromPool("eagle", spawnPosition);
        }
    }

    private void SpawnRabbits() {
        for (int i = 0; i < numberOfRabbits; i++) {
            Transform spawnPosition = rabbitsSpawn[Random.Range(0, rabbitsSpawn.Count - 1)];
            SpawnFromPool("rabbit", spawnPosition);
        }
    }

    public void SpawnFromPool(string tag, Transform parent) {

        if (poolDictionary.ContainsKey(tag)) {

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = parent.position;
            objectToSpawn.transform.rotation = Quaternion.Euler(parent.localEulerAngles);
            objectToSpawn.transform.rotation = Quaternion.Euler(objectToSpawn.transform.rotation.x, objectToSpawn.transform.rotation.y + Random.Range(-25, 25), objectToSpawn.transform.rotation.z);
            poolDictionary[tag].Enqueue(objectToSpawn);
        } else {
            Debug.LogWarning("Pool with tag: " + tag + " doesn't exsists.");
            return;
        }
    }

}



