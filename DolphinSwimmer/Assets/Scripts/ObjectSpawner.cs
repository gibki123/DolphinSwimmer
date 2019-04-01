using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject water;
    public Transform playerTransform;

    private float topSpawningLimit;
    private float bottomSpawningLimit;
    private float minSpawnTime = 0.5f;
    private float maxSpawnTime = 0.75f;
    private float positionOffsetX = 20f;
    private IEnumerator spawnCoroutine;
    private List<GameObject> collectables;
    private bool spawningCoroutine = false;



    void Awake() {
        collectables = new List<GameObject>();
        spawnCoroutine = spawnCollectables(minSpawnTime, maxSpawnTime);
        Vector3 waterPosition = water.transform.position;
        topSpawningLimit = waterPosition.y + water.transform.localScale.y / 2 - 1;
        bottomSpawningLimit = waterPosition.y - water.transform.localScale.y / 2 + 1;
    }
    void Start() {
    }

    void Update() {
        if (spawningCoroutine == false) {
         //   Debug.Log("Coroutine chenged to true");
            spawningCoroutine = true;
            StartCoroutine(spawnCollectables(minSpawnTime,maxSpawnTime));
        }
        if (collectables.Count > 0) {
            CheckForCollectableDisable();
        }    
    }

    IEnumerator spawnCollectables(float minSpawnTime, float maxSpawnTime) {
        Debug.Log("Coroutine started");
        float randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        float randomSpawnY = Random.Range(bottomSpawningLimit, topSpawningLimit);
        float spawnX = playerTransform.position.x + positionOffsetX;
        float spawnZ = -0.5f;
        Vector3 instantiatePosition = new Vector3(spawnX, randomSpawnY, spawnZ); 
        yield return new WaitForSeconds(randomSpawnTime);
        collectables.Add(ObjectPooler.Instance.SpawnFromPool("CollectableFish", instantiatePosition));
       // Debug.Log("Coroutine chenged to fasle");
        spawningCoroutine = false;
    }

    private void CheckForCollectableDisable() {
        Debug.Log("In CHeck for disable");
        GameObject collectableToDisable = collectables.First();
        if(collectableToDisable.transform.position.x < playerTransform.position.x - positionOffsetX) {
            ObjectPooler.Instance.DisableFromPool(collectables.First());
            collectables.Remove(collectableToDisable);
        }
    }
}
