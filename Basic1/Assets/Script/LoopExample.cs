using UnityEngine;

public class LoopExample : MonoBehaviour
{
    void Start()
    {
        // for��: 1���� 10���� ���
        for (int i = 1; i <= 10; i++)
        {
            Debug.Log("Count: " + i);
        }

        // while��: ������ ���� �� ����
        int count = 0;
        while (count < 5)
        {
            Debug.Log("While Count: " + count);
            count++;
        }
    }
}
