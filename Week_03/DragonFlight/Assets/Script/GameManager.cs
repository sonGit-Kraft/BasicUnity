using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �̱���
    // ��𿡼��� ���� �� �� �ֵ��� static���� �ڱ��ڽ��� �����ؼ� �̱����̶�� ������ ���� ���
    public static GameManager instance;
    public Text ScoreText; // ������ ǥ���ϴ� Text ��ü�� �����Ϳ��� �޾ƿ�
    public Text StartText; // ���� ���� �� 3, 2, 1
    public Text HpText; // Hp�� ǥ���ϴ� Text ��ü�� �����Ϳ��� �޾ƿ�
    public int score = 0; // ���� �ʱ�ȭ
    public int hp = 100;

    private void Awake()
    {
        if (instance == null) // �������� �ڱ� �ڽ� üũ
        {
            instance = this; // �ڱ� �ڽ� ����
        }
    }

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Time.timeScale = 0; //��ü �ð�����

        int i = 3;
        while (i > 0)
        {
            StartText.text = i.ToString();
            // yield return new WaitForSeconds(1f); // 1�� ���
            yield return new WaitForSecondsRealtime(1); //������ ���絵 �����ϴ� ���
            i--;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false); // UI ���߱�
                Time.timeScale = 1; //�ٽ� �ð� ��������
            }
                
        }
    }

    public void AddScore(int num)
    {
        score += num; // ������ ����
        ScoreText.text = "Score: " + score; // �ؽ�Ʈ�� �ݿ�
    }

    public void Hp(int num)
    {
        hp -= num;
        HpText.text = "Hp: " + hp; // �ؽ�Ʈ�� �ݿ�
    }
}