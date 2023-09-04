using System;
using System.Threading.Tasks;
using DG.Tweening;
using Runtime.Data.Scriptables.Level;
using Runtime.Data.Scriptables.Time;
using Runtime.Data.ValueObjects.Level;
using Runtime.Data.ValueObjects.Time;
using Runtime.Signals;
using Runtime.UISystem;
using TMPro;
using UnityEngine;

namespace Runtime.PoolSystem
{
    public class PoolController : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshPro poolText;
        
        [SerializeField] 
        private int stageID;
        
       
        private PoolMaterialData _poolMaterialData;
        
        [SerializeField]              
        private GameObject poolGround;
        [SerializeField]               
        private GameObject leftBarrier;
        [SerializeField]                 
        private GameObject rightBarrier; 
        
        private int _poolScore;
        
        private PoolData _poolData;
        
        private InGameCooldownData _inGameCooldownData;
        
        private const float POOL_GROUND_Y_POSITION = -0.58f;
        private const float DEGREE90 = 90f;

        private const string POOL_DATA_PATH = "Data/Level/SO_Level";
        private const string TIME_DATA_PATH = "Data/Time/SO_Time";
        
        private const string MATERIAL_SMOOTHNESS = "_Smoothness";
        
        
        private void Awake()
        {
            GetPoolData();
            GetTimeData();
            GetMaterialData();
        }
        
        private void Start()
        {
            UpdateScoreText();
            SetPoolMaterialDefaultColor();
            SetPoolMaterialDefaultSmoothness();
        }

        private void GetPoolData()
        {
            _poolData = Resources.Load<SO_Level>(POOL_DATA_PATH)                           
                .LevelDatas[(int)LevelSignals.Instance.onGetCurrentLevelIndex?.Invoke()]     
                .PoolDatas[stageID];                                                         
        }
        
        private void GetTimeData()
        {
            _inGameCooldownData = Resources.Load<SO_Time>(TIME_DATA_PATH).InGameCooldownData;
        }
        
        private void GetMaterialData()
        {
            _poolMaterialData = Resources.Load<SO_Level>(POOL_DATA_PATH).PoolMaterialData;
        }
        
        public void IncreasePoolScore()
        {
            _poolScore++;
        }

        public void UpdateScoreText()
        {
            poolText.text = _poolScore + " / " + _poolData.RequiredObjectCount;
        }
        
        public async void OnControlStageSuccess()
        {
            if (_poolScore < _poolData.RequiredObjectCount)
            {
                UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.LosePanel, 1);
            }

            else
            {
                LevelSignals.Instance.onStageSuccess?.Invoke();
                UISignals.Instance.onSetStageColor?.Invoke(stageID);
                PoolGroundMoveY();
                BarriersRotateX();
                SetPoolMaterialNewColor();
                SetPoolMaterialNewSmoothness();

                await Task.Delay(TimeSpan.FromSeconds(_inGameCooldownData.PlayerMovementWaitingTime));
            
                PlayerSignals.Instance.onPlayerCanMove?.Invoke(true);

                await Task.Delay(TimeSpan.FromSeconds(_inGameCooldownData.MaterialDefaultWaitingTime));
                
                SetPoolMaterialDefaultColor();
                SetPoolMaterialDefaultSmoothness();
                ResetPoolScore();
            }
        }

        private void ResetPoolScore()
        {
            _poolScore = 0;
        }

        private void SetPoolMaterialDefaultColor()
        {
            _poolMaterialData.Material.color = Color.red;
        }
        
        private void SetPoolMaterialDefaultSmoothness()
        {
            _poolMaterialData.Material.SetFloat(MATERIAL_SMOOTHNESS, 0);
        }

        private void SetPoolMaterialNewSmoothness()
        {
            _poolMaterialData.Material.DOFloat(1, MATERIAL_SMOOTHNESS, 1f);
        }

        private void SetPoolMaterialNewColor()
        {
            _poolMaterialData.Material.DOColor(new Color(0.1607843f, 0.6039216f, 0.1766219f, 1f), 1f);
        }

        private void BarriersRotateX()
        {
            leftBarrier.transform.DORotate(new Vector3(DEGREE90, -DEGREE90, -DEGREE90), 1f);
            rightBarrier.transform.DORotate(new Vector3(-DEGREE90, -DEGREE90, -DEGREE90), 1f);
        }

        private void PoolGroundMoveY()
        {
            poolGround.transform.DOMoveY(POOL_GROUND_Y_POSITION, 1f);
        }
    }
}