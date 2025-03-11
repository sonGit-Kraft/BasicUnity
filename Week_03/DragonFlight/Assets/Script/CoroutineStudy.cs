using System.Collections; // for Coroutine
using UnityEngine;

public class CoroutineStudy : MonoBehaviour
{
    /*
    �ڷ�ƾ(Coroutine)�� Unity���� �ð��� �ɸ��� �۾��� ȿ�������� ������ �� �ֵ��� �����ִ� ���
    �Ϲ� �Լ��� �޸� �ڷ�ƾ�� ������ ����ٰ� ���� �ٽ� ������ �� ����
    */
    void Start()
    {
        StartCoroutine("ExampleCoroutine");
        StartCoroutine(ExampleCoroutine());
    }
    
    IEnumerator ExampleCoroutine()
    {
        Debug.Log("�ڷ�ƾ ����");
        yield return new WaitForSeconds(2f); // 2�� ��� (���α׷� ���ߴ°� �ƴ�)
        Debug.Log("2�� �� ����");

        while (true)
        {
            Debug.Log("1�ʸ��� ����");
            yield return new WaitForSeconds(1f);
        }
    }
}