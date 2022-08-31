using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 현재 모드를 설정하는 Enum Type
    /// </summary>
    public enum Mode
    {
        Move,
        Rotate,
        Delete,
        ColorChange
    }
    /// <summary>
    /// 현재 모드
    /// </summary>
    public Mode curState = Mode.Move;

    [SerializeField] private GameObject system;

    private DragBlock movingScript;
    private DeleteMode deleteScript;
    private RotationBlock rotateScript;

    private Mode preState = Mode.Move;

    private void Start()
    {
        movingScript = system.GetComponent<DragBlock>();
        deleteScript = system.GetComponent<DeleteMode>();
        rotateScript = system.GetComponent<RotationBlock>();
        ChangeState();
    }

    private void Update()
    {
        if(preState != curState)
        {
            preState = curState;
            ChangeState();
        }
    }
    void ChangeState()
    {
        switch (curState)
        {
            case Mode.Move:
                Move();
                break;
            case Mode.Rotate:
                Rotate();
                break;
            case Mode.Delete:
                Delete();
                break;
            case Mode.ColorChange:
                ColorChage();
                break;
        }
    }
    void Move()
    {
        movingScript.enabled = true;
        rotateScript.enabled = false;
        deleteScript.enabled = false;
    }
    void Rotate()
    {
        rotateScript.enabled = true;
        movingScript.enabled = false;
        deleteScript.enabled = false;
    }
    void Delete()
    {
        deleteScript.enabled = true;
        movingScript.enabled = false;
        rotateScript.enabled = false;
    }
    void ColorChage()
    {

    }
}
