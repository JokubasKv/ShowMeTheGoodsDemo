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

![paveikslas](https://user-images.githubusercontent.com/90623592/209153760-69045c47-76cf-4f31-a6a7-669898231595.png)
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
![paveikslas](https://user-images.githubusercontent.com/90623592/209153814-5039cb8c-7672-4509-9529-a1953b5cc0f2.png)
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
## EventType Endpoints
|||
|-|-|
| Requires Authentication | No |
| Response Formats | JSON |
---
## **GET Event Type**
Returns event type based on id.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
#### **Example Request**
GET https://{hostname}:{port}/api/eventType/1
#### **Example Response**
```
200
{
  "id": 1,
  "name": "Concert",
  "description": "A buzzling palce of music and people",
  "pictureLink": "https://images.pexels.com/photos/1763075/pexels-photo-1763075.jpeg?cs=srgb&dl=pexels-sebastian-ervi-1763075.jpg&fm=jpg",
  "creation
  ": "2022-11-16T12:15:25.2794656"
}
```
## **GET Event Types**
Returns all event types.
#### **URL Template**
https://{hostname}:{port}/api/eventType
#### **Example Request**
GET https://{hostname}:{port}/api/eventType
#### **Example Response**
```
200
[
    {
      "id": 1,
      "name": "Concert",
      "description": "A buzzling palce of music and people",
      "pictureLink": "https://images.pexels.com/photos/1763075/pexels-photo-1763075.jpeg?cs=srgb&dl=pexels-sebastian-ervi-1763075.jpg&fm=jpg",
      "creationDate": "2022-11-16T12:15:25.2794656"
    },
    {
        ...
    }
]
```

## **POST Event Type**
Creates event type.
#### **URL Template**
https://{hostname}:{port}/api/eventType
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| name | yes | any string | "Picnic" |
| description | yes | any string | "description" |
| pictureLink | yes | any string | "https://linkTopicture.jpg" |
#### **Example Request**
```
POST https://{hostname}:{port}/api/eventType/
{
  "name": "Picnic",
  "description": "description",
  "pictureLink": "https://linkTopicture.jpg"
}
```
#### **Example Response**
```
201
{
  "id": 17,
  "name": "Picnic",
  "description": "description",
  "pictureLink": "https://linkTopicture.jpg",
  "creationDate": "2022-12-22T14:24:52.6667221Z"
}
```

## **PUT Event Type**
Updates event type.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| description | yes | any string | "description" |
| pictureLink | yes | any string | "https://linkTopicture.jpg" |
#### **Example Request**
```
PUT https://{hostname}:{port}/api/eventType/17
{
  "description": "description",
  "pictureLink": "https://linkTopicture.jpg"
}
```
#### **Example Response**
```
200
{
  "id": 17,
  "name": "Picnic",
  "description": "description",
  "pictureLink": "[string](https://linkTopicture.jpg)",
  "creationDate": "2022-12-22T14:24:52.6667221"
}
```

## **DELETE Event Type**
Deletes event type.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
#### **Example Request**
DELETE https://{hostname}:{port}/eventType/6
#### **Example Response**
```
Status 200
```

## Events Endpoints
|||
|-|-|
| Requires Authentication | Yes |
| Response Formats | JSON |
---
## **GET Event by id**
Returns event based on id.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
#### **Example Request**
GET https://{hostname}:{port}/api/eventType/1/event/2
#### **Example Response**
```
200
{
  "id": 2,
  "name": "Aluminum Oxide +2",
  "description": "Amazing concert of amazingness ha ahaha",
  "place": "Place of cool",
  "price": 56,
  "eventDate": "0001-01-01T00:00:00",
  "pictureLink": "https://upload.wikimedia.org/wikipedia/commons/c/cc/Corundum-3D-balls.png",
  "creationDate": "2022-11-18T10:17:57.3897278",
  "eventTypeId": 1
}
```

## **GET All Events**
Returns all events.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
#### **Example Request**
GET https://{hostname}:{port}/api/eventType/1/event
#### **Example Response**
```
200
[
  {
    "id": 2,
    "name": "Aluminum Oxide +2",
    "description": "Amazing concert of amazingness ha ahaha",
    "place": "Place of cool",
    "price": 56,
    "eventDate": "0001-01-01T00:00:00",
    "pictureLink": "https://upload.wikimedia.org/wikipedia/commons/c/cc/Corundum-3D-balls.png",
    "creationDate": "2022-11-18T10:17:57.3897278",
    "eventTypeId": 1
  },
  {
    "id": 7,
    "name": "The Birds",
    "description": "The best band in the world. The Birds are coming to Kaunas",
    "place": "Kaunas",
    "price": 231,
    "eventDate": "0001-01-01T00:00:00",
    "pictureLink": "https://upload.wikimedia.org/wikipedia/commons/2/2a/Frans_Snyders_-_Concert_of_Birds_-_WGA21527.jpg",
    "creationDate": "2022-12-16T10:06:16.8576624",
    "eventTypeId": 1
  }
]
```

## **POST Event**
Creates event.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| name | yes | any string | "name" |
| description | yes | any string | "description" |
| place | yes | any string | "invalid address" |
| price | yes | 32 bit integer | 56 |
| eventDate | yes | string with datetime | "2022-12-22T14:40:38.872Z" |
| place | yes | any string | "https://linkTopicture.jpg" |
#### **Example Request**
```
POST https://{hostname}:{port}/api/eventType/3/series
{
  "name": "name",
  "description": "description",
  "place": "invalid address",
  "price": 56,
  "eventDate": "2022-12-22T14:40:38.872Z",
  "pictureLink": "https://linkTopicture.jpg"
}
```
#### **Example Response**
```
201
{
    "id": 12,
    "name": "name",
    "description": "description",
    "place": "invalid address",
    "price": 56,
    "eventDate": "2022-12-22T14:40:38.872Z",
    "pictureLink": "https://linkTopicture.jpg",
    "creationDate": "2022-12-22T16:47:26.3482169+02:00",
    "eventTypeId": 3
}
```

## **UPDATE Event**
Updates event.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
| name | yes | any string | "name" |
| description | yes | any string | "description" |
| place | yes | any string | "invalid address" |
| price | yes | 32 bit integer | 56 |
| eventDate | yes | string with datetime | "2022-12-22T14:40:38.872Z" |
| place | yes | any string | "https://linkTopicture.jpg" |
#### **Example Request**
```
PUT https://{hostname}:{port}/api/eventType/3/event/12
{
  "name": "name",
  "description": "new description",
  "place": "invalid address",
  "price": 56,
  "eventDate": "2022-12-22T14:40:38.872Z",
  "pictureLink": "https://linkTopicture.jpg"
}
```
#### **Example Response**
```
200
{
    "id": 12,
    "name": "name",
    "description": "new description",
    "place": "invalid address",
    "price": 56,
    "eventDate": "2022-12-22T14:40:38.872Z",
    "pictureLink": "https://linkTopicture.jpg",
    "creationDate": "2022-12-22T16:47:26.3482169",
    "eventTypeId": 3
}
```

## **DELETE Event**
Deletes event.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
#### **Example Request**
DELETE https://{hostname}:{port}/api/eventType/6/event/3
#### **Example Response**
```
Status 200
```

## Comments Endpoints
|||
|-|-|
| Requires Authentication | No |
| Response Formats | JSON |
---

## **GET comment**
Returns comment based on id.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}/comments/{commentId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
| commentId | yes | 32 bit integer comment ID | 1 |
#### **Example Request**
GET https://{hostname}:{port}/api/eventType/1/event/2/comments/6
#### **Example Response**
```
200
{
  "id": 6,
  "content": "Commentarino",
  "creationDate": "2022-12-22T16:55:58.6715987",
  "eventId": 2
}
```

## **GET All Comments**
Returns all comments.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}/comments
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
#### **Example Request**
GET https://{hostname}:{port}/api/eventType/1/event/2/comments
#### **Example Response**
```
200
[
  {
    "id": 6,
    "content": "Commentarino",
    "creationDate": "2022-12-22T16:55:58.6715987",
    "eventId": 2
  },
  {
    "id": 7,
    "content": "Another great comment",
    "creationDate": "2022-12-22T16:58:38.9270211",
    "eventId": 2
  },
  { ... }
]
```

## **POST Comments**
Creates comment.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}/comments
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
| content | Yes | any string | "comment" |
#### **Example Request**
```
POST https://{hostname}:{port}/api/eventType/1/event/2/comments
{
  "content": "comment"
}
```
#### **Example Response**
```
{
  "id": 8,
  "content": "comment",
  "creationDate": "2022-12-22T17:01:46.2365392+02:00",
  "eventId": 2
}
```

## **PUT Comment**
Updates comment.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}/comments/{commentId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
| commentId | yes | 32 bit integer comment ID | 1 |
| content | Yes | any string | "comment" |
#### **Example Request**
```
PUT https://{hostname}:{port}/api/eventType/6/event/3/comments/8
{
  "content": "better comment"
}
```
#### **Example Response**
```
200
{
  "id": 8,
  "content": "better comment",
  "creationDate": "2022-12-22T17:01:46.2365392",
  "eventId": 2
}
```

## **DELETE Comment**
Deletes comment.
#### **URL Template**
https://{hostname}:{port}/api/eventType/{eventTypeId}/event/{eventId}/comments/{commentId}
#### **Parameters**
| Name | Required | Description | Example |
|-|-|-|-|
| eventTypeId | yes | 32 bit integer eventType ID | 1 |
| eventId | yes | 32 bit integer event ID | 1 |
| commentId | yes | 32 bit integer comment ID | 1 |
#### **Example Request**
DELETE https://{hostname}:{port}/api/eventType/1/event/2/comments/8
#### **Example Response**
```
Status 200
```

# Išvados

Laboratorinių darbų metu .NET 6.0 aplinkoje pavyko sukurti REST API renginiu kurimo sistemai su autorizacija bei autentifikacija naudojant JWT. Sukurtam API buvo parengta grafinė sąsaja, naudojant Rest API. Projektas yra pasiekamas saityne, tai buvo atlikta naudojant Azure. Tačiau nepavyo sukurti visus funkcinius reikalavimus pagal aprašyma, po kolkas authetifikacija leidžia keisti renginio duomenis tiktais renginio kūrėjui arba žmogui su admin role. Išskirtinės rolių funkcijos nebuvo sukurtos.



