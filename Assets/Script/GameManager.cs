using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerControl player ; 
    public bool isCreateLand ;
    public bool isBuildingTower = true ; //任意时间都可以建
    public GameObject TowerUI ; 

    public int createCount ; 
    public GameObject choseTile ; //建造时被选择的地块
    
    [Header("可以建造的防御塔")]
    public GameObject 炎 ; 
    public GameObject 电 ; 
    public GameObject 冰 ; 
    public GameObject 毒 ; 


    public List<Grid> grids = new List<Grid>() ; 


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        // 测试
        if(Input.GetKeyDown(KeyCode.E)){
            EnterBuildMode();
        }

        if(isCreateLand){
            if(Input.GetMouseButtonDown(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);             
                
                //建造模式
                    if(hit.collider != null){
                        GameObject temp = hit.collider.gameObject;
                        Debug.Log("S"+temp.name);

                        if(temp.tag.Equals("Grid")){
                            temp.tag = "Land" ; 
                            temp.GetComponent<SpriteRenderer>().color = new Color(0,0,0);
                            createCount--;

                            if(createCount <= 0){
                                ExitBuildMode();
                            }
                        }
        

                    }

                player.FreshDectors();
            }
        }

        if(isBuildingTower){
                if(Input.GetMouseButtonDown(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);             

                // 建造防御塔   
                if(hit.collider != null){
                    GameObject temp = hit.collider.gameObject;
                    if(temp.tag.Equals("Land") && player.buildItem >= 1){
                        //选择地区防御塔
                        choseTile = temp ; 
                        EnterBuildTower();
                    }
                }

                player.FreshDectors();
            }
        }

    }

    public void EnterBuildMode(){
        isCreateLand = true ; 
        Time.timeScale = 0.0f;
        createCount = 2 ;
    }

    public void ExitBuildMode(){
        isCreateLand = false ;
        Time.timeScale = 1.0f;
        createCount = 2 ;
    }

    public void EnterBuildTower(){
        Time.timeScale = 0.0f;
        TowerUI.SetActive(true);
    }

    public void ExitBuildTower(){
        Time.timeScale = 1.0f;
        TowerUI.SetActive(false);
    }

    public void BuildTower(int _tower){
        if(choseTile != null){
            switch(_tower){
                case 1 :
                    GameObject.Instantiate(炎,choseTile.transform);
                    break;

                case 2 :
                    GameObject.Instantiate(电,choseTile.transform);
                    break;                
                    
                case 3 :
                    GameObject.Instantiate(冰,choseTile.transform);
                    break;                
                    
                case 4 :
                    GameObject.Instantiate(毒,choseTile.transform);
                    break;

                default:
                    Debug.Log("错误按键");
                    GameObject.Instantiate(炎,choseTile.transform);
                    break;

            }
        }
    }


    public void addExpToPlayer(int exp){
        player.addExp(exp);
    }
    
    public void registerGrid(Grid grid){
        grids.Add(grid);
    }
}
