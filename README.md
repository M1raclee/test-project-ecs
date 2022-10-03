# Test Project ECS
Реализация тестового задания на позицию "Senior Unity Developer" с ECS архитектурой.
Тестовое задание было реализовано в минимальнои и достаточном объеме, чтобы соответствовать поставленным треованиям.
Общее время, затраченное на тестовое: 17 часов (из них порядка 14 часов непосредственно на кодинг)

## Игра
Для корректной работы игру стоит запускать со сцены запуска (<b>Init</b>) 

## Серверные файлы
Список серверных файлов:
1. Системы (Server/Systems):
- ButtonInitializeSystem
- DoorsInitializeSystem
- PlayerInitializeSystem
- ButtonsMovementSystem
- DoorMovementSystem
- LocationUpdatingSystem
- MovementSystem

2. Компоненты (Shared/Components):
- ButtonsInteractor
- ButtonState
- Identifier
- Location
- MovementInput
- MovementParams
- MovementResult
- PositionRestrictions

3. Тэги (Shared/Tags)
- ButtonTag
- DoorTag
- PlayerTag

4. Зависимости:
- LeoECS lite
- Интерфейс IStaticData и его имплементация.

Безусловно, в текущем варианте реализации серверные файлы не являются достаточными для полной работоспособности server-side (не хватает мостов передачи входящих данных, server-side регистрации ECS и тп), однако минимальное условие тестового задания выполняется: системы содержат в себе всю основную* бизнес-логику и могут быть симулированы отдельно от unity.
![Server files](https://drive.google.com/uc?export=view&id=1_-NNu6bDrohkRLVFyPYxq_ChlaVVT4NB)
![Success build](https://drive.google.com/uc?export=view&id=19YXF7xkJWmXCh7V967wIl6Rho6oXYxzV)
