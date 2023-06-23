# Beauty supplies store

Website for beauty supplies store in Jasło.

## Development

---

### **Dev mode**

To run the project in development mode use:

```
docker compose -f docker-compose-dev.yml up --build
```

Ports:  
Api: `1235`  
Adminer: `8080`

Swagger available on: `http://localhost:1235/swagger`

### **Prod mode**

To run the project in production mode use:

```
docker compose up --build
```

Ports:  
Api: `1234`

## Env variables

---

**Note:** Environmental variables need to be placed inside `.env` file.

| Name              | Description        |
| ----------------- | ------------------ |
| POSTGRES_USER     | database user name |
| POSTGRES_DB       | database name      |
| POSTGRES_PASSWORD | database password  |
