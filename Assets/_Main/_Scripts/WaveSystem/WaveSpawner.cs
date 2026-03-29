using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Main._Scripts.WaveSystem
{
    public class WaveSpawner
    {
        public async UniTask<Enemyl.Enemy> SpawnEnemy(Transform[] areaPoints, GameObject prefab)
        {
            Random.InitState((int)Time.time);
            Transform currentPoint = areaPoints[Random.Range(0, areaPoints.Length-1)];
        
            return Object.Instantiate(prefab, currentPoint.position, Quaternion.identity).GetComponent<Enemyl.Enemy>();
        }
    }
}
