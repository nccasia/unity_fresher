using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class ScreenPlay : MonoBehaviour
{
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

    private WaitForEndOfFrame _eof;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartScenePlay_CayKhe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartScenePlay_CayKhe()
    {
        yield return Scene1_LuatSu();

        yield return Scene2_khac_biet_to_lon();
    }

    IEnumerator Scene1_LuatSu()
    {
        yield return new WaitForSeconds(0.5f);
        // Anh sang
        Light_TrungTam.SetActive(true);
        // Di sang co Em dau
        yield return new WaitForSeconds(17);
        nvChiDau.GetComponent<NavMeshAgent>().destination = nvEmDau.position;
        
        // Di sang em chong`
        yield return new WaitForSeconds(10);
        Destroy(objQuaKhe);
        nvChiDau.GetComponent<NavMeshAgent>().destination = nvEm.position;
        yield return new WaitForSeconds(2);
        Destroy(objBug);
        
        // Ve di cung da muon roi
        yield return new WaitForSeconds(5);
        nvEm.GetComponent<NavMeshAgent>().destination = chairEm1.position;
        yield return new WaitForSeconds(0.5f);
        nvEmDau.GetComponent<NavMeshAgent>().destination = chairEm2.position;
        
        // Dut' lot
        yield return new WaitForSeconds(1f);
        nvAnh.GetComponent<NavMeshAgent>().destination = nvLuaSu.position;
        yield return new WaitForSeconds(2f);
        Destroy(objDollars);
        nvLuaSu.GetComponent<NavMeshAgent>().destination = nvChim.position;
        yield return _eof;
    }

    IEnumerator Scene2_khac_biet_to_lon()
    {
        // 2 vo chong chi di ve & stream
        nvAnh.GetComponent<NavMeshAgent>().destination = chairNguoiAnh.position;
        nvChiDau.GetComponent<NavMeshAgent>().destination = chairCoChi.position;
        yield return new WaitForSeconds(2f);
        Light_TrungTam.SetActive(false);
        Light_CoChi.SetActive(true);
        food.SetActive(true);
        goldBars.SetActive(false);
    }
}
