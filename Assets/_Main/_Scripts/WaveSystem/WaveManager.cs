using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class WaveManager : MonoBehaviour
{
   [Header("Wave Settings")] [Space]
   [SerializeField]private double _localStep = 0.00001;
   [SerializeField]private int _durationToNextWave = 5;
   
   [Header("Wave Patterns")] [Space]
   [SerializeField]private List<WavePattern> _wavePatterns = new List<WavePattern>();
   [SerializeField]private Transform[] _areaPoints;
   [SerializeField]private List<GameObject> _enemyInWave = new List<GameObject>();
   
   private double _localDifficulty = 1.00;
   private WaveSpawner _waveSpawner;
   private bool _waveInProgress = false;
   

   public void ResetLocalDifficulty() => _localDifficulty = 1.00;
   
   private void Start()
   {
      _waveSpawner = new WaveSpawner();
   }

   private async UniTask NextWave()
   {
      _waveInProgress = true;
      WavePattern pattern = _wavePatterns[Random.Range(0, _wavePatterns.Count - 1)];
      int numberOfEnemies = pattern.NumberOfEnemies;

      await UniTask.WaitForSeconds(_durationToNextWave);
      
      Debug.Log(_enemyInWave + " Spawned");
      for (int i = 0; i < numberOfEnemies; i++)
      {
         GameObject enemy = await _waveSpawner.SpawnEnemy(_areaPoints, pattern.Enemies);
         
         _enemyInWave?.Add(enemy);
         await UniTask.WaitForSeconds(1f);
      }
      
      _waveInProgress = false;
   }
   
   private void Update()
   {
      _localDifficulty += _localStep;
      if (_enemyInWave.Count <= 0 && !_waveInProgress)
      { 
         NextWave().Forget();
      }
   }
}
