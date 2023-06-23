import psycopg2
from queries import get_structural_queries, get_insert_queries, get_select_queries
from config import parse_config

def connect_to_db_and_populate_with_mock_data():
    db_connection = None
    try:
        config = parse_config()
        print('Connecting to the database ...')
        db_connection = psycopg2.connect(**config)
        cursor = db_connection.cursor()
        execute_queries(cursor)
        db_connection.commit()
        cursor.close()
    except (Exception, psycopg2.DatabaseError) as error:
        print(error)
    finally:
        if db_connection is not None:
            db_connection.close()
            print('Database connection closed.')

def execute_queries(cursor):
    for query in get_structural_queries():
        cursor.execute(query)
        print(query)

    for insert in get_insert_queries():
        cursor.execute(insert)
        print(insert)

    for select in get_select_queries():
        cursor.execute(select)
        print(select)
        rows = cursor.fetchall()
        print("Selected:")
        for row in rows:
            print(row)

if __name__ == '__main__':
    connect_to_db_and_populate_with_mock_data()