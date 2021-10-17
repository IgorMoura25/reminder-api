#!/bin/sh

SA_PASSWORD=$1

check_directory_and_run_scripts(){
    cd $1
    echo "==> CHECKING DIRECTORY $1"
    for file in *
    do
        local file_path=$(find $1 -name $file)

        if [ -d $file_path ]
        then
            if [ ! -z "$(ls -A $file_path)"] #if directory is not empty
            then
                check_directory_and_run_scripts $file_path # runs recursively, checking subdirectories
            fi
        elif [[ "$file" == *.sql ]] #if it is a .sql file
        then
            echo "==> RUNNING SCRIPT: $file"
            /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i $file
        fi
    done
}

echo "SLEEPING 15 SECONDS"
sleep 15s

echo "==> SETTING SCRIPTS TO **DEVELOPMENT** ENVIRONMENT"
check_directory_and_run_scripts /scripts/schemas/dev-setup
check_directory_and_run_scripts /scripts/procedures

if [ $? -eq 0 ]
then
    echo "==> SCRIPTS FINISHED!"
else
    echo "==> ERROR WHILE RUNNING THE SCRIPTS..."
fi