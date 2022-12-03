using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance ; 
    public AudioSource playerHit ; 

    [Header("基础属性")]
    public int health ;

    public bool isDef ; //无敌

    public float DefTimer ; 

    [Header("升级")]
    public int level ; 
    public int exp ; 

    public int exptoNextLevel ; 

    public int buildItem ; //每次升级玩家会获得一定数量的晶核。剩余晶核数显示在屏幕下方。具体获得数量见下表：

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
        if(instance == null ){
            instance = this ;
            //设置instance
        }else{
            if(instance != this){
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);  

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
        if (MoveInTile())
        {
            FreshDectors();
        }

        UpdateDate();
    }

    public void UpdateDate(){
        if(DefTimer <= 0.01f){
            isDef = false ; 
        }else{
            DefTimer -= Time.deltaTime;
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



    public void PlayerHurt(){
        if(!isDef){
            health--;
            playerHit.Play();
            isDef = true ;
            DefTimer = 3.0f ;

            if(health <=0){
                PlayerDead();
            }
        }else{
            //无事发生
        }
    }

    public void addExp(int _exp){
        this.exp += _exp ; 
        if(exp >= exptoNextLevel){
            exp -= exptoNextLevel;
            levelUp();
        }
    }

    public void PlayerDead(){
        GameManager.Instance.GameOver();
    }

    public void levelUp(){
        //升级部分
        if(level <30){
            buildItem += 2;
        }else if(level >=31 && level <50){
            buildItem += 3 ;
        }else{
            buildItem += 4 ;
        }

        if(level>0 && level <=2){
            exptoNextLevel = 5 ;
        }else if(level>2 && level<=3){
            exptoNextLevel = 15;
        }else if(level>3 && level<=5){
            exptoNextLevel = 30;
        }else if(level>5 && level<=8){
            exptoNextLevel = 45;
        }else if(level>8 && level<=10){
            exptoNextLevel = 60;
        }else if(level>10 && level<=12){
            exptoNextLevel = 75;
        }else if(level>12 && level<=15){
            exptoNextLevel = 90;
        }else if(level>15 && level<=18){
            exptoNextLevel = 110;
        }else if(level>18 && level<=20){
            exptoNextLevel = 130;
        }else if(level>20 && level<=22){
            exptoNextLevel = 150;
        }else if(level>22 && level<=25){
            exptoNextLevel = 180;
        }else if(level>25 && level<=28){
            exptoNextLevel = 210;
        }else if(level>28 && level<=30){
            exptoNextLevel = 240;
        }else if(level>30 && level<=32){
            exptoNextLevel = 280;
        }else if(level>32 && level<=35){
            exptoNextLevel = 320;
        }else if(level>35 && level<=38){
            exptoNextLevel = 360;
        }else if(level>38 && level<=40){
            exptoNextLevel = 410;
        }else if(level>40 && level<=42){
            exptoNextLevel = 460;
        }else if(level>42 && level<=45){
            exptoNextLevel = 510;
        }else if(level>45 && level<=48){
            exptoNextLevel = 570;
        }else if(level>48 && level<=50){
            exptoNextLevel = 630;
        }else if(level>50){
            exptoNextLevel = 700;
        }else{
            Debug.Log("等级设置错误");
        }

        level++;

        GameManager.Instance.EnterBuildMode();
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
