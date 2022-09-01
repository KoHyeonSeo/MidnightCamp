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
        #region 여기는  망치가 치는 모션 
        if (toLerp < 120)
        {
            toLerp = Mathf.Lerp(toLerp, h,  4*Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0, 0, toLerp);
        }
        #endregion
        #region 여기는 조명 밝아지는 모션
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
//================================================여기서부터 씬 전환하는 부분
        if (waitTime > setTime)
        {
            print("씬 전환");
            // 여기서 씬 로드
            SceneManager.LoadScene("EditorScene");
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("닿음");
        Spark.transform.position = Head.position;
        Spark.Play();
        audio.Play();
        isHit = true;
    }


}
