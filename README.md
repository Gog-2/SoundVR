# Untiy Sound Тестовое
## Стек:
- [Unity 6000.3.18f1 LTS](https://unity.com/releases/editor/whats-new/6000.3.18f1#installs)
  - URP
  - OpenXR
  - XR Interaction Toolkit
- [Steam Audio](https://valvesoftware.github.io/steam-audio/) (Пространственое аудио)
- [UniTask](https://github.com/cysharp/unitask) (Кулдаун для Object Pool в "HitSource")

## Использовано в коде:
- [Конвенция майкросфт C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Патерн Singltone
- Патерн ObjectPool (от unity)

## Структура:
 ### Assets/My/Script
 - AudioModule - Оброботчик столкновений. Есть зависимости от наличие HitSourcePoolManager
 - HitSourcePoolManager - Пулл менеджер отвечающий за префабы звуков от столкновение для всех объектов с AudioModul
 - HitSource - Издавание звуков ударов от AudioModule, принимает от AudioModule: Звук, Громкость, Положение. Находиться в Pool от HitSourceManager
 - AudioPresetSO - Присеты звуков которые имеют 2 поля: Масив звуков ударов и сопративление воздуха (звучит как баг и на многиех объектах выключено)
 ### Assets/My/Scene
 - Основная сцена
 ### Assets/My/Prefabs
 - HitSourcePrefab - Префаб который иницилизируеться из пула от HitSourcePoolManager и издаёт звуки в нужных местах
 ### Assets/My/Audio
 Пресеты Звука
 -Book - Звуки кники
 -Mug - Кружка
 -PC - Компьютер и мониторы
 -Plastic - Растение, клавиатура, мышь, кресло синие
 -WheelChair - Стул на колёсиках
 
## Затраченое время приблизительно:
- Сцена (растановка асетов с запечкой света)  - 48 минут
- Настройка параметров (Rigbody и Audio Source) - 30 минут
- Разобраться с Steam Audio - 40 минут
- Поиск звуков - 1 час 30 минут
- Написание скриптов и фикс багов - 30 минут
- Монтаж с записью - 1 час
