using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScreenPlay : MonoBehaviour
{
    public AudioSource Music;
    public Text txtTimeCounter;
    public float timeCounter = 0;
    [Header("Nhan vat")]
    public Transform nvChim;
    public Transform nvLuaSu;
    
    public Transform nvEmDau;

    public Transform nvChiDau;

    public Transform nvAnh;

    public Transform nvEm;

    [Space] [Header("Objects")] 
    public GameObject cayKhe;
    public GameObject food;

    public GameObject goldBars;

    public GameObject objBug;
    public GameObject objQuaKhe;
    public GameObject objDollars;

    public Transform chairEm1;
    public Transform chairEm2;
    public Transform chairCoChi;
    public Transform chairNguoiAnh;

    [Space] [Header("Anh sang")] 
    public GameObject Light_TrungTam;
    public GameObject Light_CoEm;
    public GameObject Light_CoChi;

    [Space] [Header("Phong bat")]
    public Material phongbat_NhaChi;
    public Material phongbat_2Nha;

    public Material phongbat_Island;
    public Material phongbat_Jail;

    public MeshRenderer PhongBat;

    [Space] [Header("Dance positions")] 
    public Transform dance_pos_chong;

    public Transform dance_pos_vo;
    [FormerlySerializedAs("outOfStagePosition")] public Transform outOfStage;
    

    private WaitForEndOfFrame _eof;
    // Start is called before the first frame update
    void Start()
    {
        Music = GetComponent<AudioSource>();
        cayKhe.SetActive(false);
        goldBars.SetActive(false);
        StartCoroutine(StartScenePlay_CayKhe());
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        txtTimeCounter.text = Mathf.RoundToInt(timeCounter).ToString();
    }

    IEnumerator StartScenePlay_CayKhe()
    {
        yield return Scene1_chia_tai_san();

        yield return Scene2_khac_biet_to_lon();

        yield return Scene3_chim_and_gold_island();

        yield return Scene4_giau_co_va_ghen_ty();

        yield return Scene5_gold_island_act2();

        yield return Scene6_jail_final_act();
    }

    IEnumerator Scene1_chia_tai_san()
    {
        yield return new WaitForSeconds(0.5f);
        // Anh sang
        Light_TrungTam.SetActive(true);
        
        // Show phongbat_nhachi
        yield return new WaitForSeconds(13);
        PhongBat.material = phongbat_NhaChi;
        // Di sang co Em dau
        yield return new WaitForSeconds(3);
        nvChiDau.GetComponent<NavMeshAgent>().destination = nvEmDau.position;
        
        yield return new WaitForSeconds(2);
        PhongBat.material = phongbat_2Nha;
        
        // Di sang em chong`
        yield return new WaitForSeconds(3);
        cayKhe.SetActive(true);
        yield return new WaitForSeconds(7);
        objQuaKhe.transform.parent = nvEmDau;
        
        nvChiDau.GetComponent<NavMeshAgent>().destination = nvEm.position;
        yield return new WaitForSeconds(2);
        objBug.transform.parent = nvEm;
        
        // Ve di cung da muon roi
        yield return new WaitForSeconds(5);
        nvEm.GetComponent<NavMeshAgent>().destination = chairEm1.position;
        yield return new WaitForSeconds(0.5f);
        nvEmDau.GetComponent<NavMeshAgent>().destination = chairEm2.position;
        
        // Dut' lot
        yield return new WaitForSeconds(1f);
        nvAnh.GetComponent<NavMeshAgent>().destination = nvLuaSu.position;
        yield return new WaitForSeconds(2f);
        objDollars.transform.parent = nvLuaSu;
        nvLuaSu.GetComponent<NavMeshAgent>().destination = nvChim.position;
        
        Destroy(objQuaKhe);
        Destroy(objBug);
        yield return _eof;
    }

    IEnumerator Scene2_khac_biet_to_lon()
    {
        // 2 vo chong chi di ve & stream
        nvAnh.GetComponent<NavMeshAgent>().destination = chairNguoiAnh.position;
        nvChiDau.GetComponent<NavMeshAgent>().destination = chairCoChi.position;
        yield return new WaitForSeconds(2f);
        
        // Lighting & shit
        Light_TrungTam.SetActive(false);
        Light_CoChi.SetActive(true);
        food.SetActive(true);
        goldBars.SetActive(false);
        
        yield return new WaitForSeconds(14.3f);
        // Chuyen canh sang co em: Bon' mua` fix bug
        Light_CoChi.SetActive(false);
        Light_CoEm.SetActive(true);
    }

    IEnumerator Scene3_chim_and_gold_island()
    {
        var nvChimNav = nvChim.GetComponent<NavMeshAgent>();
        var nvEmNav = nvEm.GetComponent<NavMeshAgent>();
        var nvEmDauNav = nvEmDau.GetComponent<NavMeshAgent>();
        
        yield return new WaitForSeconds(13f);
        
        // Chim enter with Moonwalk
        nvChimNav.destination = cayKhe.transform.position;
        
        yield return new WaitForSeconds(5f);
        // 2 vc nguoi Chi di ra ngoai san khau + hide food
        food.SetActive(false);
        goldBars.SetActive(true);
        nvChiDau.GetComponent<NavMeshAgent>().destination = outOfStage.position;
        nvAnh.GetComponent<NavMeshAgent>().destination = outOfStage.position;
        
        // Oi, nha` dau tu thien than
        yield return new WaitForSeconds(10);
        // Move to dance position
        nvEmNav.destination = dance_pos_chong.position;
        nvEmDauNav.destination = dance_pos_vo.position;
        
        yield return new WaitForSeconds(10);
        nvEmNav.destination = nvChim.position;
        nvEmDauNav.destination = nvChim.position;
        
        yield return new WaitForSeconds(4);
        nvEmNav.destination = dance_pos_vo.position;
        nvEmDauNav.destination = dance_pos_vo.position;
        nvChimNav.destination = dance_pos_vo.position;
        
        yield return new WaitForSeconds(30);
        PhongBat.material = phongbat_Island;
        
        yield return new WaitForSeconds(18);

        nvChimNav.destination = chairCoChi.position;
        nvEmDauNav.destination = chairCoChi.position;
        
        
        yield return new WaitForSeconds(2);
        
        nvChimNav.destination = outOfStage.position;
        nvEmDauNav.destination = outOfStage.position;
        
        Music.Pause();
    }

    IEnumerator Scene4_giau_co_va_ghen_ty()
    {
        yield return new WaitForSeconds(5);
        Music.UnPause();
        yield return _eof;
    }
    
    IEnumerator Scene5_gold_island_act2()
    {
        yield return _eof;
    }
    
    IEnumerator Scene6_jail_final_act()
    {
        yield return _eof;
    }
}
