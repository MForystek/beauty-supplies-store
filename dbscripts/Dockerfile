FROM python:3.10-alpine
COPY . .
RUN pip install psycopg2-binary
CMD ["python", "./fill_db.py"]