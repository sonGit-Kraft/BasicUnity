using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    // ���� ��������
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject currentEnemy; // ���� ������ ��

    public float spawnTime = 0.5f; // ���� �ֱ�

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
        InvokeRepeating("SpawnEnemy", 1, spawnTime);
    }

    void Update()
    {
        // ���� �������� �� ����
        if (GameManager.instance.score >= 50 && GameManager.instance.score < 100 && currentEnemy != enemy2)
        {
            if (spawnTime != 0.75f)  // spawnTime�� ������ ����� ����
            {
                currentEnemy = enemy2;
                spawnTime = 0.75f;
                CancelInvoke("SpawnEnemy");  // ���� ȣ�� ���
                InvokeRepeating("SpawnEnemy", 1, spawnTime);  // ���ο� �ֱ�� ȣ��
            }
        }
        else if (GameManager.instance.score >= 100 && currentEnemy != enemy3)
        {
            if (spawnTime != 1.0f)  // spawnTime�� ������ ����� ����
            {
                currentEnemy = enemy3;
                spawnTime = 1.0f;
                CancelInvoke("SpawnEnemy");  // ���� ȣ�� ���
                InvokeRepeating("SpawnEnemy", 1, spawnTime);  // ���ο� �ֱ�� ȣ��
            }
        }
    }
}