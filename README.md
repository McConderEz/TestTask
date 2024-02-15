**Цель:** Разработать программу, которая обрабатывает данные из двух различных файлов форматов .xml и .csv, и генерирует итоговый файл в формате .json.

**Описание Задачи:**

1. **Входные Данные:**
    - Программа получает на вход файлы. Из двух файлов она сопоставляет единный набор данных для дальнейшей работы с ним. Файлы в формате .xml, второй в формате .csv.
    - Файлы могут поступать не одновременно. Программа должна уметь обрабатывать поступающие файлы по мере их появления и работать только с тем набором данных, который удалось сформировать из двух сопоставленных csv и xml.
    - Могут сначала приходить только CSV файлы, например 5 штук, затем XML  файлы, которые не обязаны быть свзяаны с предыдущеми CSV. Если среди этих CSV и XML программа обноруживает связанные файлы, она готова работать с этим набором данных, остальные файлы, которые еще не получили связанный файл, продолжают ожидать.
2. **Обработка Данных:**
    - После получения каждого файла программа сопоставляет его с существующими файлами, чтобы найти свою пару.
    - Если найдены 2 файла, которые можно сопоставить, программа перед генерацией итогового файла, выводит уведомление(в любом виде, можно просто Label на форме) о количестве записей, которые будут сформированы.
    - Если удалось найти 2 связанных файла, программа по нажатию на кнопку на форме формирует итоговый файл/отчет.
3. **Итоговый Файл:**
    - Для начала процесса генерации ответного файла, должна быть предусмотрена кнопка "Сформировать отчет".
    - Результатом работы программы является файл в формате .json, содержащий совмещенные данные из обоих входных файлов.
4. **Настройки:**
    - Возможность задавать директории для входных файлов и для сохранения итогового файла. Это можно реализовать через графический интерфейс или настройками в файле (например, Settings.xml или Settings.json).