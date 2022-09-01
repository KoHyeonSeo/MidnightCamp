using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    float toLerp;
    [SerializeField] float h;
    [SerializeField] ParticleSystem spark;
    [SerializeField] Transform Head;
    ParticleSystem Spark;
    AudioSource audio;
    [SerializeField] Light light;
    [SerializeField] float intensityMax;
    [SerializeField] float intensitySpeed;
    [SerializeField] float setTime;
    float waitTime;
    bool isHit;
    void Start()
    {
        Spark=Instantiate(spark);
        audio = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        #region �����  ��ġ�� ġ�� ��� 
        if (toLerp < 120)
        {
            toLerp = Mathf.Lerp(toLerp, h,  4*Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0, 0, toLerp);
        }
        #endregion
        #region ����� ���� ������� ���
        if (isHit)
        {
            if (light.intensity >= intensityMax)
            {
                light.intensity = intensityMax;
                waitTime += Time.deltaTime;
            }
            light.intensity += intensitySpeed;
        }
        #endregion
//================================================���⼭���� �� ��ȯ�ϴ� �κ�
        if (waitTime > setTime)
        {
            print("�� ��ȯ");
            // ���⼭ �� �ε�
            SceneManager.LoadScene("EditorScene");
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("����");
        Spark.transform.position = Head.position;
        Spark.Play();
        audio.Play();
        isHit = true;
    }


}
