# Программа учета проката дисков с фильмами

## Описание
Десктопная программа для автоматизации учета движения кинопродукции, записанной на DVD-дисках и аренды этой кинопродукции клиентами в обмен на залог в виде документа или денежного эквивалента. Позволяет производить отчет по состоянию видеотеки 

### Требования для запуска:
* [.NET 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
* [MySQL version 8.0.26](https://downloads.mysql.com/archives/community/)
* [MySQL Connector/Net 8.0.26](https://downloads.mysql.com/archives/c-net/)
* [MySQL Workbench 8.0.26](https://downloads.mysql.com/archives/workbench/)
* [Git](https://docs.github.com/en/desktop/installing-and-configuring-github-desktop/installing-and-authenticating-to-github-desktop/installing-github-desktop)
* [VisualStudio 2019](https://docs.microsoft.com/ru-ru/visualstudio/releases/2019/history)

### Запуск:
* `git clone https://github.com/voffan/ivt-19-1.git`
* `git checkout Buyvol`
* `cd Autoreport`
* `start Autoreport.sln` - открыть решение проекта в VisualStudio
* Перейти в панель "Средства" -> "Диспетчер пакетов Nuget" -> "Управление пакетами Nuget". Установить зависимости
* Далее запустить MySQL Workbench. Создать базу данных Autoreport
* Вернуться в VisualStudio. После установки зависимостей и создания БД перейти "Средства" -> "Диспетчер пакетов Nuget" -> "Консоль диспетчера пакетов".
* Ввести команду `update-database`
* Запуск проекта: нажать Ctrl+F5 ИЛИ перейти в пенель "Отладка" -> "Запуск без отладки"

## Roadmap:
### MVP
* Главное окно программы со вкладками - ✅
* Показать список Клиентов, Сотрудников, Фильмов, Дисков, Заказов, Залогов, Режиссеров - ✅
* Формы добавления моделей, не связанных с прочими моделями: Клиентов, Сотрудников, Режиссеров - ✅
* Логика обавления моделей, не связанных с прочими моделями - ✅
* Режим выбора связанных моделей и форма их выбора - ✅
* Формы добавления связных моделей: Фильмов, Дисков, Залогов, Заказов - ✅
* Логикика добавления связных моделей  - ✅
* Удаление моделей - ✅

### Авторизация сотрудников
* Установка логинов и паролей сотрудникам - ✅
* Окно авторизации сотрудников - ✅
* Логика авторизации - ✅

### Редактирование записей
* Формы редактирования моделей: Клиентов, Сотрудников, Фильмов, Дисков, Заказов, Залогов, Режиссеров - частично реализованы
* Логика редактирования моделей: Клиентов, Сотрудников, Фильмов, Дисков, Заказов, Залогов, Режиссеров - 1/7

### Поиск записей
* Формы поиска моделей: Клиентов, Сотрудников, Фильмов, Дисков, Заказов, Залогов, Режиссеров
* Логика поиска

### Отчет
* Окно генерации отчета
* Логика генерации отчета