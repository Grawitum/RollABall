using UnityEngine;

namespace RollABall
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;

        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;
        private ListInteractiveObject _interactiveObject;
        private readonly SaveGoodDataRepository _saveGoodDataRepository;
        private readonly SaveBedDataRepository _saveBedDataRepository;

        private int _goodBonusNumber;
        private int _bedBonusNumber;

        public InputController(PlayerBase player)
        {
            _playerBase = player;
            _saveDataRepository = new SaveDataRepository();
            _saveGoodDataRepository = new SaveGoodDataRepository();
            _saveBedDataRepository = new SaveBedDataRepository();
        }

        public void Execute(float deltaTime)
        {
            _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0.0f, Input.GetAxis(AxisManager.VERTICAL));

            if (Input.GetKeyDown(_savePlayer))
            {
                _interactiveObject = new ListInteractiveObject();
                _goodBonusNumber = 0;
                _bedBonusNumber = 0;
                for (int i = 0; i < _interactiveObject.Length; i++)
                {
                    if (_interactiveObject[i] is GoodBonus goodBonus)
                    {
                        _saveGoodDataRepository.Save(goodBonus, _goodBonusNumber);
                        _goodBonusNumber += 1;
                    }
                    if (_interactiveObject[i] is BadBonus badBonus)
                    {
                        _saveBedDataRepository.Save(badBonus, _bedBonusNumber);
                        _bedBonusNumber += 1;
                    }
                    _saveDataRepository.Save(_playerBase);
                }
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                _interactiveObject = new ListInteractiveObject();
                _goodBonusNumber = 0;
                _bedBonusNumber = 0;
                for (int i = 0; i < _interactiveObject.Length; i++)
                {
                    if (_interactiveObject[i] is GoodBonus goodBonus)
                    {
                        _saveGoodDataRepository.Load(goodBonus, _goodBonusNumber);
                        _goodBonusNumber += 1;
                    }
                    if (_interactiveObject[i] is BadBonus badBonus)
                    {
                        _saveBedDataRepository.Load(badBonus, _bedBonusNumber);
                        _goodBonusNumber += 1;
                    }
                    _saveDataRepository.Load(_playerBase);
                }
            }
        }
    }

}
