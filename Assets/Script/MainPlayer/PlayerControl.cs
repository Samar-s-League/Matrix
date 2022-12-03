using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Detectors")]
    [SerializeField] private float X_offset;
    [SerializeField] private float Y_offset;
    [SerializeField] private TileDetector up;
    [SerializeField] private TileDetector down;
    [SerializeField] private TileDetector left;
    [SerializeField] private TileDetector right;
    private List<TileDetector> detectors = new List<TileDetector>();

    public GameObject tile_Now;

    private Dictionary<TileDetector, Transform> maps = new Dictionary<TileDetector, Transform>();

    [SerializeField] public LayerMask groundLayer;
    [SerializeField] private bool isSetTile = false; 

    [Header("游戏中菜单")]
    private bool openGameMenu = false;
    public GameObject gameMenuObject; 

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        detectors.Add(up);
        detectors.Add(down);
        detectors.Add(left);
        detectors.Add(right);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     if (openGameMenu)
        //     {
        //         //关闭
        //         CloseGameMenu();
        //     }
        //     else if (!openGameMenu)
        //     {
        //         //开启
        //         OpenGameMenu();
        //     }
        // }

        if (MoveInTile())
        {
            FreshDectors();
        }
    }

    public void OpenGameMenu()
    {
        gameMenuObject.SetActive(true);
        Time.timeScale = 0.0f;
        openGameMenu=!openGameMenu;
    }

    public void CloseGameMenu()
    {
        gameMenuObject.SetActive(false);
        Time.timeScale = 1.0f;
        openGameMenu=!openGameMenu;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public bool MoveInTile()
    {
        bool result = false;

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (down.canGet)
            {
                transform.localPosition = down.tile.transform.position;
                result = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (up.canGet)
            {
                transform.localPosition = up.tile.transform.position;
                result = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (left.canGet)
            {
                transform.localPosition = left.tile.transform.position;
                result = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (right.canGet)
            {
                transform.localPosition = right.tile.transform.position;
                result = true;
            }
        }

        return result;
    }

    public void setTile(int _mode)
    {
        if(_mode == 1)
        {
            isSetTile = true;
        }

        if(_mode == 0)
        {
            isSetTile = false; 
        }
    }

    public void FreshDectors()
    {
        foreach (TileDetector detector in detectors)
        {
            detector.gameObject.SetActive(false);
            detector.gameObject.SetActive(true);
        }

        up.transform.localPosition = new Vector3(up.transform.localPosition.x, Y_offset, up.transform.localPosition.z);
        down.transform.localPosition = new Vector3(down.transform.localPosition.x, -Y_offset, down.transform.localPosition.z);
        left.transform.localPosition = new Vector3(-X_offset, left.transform.localPosition.y, left.transform.localPosition.z);
        right.transform.localPosition = new Vector3(X_offset, right.transform.localPosition.y, right.transform.localPosition.z);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grid"))
        {
            if (!isSetTile)
            {
                tile_Now = other.gameObject;
                //tile_Now.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }

        }

    }

}
