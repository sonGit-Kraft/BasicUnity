using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �̱���
    public static SoundManager instance; // �ڱ� �ڽ��� ������ ���

    AudioSource myAudio; // AudioSource ������Ʈ�� ������ ����
    public AudioClip soundBullet; // �Ѿ� �Ҹ�
    public AudioClip soundDie; // �״� �Ҹ�

    private void Awake()
    {
        if(SoundManager.instance == null) // �ν��ͽ��� �ִ��� �˻�
        {
            SoundManager.instance = this; // �ڱ� �ڽ��� ����
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������    
    }

    // �Ѿ� �߻� ����
    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(soundBullet); // PlayOneShot: �ѹ��� ����
    }

    // ���� �״� ����
    public void PlayDieSound()
    {
        myAudio.PlayOneShot(soundDie); // PlayOneShot: �ѹ��� ����
    }
}
