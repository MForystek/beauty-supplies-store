# Beauty supplies store

Website for beauty supplies store in Jasło.

## Development

### **Dev mode**

To run the project in development mode use:

```
./run dev up
```

or

```
docker compose -f docker-compose-dev.yml up --build
```

Ports:  
Frontend: `2230`  
Api: `2231`  
Product catalog: `2232`  
Checkout: `2233`  
Adminer: `8080`

Swagger available on: `http://localhost:<port>/swagger`

### **Prod mode**

To run the project in production mode use:

```
./run prod up
```

or

```
docker compose up --build
```

Ports:  
Frontend: `80`  
Api: `1231`  
Product catalog: `1232`  
Checkout: `1233`

## Env variables

**Note:** Environmental variables need to be placed inside file `.env` for production and inside `.env-dev` for development.

| Name              | Description        |
| ----------------- | ------------------ |
| POSTGRES_USER     | database user name |
| POSTGRES_DB       | database name      |
| POSTGRES_PASSWORD | database password  |
