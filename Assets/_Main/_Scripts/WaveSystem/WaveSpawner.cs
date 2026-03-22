using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

public class WaveSpawner
{
    public async UniTask<GameObject> SpawnEnemy(Transform[] areaPoints, GameObject[] objectsToSpawn)
    {
        Transform currentPoint = areaPoints[Random.Range(0, areaPoints.Length-1)];
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length-1)]; 
        
        return Object.Instantiate(objectToSpawn, currentPoint.position, Quaternion.identity);
    }
}
