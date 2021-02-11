using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;

        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;
        private ListExecuteObject _interactiveObject;
        private readonly SaveGoodDataRepository _saveGoodDataRepository;
        private readonly SaveBedDataRepository _saveBedDataRepository;

        public InputController(PlayerBase player)
        {
            _playerBase = player;

            _saveDataRepository = new SaveDataRepository();
            _saveGoodDataRepository = new SaveGoodDataRepository();
            _saveBedDataRepository = new SaveBedDataRepository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0.0f, Input.GetAxis(AxisManager.VERTICAL));

            if (Input.GetKeyDown(_savePlayer))
            {
                _interactiveObject = new ListExecuteObject();
                int goodBonusNumber = 0;
                int bedBonusNumber = 0;
                foreach (var o in _interactiveObject)
                {
                    if (o is GoodBonus goodBonus)
                    {
                        //Debug.Log(goodBonus.name + goodBonusNumber);
                        _saveGoodDataRepository.Save(goodBonus, goodBonusNumber);
                        goodBonusNumber += 1;
                    }
                    if (o is BadBonus badBonus) //добить
                    {
                        //Debug.Log(badBonus.name + bedBonusNumber);
                        _saveBedDataRepository.Save(badBonus, bedBonusNumber);
                        bedBonusNumber += 1;
                    }
                        _saveDataRepository.Save(_playerBase);
                }
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _interactiveObject = new ListExecuteObject();
                int goodBonusNumber = 0;
                int bedBonusNumber = 0;
                foreach (var o in _interactiveObject)
                {
                    if (o is GoodBonus goodBonus)
                    {
                        //Debug.Log(goodBonus.name + goodBonusNumber);
                        _saveGoodDataRepository.Load(goodBonus, goodBonusNumber);
                        goodBonusNumber += 1;
                    }
                    if (o is BadBonus badBonus) //добить
                    {
                        _saveBedDataRepository.Load(badBonus, bedBonusNumber);
                        goodBonusNumber += 1;

                    }
                    _saveDataRepository.Load(_playerBase);
                }
            }
        }
    }

}
