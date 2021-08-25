using System;
using System.Collections.Generic;
using Asteroid.GameLogic;
using UnityEngine;

namespace Asteroid.View
{
    public class GameView : MonoBehaviour
    {
        public GameLogicConfig gameLogicConfig;
        public GameVisualConfig gameVisualConfig;
        public UserInfoScreen userInfoScreen;
        public GameOverScreen gameOverScreen;

        private readonly GameObjectPool _pool = new GameObjectPool();

        private Game _game;


        private readonly Dictionary<int, GameObject> _spaceObjectsDictionary = new Dictionary<int, GameObject>();
        private GameObject[] _players;
        private GameObject _laser;

        private Vector2[] _playerDiff;

        private void Start()
        {
            _game = new Game(gameLogicConfig);
            Array.Resize(ref _players, 9);
            for (var i = 0; i < _players.Length; i++)
            {
                _players[i] = Instantiate(gameVisualConfig.player);
            }

            _playerDiff = new[]
            {
                Vector2.zero,
                new Vector2(-gameLogicConfig.boardWidth, 0), new Vector2(gameLogicConfig.boardWidth, 0),
                new Vector2(0, gameLogicConfig.boardHeight), new Vector2(0, -gameLogicConfig.boardHeight),
                new Vector2(-gameLogicConfig.boardWidth, -gameLogicConfig.boardHeight),
                new Vector2(gameLogicConfig.boardWidth, gameLogicConfig.boardHeight),
                new Vector2(-gameLogicConfig.boardWidth, gameLogicConfig.boardHeight),
                new Vector2(gameLogicConfig.boardWidth, -gameLogicConfig.boardHeight),
            };
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;

            if (_game.SpaceModel.State == GameState.Game)
            {
                _game.Input(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
                    Input.GetKeyDown(KeyCode.Space));

                while (deltaTime > 0f)
                {
                    var dt = Math.Min(deltaTime, gameLogicConfig.minTimeTick);

                    CreateCommands();
                    _game.NextTimer(dt);
                    RemoveCommands();
                    MoveCommands();
                    LaserCommand();
                    UICommand();

                    deltaTime -= dt;
                }

                userInfoScreen.SetData(_game.SpaceModel.PlayerData);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ClearBoard();
                    _game.StartGame();
                }
            }
        }

        private void UICommand()
        {
            switch (_game.SpaceModel.State)
            {
                case GameState.GameOver when !gameOverScreen.gameObject.activeSelf:
                    gameOverScreen.gameObject.SetActive(true);
                    gameOverScreen.SetData(_game.SpaceModel.PlayerData.Score);
                    break;
                case GameState.Game when gameOverScreen.gameObject.activeSelf:
                    gameOverScreen.gameObject.SetActive(false);
                    break;
            }
        }

        private void LaserCommand()
        {
            if (_game.SpaceModel.PlayerData.Laser == null)
            {
                if (_laser != null) _laser.SetActive(false);
            }
            else
            {
                if (_laser == null) _laser = Instantiate(gameVisualConfig.laser);
                _laser.SetActive(true);
                _laser.transform.position = _game.SpaceModel.PlayerData.Laser.Pos;
                _laser.transform.rotation = _game.SpaceModel.PlayerData.Laser.Rotation;
            }
        }

        private void CreateCommands()
        {
            foreach (var item in _game.SpaceModel.SpaceObject.NewObjectPool)
            {
                if (item.Value is AsteroidData ad)
                {
                    _spaceObjectsDictionary.Add(item.Key, _pool.Get(gameVisualConfig.asteroids[ad.sizeIndex]));
                }
                else if (item.Value is UfoData)
                {
                    _spaceObjectsDictionary.Add(item.Key, _pool.Get(gameVisualConfig.ufo));
                }
                else if (item.Value is BulletData)
                {
                    _spaceObjectsDictionary.Add(item.Key, _pool.Get(gameVisualConfig.bullet));
                }
            }
        }

        private void MoveCommands()
        {
            foreach (var item in _game.SpaceModel.SpaceObject.Objects)
            {
                if (_spaceObjectsDictionary.TryGetValue(item.Key, out var value))
                {
                    value.transform.position = item.Value.position;
                }
                else
                {
                    throw new Exception("Not found:" + item.Key);
                }
            }

            for (var index = 0; index < _players.Length; index++)
            {
                var player = _players[index];
                player.transform.position = _game.SpaceModel.PlayerData.Position + _playerDiff[index];
                player.transform.rotation = _game.SpaceModel.PlayerData.Rotation;
            }
        }

        private void RemoveCommands()
        {
            foreach (var item in _game.SpaceModel.SpaceObject.RemoveObjectPool)
            {
                if (_spaceObjectsDictionary.TryGetValue(item.Key, out var value))
                {
                    _pool.Release(value);
                    _spaceObjectsDictionary.Remove(item.Key);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        private void ClearBoard()
        {
            foreach (var item in _spaceObjectsDictionary)
            {
                _pool.Release(item.Value);
            }

            _spaceObjectsDictionary.Clear();
        }
    }
}