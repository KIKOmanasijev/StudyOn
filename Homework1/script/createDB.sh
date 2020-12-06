#!/bin/python
from sqlalchemy import *

connection_string="postgresql://"+"postgres"+":"+"djuntafan%5"+"@"+"127.0.0.1"+":"+"5432"+"/"+"postgres"
engine = create_engine(connection_string)

metadata=MetaData(engine)

engine.execute("create schema if not exists my_schema")
engine.execute("drop table if exists my_schema.courts")
engine.execute("create table if not exists my_schema.courts("
			   "id numeric primary key,"
			   "lat real not null,"
			   "lng real not null,"
			   "sport varchar(20),"
			   "name varchar(20)"
			   ")")

f = open("o.csv", encoding = 'utf-8')
f.readline()
for x in f:
	arr=x.split(",")
	# if arr[3]=="" and arr[4]=="\n":
	engine.execute("insert into my_schema.courts "
			   "values("
			   +arr[0]+","+arr[1]+","+arr[2]+
			   ")")
	# elif arr[3]!="" and arr[4]=="\n" :
	# 	engine.execute("insert into my_schema.courts "
	# 				   "values("
	# 				   + arr[0] + "," + arr[1] + "," + arr[2] +","+str(arr[3])+
	# 				   ")")
	# else:
	# 	engine.execute("insert into my_schema.courts "
	# 				   "values("
	# 				   + arr[0] + "," + arr[1] + "," + arr[2] +","+str(arr[3])+","+str(arr[4])+
	# 				   ")")
f.close()


inspector = inspect(engine)
schemas = inspector.get_schema_names()

for table_name in inspector.get_table_names(schema="my_schema"):
	for column in inspector.get_columns(table_name, schema="my_schema"):
		print("Column: %s" % column)

