
using Infrastructure.Services;
using Infrastructure.Services.Persistent.SaveLoad;
using UnityEngine;

public class SaveTrigger : MonoBehaviour {
    private ISaveLoadService _saveLoadService;
    public BoxCollider boxCollider;

    private void Awake(){
        _saveLoadService = AllServices.Container.GetService<ISaveLoadService>();
    }

    private void OnTriggerEnter(Collider Other){
        _saveLoadService.SaveProgress();
        Debug.Log("SAVE PROGRESS");
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos(){
        if (!boxCollider)
            return;
        Gizmos.color = new Color32(30, 200, 30, 130);
        Gizmos.DrawCube(transform.position + boxCollider.center, boxCollider.size);
    }

   
}