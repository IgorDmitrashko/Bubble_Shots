using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    private GameObject[] _enemies;

    private float[] _rangeSpownX;
    private float[] _rangeSpownZ;
    private int _numberEnemies;

    private MeshRenderer _meshRend;
    private Material _matInfection;

    public Enemy enemy;

    void Start() {
        SpownEnemy();
        enemy = _enemy.GetComponent<Enemy>();
       Enemy.Impact += ChengeMatAndDestroy;
       //Enemy.Impact += ChangeEnemyMaterial;
    }

    private void ChengeMatAndDestroy(GameObject enemy, Collider bubble) {      
        StartCoroutine(HoldTime(enemy, bubble));      
    }

    IEnumerator HoldTime(GameObject enemy, Collider bubble) {
        Destroy(bubble.gameObject);
        ChangeEnemyMaterial(enemy, bubble);
        yield return new WaitForSeconds(0.8f);
        Destroy(enemy);
    }

    private void ChangeEnemyMaterial(GameObject enemy, Collider bubble) {
        _meshRend = enemy.GetComponent<MeshRenderer>();
        _matInfection = Resources.Load("EnemyInfection", typeof(Material)) as Material;
        _meshRend.material = _matInfection;
    }

    void SpownEnemy() {
        _numberEnemies = Random.Range(70, 100);

        _rangeSpownX = new float[_numberEnemies];
        _rangeSpownZ = new float[_numberEnemies];
        _enemies = new GameObject[_numberEnemies];

        for(int i = 0; i < _numberEnemies; i++)
        {
            _enemies[i] = _enemy;
        }

        for(int i = 0; i < _numberEnemies; i++)
        {
            _rangeSpownX[i] = Random.Range(-4f, 4f);
            _rangeSpownZ[i] = Random.Range(0.3f, 4.5f);
            Vector3 possitionSwown = new Vector3(_rangeSpownX[i], 0.1f, _rangeSpownZ[i]);

            Instantiate(_enemies[i], possitionSwown, Quaternion.identity);
        }
    }
}
