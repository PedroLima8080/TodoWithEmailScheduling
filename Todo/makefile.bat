@ECHO OFF

SET IMAGE_NAME=emailscheduling
SET CONTAINER_NAME=emailscheduling
SET PORT=8080

REM Check if an argument is provided
IF "%1"=="" GOTO help

REM Development
IF /I "%1"=="build-dev" GOTO build-dev
IF /I "%1"=="run-dev" GOTO run-dev

REM Production
IF /I "%1"=="build-prod" GOTO build-prod
IF /I "%1"=="run-prod" GOTO run-prod

REM Stop and remove containers
IF /I "%1"=="stop" GOTO stop

IF /I "%1"=="clean" GOTO clean

:help
ECHO Available targets:
ECHO   build-dev       - Build development container
ECHO   run-dev         - Run the development container
ECHO   build-prod      - Build production container
ECHO   run-prod        - Run the production container
ECHO   stop            - Stop running containers
ECHO   clean           - Stop and remove containers
GOTO end

:build-dev
docker build -t %IMAGE_NAME%:dev -f Dockerfile.dev .
GOTO end

:run-dev
docker run -it --rm -p %PORT%:%PORT% -e ASPNETCORE_ENVIRONMENT=Development --name %CONTAINER_NAME%-dev %IMAGE_NAME%:dev
GOTO end

:build-prod
docker build -t %IMAGE_NAME%:prod -f Dockerfile.prod .
GOTO end

:run-prod
docker run -d -p %PORT%:%PORT% --name %CONTAINER_NAME%-prod %IMAGE_NAME%:prod
GOTO end

:stop
docker stop %CONTAINER_NAME%-dev 2>NUL
docker stop %CONTAINER_NAME%-prod 2>NUL
GOTO clean

:clean
docker rm %CONTAINER_NAME%-dev 2>NUL
docker rm %CONTAINER_NAME%-prod 2>NUL

:end
