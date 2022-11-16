# Show Me The Goods

T120B165 Saityno taikomųjų programų projektavimas, rudens semestro modulio projektas.

Studentas: Jokūbas Kvederaitis, IFF-9/10

2022

# Ataskaita
## 1.	Sprendžiamo uždavinio aprašymas	
### 1.1. Sistemos paskirtis

Projekto tikslas – sukurti WEB aplikacija, kurioje naudotojas galėtų rasti koncertus skelbimus.

Veikimo principas – visą sukurtą platformą sudaro dvi dalys – internetinė aplikacija bei aplikacijų programavimo sąsaja. Aplikacijoje bus trys rolės: administratorius, neregistruotas naudotojas bei rengejas. Neregistruotas vartotojas galės matyti visas renginius, koncertus ir galės juos filtruoti pagal norus, jeigu prisiregistruos prie internetinės aplikacijos rengejas, jie galės pridėti renginius prie sistemos. Tačiau prisiregistruoti reikės administartoriaus leidimo. Administratorius turės praeitų rolių galimybes ir galės priimti naujus rengėjus

### 1.2. Funkciniai reikalavimai
Neregistruotas sistemos naudotojas galės:

•	Peržiūrėti aplikacijos pradinį puslapį

•	Peržiūrėti renginių skelbimų sąrašą

•	Paspausti ant renginio ir peržiūrėti išamesnę informaciją

•	Pridėti komentąrą apie renginį

•	Prisijungti prie aplikacijos

•	Prisiregistruoti prie aplikacijos

Registruotas sistemos naudotojas galės:

•	Atsijungti nuo aplikacijos

•	Peržiūrėti savo sukurtų renginių skelbimų sąrašą

•	Sukurti renginio skelbimą

•	Pašalinti žrenginio skelbimą

•	Redaguoti renginio skelbimą

Sistemos administratorius gales:
•	Patvirtinti rengėjo registraciją

•	Matyti visus registruotus rengėjus

•	Pašalinti registruotus rengėjus

•	Redaguoti esamus komentarus

•	Pašalinti esamus komentarus


## 2.	Sistemos architektūra
Sistemos sudedamosios dalys:

•	Kliento pusė (angl. Front-End)  Angular

•	Serverio pusė (angl. Back-End)  .NET Core. Duomenų bazė – MySQL
![alt text](https://cdn.discordapp.com/attachments/406114988504252419/1032978916740182107/unknown.png)


