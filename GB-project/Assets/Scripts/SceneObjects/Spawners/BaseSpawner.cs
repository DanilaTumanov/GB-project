using GBproject.SceneObjects;
using System.Collections;
using UnityEngine;

namespace DBproject.SceneObjects.Spawners
{
    /// <summary>
    /// Класс для создания базовых спаунеров.
    /// Наследует класс <see cref="BaseSceneObject"/>
    /// </summary>
    public class BaseSpawner : BaseSceneObject
    {
        #region Fields
        /// <summary>
        /// Спаунящийся объект.
        /// </summary>
        [SerializeField]
        [Tooltip("Объект типа BaseSceneObject, который спаунится данным спаунером.")]
        private BaseSceneObject _spawnerObj;

        /// <summary>
        /// Минимальное и максимальное время между спаунами.
        /// </summary>
        [SerializeField]
        [Tooltip("Минимальное и максимальное время между спаунами.")]
        private Vector2 _timeBetweenSpawns;

        /// <summary>
        /// Признак пассивности спаунера.
        /// Если <code>true</code> то объекты спаунятся только по команде.
        /// Если <code>false</code> то объекты спаунятся в автоматическом режиме.
        /// </summary>
        [SerializeField]
        [Tooltip("Если false, то спаунер спаунит объекты в автоматическом режиме. Если true, то объекты спаунятся только по команде.")]
        private bool _isPassive;

        /// <summary>
        /// Признак проверки видимости камерой. 
        /// Если <code>true</code> то объекты спаунятся только когда сапаунер находится вне зоны видимости камеры.
        /// Если <code>false</code> то объекты спаунятся вне зависимости от того находится ли спаунер в зоне видимости камеры.
        /// </summary>
        [SerializeField]
        [Tooltip("Если true, то объекты спаунятся только когда сапаунер находится вне зоны видимости камеры.")]
        private bool _cameraCheck;

        /// <summary>
        /// Признак является ли спаунер видимым для камеры в данный момент.
        /// </summary>
        private bool _isVisible;
        #endregion

        #region Properties
        /// <summary>
        /// Спаунящийся объект.
        /// </summary>
        public BaseSceneObject SpawnerObject
        {
            get
            {
                return _spawnerObj;
            }
        }

        /// <summary>
        /// Минимальное и максимальное время между спаунами.
        /// </summary>
        public Vector2 TimeBetweenSpawns
        {
            get
            {
                return _timeBetweenSpawns;
            }
        }

        /// <summary>
        /// Признак проверки видимости камерой. 
        /// Если <code>true</code> то объекты спаунятся только когда сапаунер находится вне зоны видимости камеры.
        /// Если <code>false</code> то объекты спаунятся вне зависимости от того находится ли спаунер в зоне видимости камеры.
        /// </summary>
        public bool IsPassive
        {
            get
            {
                return _isPassive;
            }
        }

        /// <summary>
        /// Признак проверки видимости камерой. 
        /// Если <code>true</code> то объекты спаунятся только когда сапаунер находится вне зоны видимости камеры.
        /// Если <code>false</code> то объекты спаунятся вне зависимости от того находится ли спаунер в зоне видимости камеры.
        /// </summary>
        public bool CameraCheck
        {
            get
            {
                return _cameraCheck;
            }
        }
        #endregion

        #region MB methods
        private void Awake()
        {
            Random.InitState(System.DateTime.Today.Millisecond);
        }

        private void Start()
        {
            if (!IsPassive)
                StartCoroutine(SpawnCoroutine());
        }

        void OnBecameVisible()
        {
            _isVisible = true;
        }

        void OnBecameInvisible()
        {
            _isVisible = false;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Начать спаунить объекты в автоматическом режиме.
        /// </summary>
        public void StartSpawning()
        {
            _isPassive = false;
            StartCoroutine(SpawnCoroutine());
        }

        /// <summary>
        /// Остановить спаунер.
        /// </summary>
        public void StopSpawning()
        {
            _isPassive = true;
            StopCoroutine(SpawnCoroutine());
        }

        /// <summary>
        /// Выполнить единичный спаун объекта.
        /// </summary>
        public void Spawn()
        {
            if (!(CameraCheck && _isVisible))
            {
                Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Rigidbody2D propInstance = Instantiate(SpawnerObject.GetComponent<Rigidbody2D>(), spawnPos, Quaternion.identity) as Rigidbody2D;
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Корутина, реализующая спаун объекта, через случайные промежутки времени.
        /// Минимальное и максимальное значение промежутка времени определяется вектором <see cref="TimeBetweenSpawns"/>
        /// </summary>
        private IEnumerator SpawnCoroutine()
        {
            float waitTime = Random.Range(TimeBetweenSpawns.x, TimeBetweenSpawns.y);
            yield return new WaitForSeconds(waitTime);
            if (!IsPassive)
            {
                Spawn();
                StartCoroutine(SpawnCoroutine());
            }
            yield return null;
        }
        #endregion
    }
}