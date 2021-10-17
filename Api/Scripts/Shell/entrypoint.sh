#!/bin/bash
SA_PASSWORD="Pass@123"

echo "RUNNING SQL SERVER IN BACKGROUND"
bash ./migrate-version.sh $SA_PASSWORD & /opt/mssql/bin/sqlservr