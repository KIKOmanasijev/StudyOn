# StudyOn ⚽
 StudyOn веб апликација која има за цел да го подобри искуството на оние кои редовно спортуваат.

### Кој е најголемиот проблем кај луѓето кои спортуваат и како ние ќе го решиме? 💡
- Свесни сме дека најголемиот проблем во денешно време со кои се соочуват луѓето што сакат да спортуваат е тоа што тие тешко можат да најдат доволен број на луѓе за да 
одржат било каков натпревар. Нашето решение е платформа на која ќе може да се закажи натпревар, да се најдат спортисти, да се организира турнири и сл.
Сето ова ќе биде додатно олеснето со тоа што ние ќе чуваме податоци за сите спортски игралишта во градот Скопје. За секое игралиште ќе може да се виде неговата локација,
рејтинг, коментари, состојба и сл.

## Како да ја стартувате скриптата за филтрирање на податоците? 💻
Најпрвин навигираме во фолдерот Script и од таму отвараме PowerShell прозорец. За да можеме да ја стартуваме скриптата таа побарува два влезни параметри:
- Изворни нефилтрирани податоци (/data/input.osm)
- Дестинација за филтрираните податоци и име на фајл со формат .csv

## Пример за повикување на скриптата ✔
`./script.sh -s ../data/input.osm -d ../data/output.csv`

## Како да ја стартувате скриптата за креирање на база на податоци и популирање на истата? 💻
Install python
Add python to path
Open cmd
Run: pip install sqlalchemy
Run: pip install psycopg2
Cd to folder with createDB.sh
Run: python createDB.sh