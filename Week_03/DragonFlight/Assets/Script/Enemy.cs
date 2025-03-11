using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ������ �ӵ� ����
    public float moveSpeed = 2f;

    void Update()
    {
        // ������ �Ÿ� ���
        float distanceY = moveSpeed * Time.deltaTime;

        // ������ �ݿ�
        transform.Translate(0, -distanceY, 0); // ����(Y����)���� ������ 
    }

    // ȭ�� ������ ���� ī�޶󿡼� ������ ���� �� ȣ��
    // ����Ƽ������ Scene�� ī�޶��̱� ������ ī�޶�� Scene�� ��� ����� ������
    // ���� Scene â�� ���ų� ī�޶� �°� Scene ũ�⸦ �����ؾߵ�
    private void OnBecameInvisible()
    {
        Destroy(gameObject); // ��ü ����   
    }
}