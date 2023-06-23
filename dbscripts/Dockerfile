FROM python:3.10-alpine
COPY database.ini config.py fill_db.py .
RUN pip install psycopg2-binary
CMD ["python", "./fill_db.py"]