using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;


    private KitchenObject _kitchenObject;

    public void Interact(Player player)
    {
        if (_kitchenObject == null)
        {
            Transform kitchenObjTransform = Instantiate(kitchenObjectSo.prefab, counterTopPoint);
            kitchenObjTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            _kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        _kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }

    public void ClearKitchenObject()
    {
        _kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return _kitchenObject != null;
    }
}