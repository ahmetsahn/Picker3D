using Runtime.Data.Scriptables.Collectables;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.CollectablesSystem
{
    public class CollectableManager : MonoBehaviour
    {
        private CollectableMovement _collectableMovement;
        
        private CollectableMesh _collectableMesh;
        
        private SO_Collectable _collectableData;
        
        private Rigidbody _rigidbody;
        
        private MeshRenderer _meshRenderer;
        
        private const string COLLECTABLE_DATA_PATH = "Data/Collectable/SO_Collectable";
        
        private void Awake()
        {
            GetCollectableData();

            Init();
        }

        private void Init()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponent<MeshRenderer>();
            
            _collectableMovement = new CollectableMovement
            (
                ref _collectableData.CollectableForceData,
                ref _rigidbody
            );
            
            _collectableMesh = new CollectableMesh
            (
                ref _meshRenderer
            );
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        private void GetCollectableData()
        {
            _collectableData = Resources.Load<SO_Collectable>(COLLECTABLE_DATA_PATH);
        }
        
        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onThrowCollectables += OnThrowCollectables;
            CollectableSignals.Instance.onHitThePool += OnChangeColor;
        }
        
        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onThrowCollectables -= OnThrowCollectables;
            CollectableSignals.Instance.onHitThePool -= OnChangeColor;
        }
        
        private void OnThrowCollectables()
        {
            _collectableMovement.Throw();
        }
        
        private void OnChangeColor()
        {
            _collectableMesh.OnChangeColor();
        }
        
        public void SetTrueCanThrow()
        {
            _collectableMovement.SetTrueCanThrow();
        }
        
        public void SetTrueIsInPool()
        {
            _collectableMesh.SetTrueIsInPool();
        }
    }
}