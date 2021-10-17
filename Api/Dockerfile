FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

COPY Scripts/Procedures scripts/procedures
COPY Scripts/Schemas scripts/schemas

COPY Scripts/Shell/migrate-version.sh migrate-version.sh
COPY Scripts/Shell/entrypoint.sh entrypoint.sh

RUN chmod 755 /scripts/*
RUN chmod +x entrypoint.sh
RUN chmod +x migrate-version.sh

EXPOSE 1433

ENTRYPOINT bash ./entrypoint.sh