using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    // ���� ��������
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject currentEnemy; // ���� ������ ��
    public float spawntime = 0.5f;
    // ���� �����ϴ� �Լ�
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f); // ���� ��Ÿ�� ���� X��ǥ ���� (����: -2 ~ 2)

        // ���� ���� 
        Instantiate(currentEnemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }

    void Start()
    {
        // SpawnEnemy 1 0.5f
        InvokeRepeating("SpawnEnemy", 1, spawntime);
    }

    void Update()
    {
        // ���� �������� �� ����
        if (GameManager.instance.score >= 50 && GameManager.instance.score < 100 && currentEnemy != enemy2)
        {
            currentEnemy = enemy2;
            Debug.Log("���� enemy2�� �����!");
            spawntime = 3f;
        }
        else if (GameManager.instance.score >= 100 && currentEnemy != enemy3)
        {
            currentEnemy = enemy3;
            Debug.Log("���� enemy3�� �����!");
            spawntime = 4f;
        }
    }
}