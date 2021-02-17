#!/bin/bash
# /etc/init.d/minecraft

# Parameter
USERNAME='root'
MCPATH='/root/SHmine/'
BACKUPPATH='/opt/backup/'
RAM='1G'
FILENAME='spigot-1.16.1.jar'
START="java -Xincgc -Xmx$RAM -jar $FILENAME"
SCREEN='minecraft-01'
COMMAND="$1"
PARAMETER="$@"
ME=`whoami`

# Ausführen als Bennutzer
as_user() {
    if [ "$ME" == "$USERNAME" ]
    then
        bash -c "$1"
    else
        su - $USERNAME -c "$1"
    fi
}

# Server Starten
start() {
    if ps ax | grep -v grep | grep -v -i SCREEN | grep $FILENAME > /dev/null
    then
        echo 'Server already run.'
    else
        echo 'Server will start.'
        
        as_user "cd $MCPATH && screen -dmS $SCREEN $START"
        sleep 7

        if ps ax | grep -v grep | grep -v -i SCREEN | grep $FILENAME > /dev/null
        then
            echo 'Server is working now.'
        else
            echo 'Server cannot started now.'
        fi
    fi
}

start
