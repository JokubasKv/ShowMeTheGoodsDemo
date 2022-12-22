# Show Me The Goods

T120B165 Saityno taikomųjų programų projektavimas, rudens semestro modulio projektas.

Studentas: Jokūbas Kvederaitis, IFF-9/10

2022

## Sistemos paskirtis

Leidti naudojtojams registruoti renginius kurie vyksta, ir kategorizuoti juos pagal tipus, kad kiti žmonės galėtų lengvai rasti juos.


### 1.2. Funkciniai reikalavimai
Neregistruotas sistemos naudotojas galės:
•	Peržiūrėti aplikacijos pradinį puslapį
•	Peržiūrėti renginių skelbimų sąrašą
•	Paspausti ant renginio ir peržiūrėti išamesnę informaciją
•	Prisijungti prie aplikacijos
•	Prisiregistruoti prie aplikacijos

Registruotas sistemos naudotojas galės:

•	Atsijungti nuo aplikacijos
•	Peržiūrėti savo sukurtų renginių skelbimų sąrašą
•	Pridėti komentąrą apie renginį
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

•	Kliento pusė (angl. Front-End)  Rest API

•	Serverio pusė (angl. Back-End)  .NET Core. Duomenų bazė – MySQL
![alt text](https://cdn.discordapp.com/attachments/406114988504252419/1032978916740182107/unknown.png)

## Naudotojo sąsajos projektas

Prieš pradėdamas kurti projekto kliento pusę susiprojektavau kliento pusės sąsajos langų
„wireframes“. Remdamasis šiais suprojektuotais „wireframes“ realizavau juos naudojant
React.js. 

Suprojektuoti langai bei jų realizacijos:

Pagrindinis puslapis:

![paveikslas](https://user-images.githubusercontent.com/90623592/209148192-8917123a-8447-4751-b2f0-06a3514b3037.png)
![paveikslas](https://user-images.githubusercontent.com/90623592/209146259-5fecf758-c3b2-43d2-b3d4-168d4cc848fb.png)

Prisijungimas ir registravimas

![paveikslas](https://user-images.githubusercontent.com/90623592/209149597-4b2c542c-600d-4d57-b8bc-15e652556480.png)
![paveikslas](https://user-images.githubusercontent.com/90623592/209149626-440f327e-b2dd-48fa-971d-154f9918520f.png)

![paveikslas](https://user-images.githubusercontent.com/90623592/209149259-3273a575-1954-4954-899e-0ca472b6689a.png)
![paveikslas](https://user-images.githubusercontent.com/90623592/209149306-075e9e5c-2e6c-4013-9c2e-ccb2eb2ed8d5.png)

Renginiu puslapis

Wireframe yra toksai pats kaip pagrindinio puslapio
![paveikslas](https://user-images.githubusercontent.com/90623592/209149840-bde25a04-e86b-45c4-80bb-2851270b5a83.png)

Renginio Puslapis
![paveikslas](https://user-images.githubusercontent.com/90623592/209151869-827aac1a-ef77-45c5-aaee-2e1206d7952e.png)
![paveikslas](https://user-images.githubusercontent.com/90623592/209150153-d88430e1-ef3f-4d95-99b1-22b414907572.png)

# API specifikacija

## **POST Register**
Creates a new user using the provided email, password.
#### **URL Template**
https://{hostname}:{port}/api/register/
#### **Resource Information**
|||
| ----------- | ----------- |
| Requires Authentication | No |
| Response Formats | JSON |
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| userName | yes | any string | "string" |
| email | yes | any email, must be in the format of "anything@anything" | "vardenis@gmail.com" |
| password | yes | any string | "VerySafeFPassword1!" |
#### **Example Request**
POST https://{hostname}:{port}/api/user/
#### **Example Response**
```
200
{
  "userName": "string",
  "password": "VerySafeFPassword1!",
  "email": "vardenis@gmail.com",
}
```
## **POST Login**
Given login details returns a refresh token (base64 string) and JWT access token
#### **URL Template**
https://{hostname}:{port}/api/login
#### **Resource Information**
|||
| ----------- | ----------- |
| Requires Authentication | No |
| Response Formats | JSON |
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| userName | yes | any string | "string" |
| password | yes | any string | "VerySafeFPassword1!" |
#### **Example Request**
POST https://{hostname}:{port}/api/user/token/
#### **Example Response**
```
200
{
  "userName": "string",
  "password": "VerySafeFPassword1!",
}
```





