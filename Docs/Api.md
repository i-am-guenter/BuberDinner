# Buber Dinner API

- [Buber Dinner API] (#buber-dinner-api)
    -[Auth](#auth)
        -[Register](#register)
            -[Register Request](#register-request)
            -[Register Rsponse](#register-response)
        -[Login](#login)
            -[Login Request](#login-request)
            -[Login Respsonse](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Guenter",
    "lastName": "Bayerl",
    "email": "guenter@die-bayerls.net",
    "password": "Password1234!"
}
```
#### Register Response
```js
200 OK
```

```json
{
    "id": "",
    "firstName": "Guenter",
    "lastName": "Bayerl",
    "email": "guenter@die-bayerls.net",
    "token": "eyJhb..hbbQ"
}
```

### Login

```json
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email": "guenter@die-bayerls.net",
    "password": "Password1234!"
}
```
#### Login Response
```js
200 OK
```

```json
{
    "id": "",
    "firstName": "Guenter",
    "lastName": "Bayerl",
    "email": "guenter@die-bayerls.net",
    "token": "eyJhb..hbbQ"
}
```