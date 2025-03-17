using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float ss = -2; // ���� ���� x�� ó��
    public float es = 2; // ���� ���� x�� ��
    public float StartTime = 1; // ���� �ð�
    public float SpawnStop = 10; // ������ �ð�
    public GameObject monster;
    public GameObject monster2;
    public GameObject boss;

    bool Switch = true;
    bool Switch2 = true;

    [SerializeField]
    GameObject textBoosWarning;

    private void Awake()
    {
        textBoosWarning.SetActive(false);
        //PoolManager.Instance.CreatePool(monster, 10);
    }

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", 10); // 10�� �ڿ� Stop() �Լ� ����
    }

    // �ڷ�ƾ���� ���� ����
    IEnumerator RandomSpawn()
    {
        while (Switch)
        {
            // 1�ʸ���
            yield return new WaitForSeconds(StartTime);
            // x�� ����
            float x = Random.Range(ss, es);
            // x���� ���� �� y���� �ڱ��ڽ� ��
            Vector2 r = new Vector2(x, transform.position.y);
            // ���� ����
            Instantiate(monster, r, Quaternion.identity);
            //GameObject enemy = PoolManager.Instance.Get(monster);
            //enemy.transform.position = r;
        }
    }

    // �ڷ�ƾ���� ���� ����
    IEnumerator RandomSpawn2()
    {
        while (Switch2)
        {
            // 1�ʸ���
            yield return new WaitForSeconds(StartTime + 2);
            // x�� ����
            float x = Random.Range(ss, es);
            // x���� ���� �� y���� �ڱ��ڽ� ��
            Vector2 r = new Vector2(x, transform.position.y);
            //���� ����
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    void Stop()
    {
        Switch = false;
        StopCoroutine("RandomSpawn");
        // �ι�° ���� �ڷ�ƾ
        StartCoroutine("RandomSpawn2");

        Invoke("Stop2", 20 + SpawnStop); // 30�� �ڿ� Stop() �Լ� ����
    }

    void Stop2()
    {
        Switch2 = false;
        StopCoroutine("RandomSpawn2");

        textBoosWarning.SetActive(true);

        // ���� ����
        Vector3 pos = new Vector3(0, 2.97f, 0);
        Instantiate(boss, pos, Quaternion.identity);
    }
}