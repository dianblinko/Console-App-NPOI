# Console-App-NPOI

Не смог до конца выполнить 11 пункт задания, а точнее построить графики по аттрибуту Pipe. Никак не смог найти способ. Очень прошу подсказать. 

Задание: Отчёт в MS Word при помощи библиотеки NPOI
1)	Создать консольное приложение
2)	Приложение должно запросить при старте количество объектов для отчёта
3)	На основании введенного числа объектов, формируется коллекция объектов
4)	Объекты могут быть типа Simple или Collection (количество объектов того или иного типа задается произвольно)
5)	И тот и другой тип должны обладать следующим набором свойств:

        /// Название

        /// Давление, атм.

        /// Температура на глубине L, °С.

        /// Объемный фактор газа.

        /// Объемный фактор нефти.

        /// Объемный фактор воды.

        /// Теплопроводность газа.

        /// Теплопроводность нефти.

        /// Теплопроводность воды.

        /// Теплопроводность смеси.

        /// Тип потока на глубине L.

        /// Дебит смеси с водой.      

        /// Дебит газа в условиях насоса.

        /// Дебит газа в условиях насоса.

        /// Дебит нефти в условиях насоса.

        /// Дебит воды в условиях насоса.

        /// Дебит воды в условиях насоса.

        /// Дебит воды в условиях насоса.

        /// Расход НГС (Объемный, Стд), м3/сутки.

        /// Расход НГС (Объемный, Действ), м3/сутки.

        /// Массовый Расход воды.

        /// Расход НГС (Массовый), кг/с.

        /// Расход НГС (Массовый), Киломоль/сек.

        /// Обводненность в долях.

        /// Мольная доля газа (композиционный поток).

        /// Объемная доля газа.

        /// Вязкость газа.

        /// Вязкость нефти.

        /// Вязкость воды.

        /// Вязкость смеси.

        /// Коэффициент  теплообмена

6)	Объекты типа Collection кроме того должны иметь свойство Pipe, которое представляет собой коллекцию объектов с полями:

        /// Длина от начала трубы.

        /// Давление, атм.

7)	Поле это должен сформироваться отчёт в формате MS Word
8)	Отчёт должен содержать следующие разделы
a.	Содержание (с навигацией по разделам)
b.	Перечень всех объектов
c.	Описание объектов типа Simple
d.	Описание объектов типа Collection
9)	Раздел «Перечень всех объектов» должен содержать таблицу со списком всех объектов, с колонками: номер, название объекта, тип объекта
10)	Раздел «Описание объектов типа Simple» должен содержать набор таблиц для каждого объекта из списка с типом Simple. Количество колонок соответствует количеству свойств объекта.
11)	Раздел «Описание объектов типа Collection» должен содержать набор таблиц для каждого объекта из списка с типом Simple. Количество колонок соответствует количеству свойств объекта. После каждой таблицы необходимо поместить график, построенный на основе свойства Pipe, т.е. зависимость давления от глубины.
12)	Пользователь должен видеть прогресс создания отчёта.
13)	Генерация отчета должна быть осуществлена при помощи библиотеки  NPOI.
