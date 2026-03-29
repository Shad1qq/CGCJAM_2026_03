using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Main._Scripts.WaveSystem
{
   public class WaveManager : MonoBehaviour
   {
        private static Action EnemyDestroyed; 

        [Header("Wave Settings")] [Space]
        [SerializeField]private double _localStep = 0.00001;
        [SerializeField]private int _durationToNextWave = 5;
   
        [Header("Wave Patterns")] [Space]
        [SerializeField]private GameObject _prefab;
        [SerializeField]private List<WavePattern> _wavePatterns = new List<WavePattern>();
        [SerializeField]private Transform[] _areaPoints;
        [SerializeField]private List<GameObject> _enemyInWave = new List<GameObject>();
   
        private double _localDifficulty = 1.00;
        private WaveSpawner _waveSpawner;
        private bool _wavespawnInProgress = false;
   

        public void ResetLocalDifficulty() => _localDifficulty = 1.00;
        public static void EnemyDestroyedInvoke() => EnemyDestroyed?.Invoke();
   
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            _waveSpawner = new WaveSpawner();
            EnemyDestroyed += DeleteNullEnemyInWave;
        }

        private async UniTask NextWave()
        {
            _wavespawnInProgress = true;
            UnityEngine.Random.InitState((int)Time.time);

            WavePattern pattern = _wavePatterns[UnityEngine.Random.Range(0, _wavePatterns.Count - 1)];
            int numberOfEnemies = pattern.NumberOfEnemies;

            Debug.Log(pattern.NumberOfEnemies);

            await UniTask.WaitForSeconds(_durationToNextWave);
      
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Enemyl.Enemy enemy = await _waveSpawner.SpawnEnemy(_areaPoints, _prefab);
         
                enemy.Init(pattern.Enemies[UnityEngine.Random.Range(0, pattern.Enemies.Length - 1)]);
         
                _enemyInWave?.Add(enemy.gameObject);
                await UniTask.WaitForSeconds(1f);
            }
      
            _wavespawnInProgress = false;
        }
   
        private void Update()
        {
            _localDifficulty += _localStep;

            //if(Time.frameCount % 60 == 0) DeleteNullEnemyInWave();

            if (_enemyInWave.Count <= 0 && !_wavespawnInProgress)
                NextWave().Forget();
         
        }
        public void DeleteNullEnemyInWave()
        {
            _enemyInWave.RemoveAll(enemy => enemy == null || !enemy.gameObject.activeInHierarchy);
        }
   }
}
