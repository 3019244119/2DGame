using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UImanger : MonoBehaviour
{
    // Start is called before the first frame update
    ///public Text buildtext;
    ///public Image buildimage;
    ///private int currentnumbers = 0;
    /*void Updatanumbers()
    {
        int sumnumber = 100;
        if(currentnumbers<sumnumber)
        {
            currentnumbers++;
        }
        buildtext.text = "正在努力加载中......"+currentnumbers + "%";
        buildimage.fillAmount = currentnumbers / 100f;
        if(currentnumbers ==100)
        {
            buildtext.text = "加载完成  请开始游戏";
            SceneManager.LoadScene("Menu");

        }
    }*/
    public static Vector3 vec3, pos;
    public bool musicflag = true;
    public AudioSource ismusic;
    public Text musictext;

    private Image thisimage;
    private float maxhp = 100f;
    /// <summary>
    /// 改变生命值
    /// </summary>
    /// <param name="newhp"></param>
    public void changehp(float newhp)
    {
        thisimage.fillAmount = newhp / maxhp;
    }
    /// <summary>
    /// 文本框部分，鼠标位置
    /// </summary>
    public void PointerDown()
    {
        vec3 = Input.mousePosition;
        pos = transform.GetComponent<RectTransform>().position;
    }
    /// <summary>
    /// 文本框部分，鼠标拖拽
    /// </summary>
    public void Drag()
    {
        Vector3 off = Input.mousePosition - vec3;
        vec3 = Input.mousePosition;
        pos = pos + off;
        transform.GetComponent<RectTransform>().position = pos;
    }
    /// <summary>
    /// 这个放在显示的button上
    /// </summary>
    public void Click()
    {
        gameObject.SetActive(true);
    }
    /// <summary>
    /// 点击文本框上的按钮关闭文本框
    /// </summary>
    public void offClick()
    {
        gameObject.SetActive(false);
    }
    public void musiccontrol()
    {
        if (musicflag == true)
        {
            ismusic.volume = 0;
            musicflag = false;
            musictext.text = "off";
            return;
        }
        if (musicflag == false)
        {
            ismusic.volume = 1;
            musicflag = true;
            musictext.text = "on";
            return;
        }
    }
    void Start()
    {
        thisimage = this.GetComponent<Image>();
        ismusic = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
