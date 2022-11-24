#Buber Dinner API

- [Auth](#auth)
  - [Register](#register)
  - [Register Request](#register-request)
- [Register Response](#register-response)
  - [Login](#login)
  - [Register Request](#register-request-1)


## Auth

### Register

```js
POST {{host}}/auth/register
```

### Register Request

```json
{
    "firstName":"Welton",
    "lastName":"Castoldi",
    "email":"weltoncastoldi@hotmail.com",
    "password":"123"
}
```

## Register Response
```js
200 OK
```

```json
{
    "id":"5b9bff7b-8d5f-477c-a0fe-cfe04e7ce8d9",
    "lastName":"Castoldi",
    "email":"weltoncastoldi@hotmail.com",
    "token":"sdklajsdaljl12312lk",

}
```
### Login

```js
POST {{host}}/auth/login
```

### Register Request

```json
{
    "firstName":"Welton",
    "lastName":"Castoldi",
    "email":"weltoncastoldi@hotmail.com",
    "password":"123"
}
```
