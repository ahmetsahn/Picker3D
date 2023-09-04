using Runtime.Signals;
using UnityEngine;

namespace Runtime.PlayerSystem
{
    public class PlayerManager : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        
        private IPlayerInput _playerInput;
        
        private Rigidbody _rigidbody;
        
        private SO_Player _playerData;
        
        private const string PLAYER_DATA_PATH = "Data/Player/SO_Player";
        
        private void Awake()
        {
            GetPlayerData();

            Init();
        }

        private void Init()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _playerInput = new PlayerMouseInput();

            _playerMovement = new PlayerMovement(_playerData.PlayerMovementData, ref _rigidbody);
        }

        private void GetPlayerData()
        {
            _playerData = Resources.Load<SO_Player>(PLAYER_DATA_PATH);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onPlayerCanMove += _playerMovement.SetCanMove;
        }
        
        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onPlayerCanMove -= _playerMovement.SetCanMove;
        }

        private void FixedUpdate()
        {
            _playerMovement.Move(_playerInput.GetInput());
        }

        private void Update()
        {
            _playerInput.ReadInput();
        }
    }
}