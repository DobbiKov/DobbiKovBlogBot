#!/bin/sh
USERNAME='root'
MCPATH='/root/SHmine/'
RAM='1G'
FILENAME='/root/SHmine/spigot-1.16.1.jar'
START="java -Xms$RAM -Xmx$RAM -jar $FILENAME"
SCREEN='minecraft-01'
COMMAND="$1"
PARAMETER="$@"
ME=`whoami`

as_user() {
    if [ "$ME" == "$USERNAME" ]
    then
        bash -c "$1"
    else
        su - $USERNAME -c "$1"
    fi
}


start(){
    if ps ax | grep -v grep | grep -v -i SCREEN | grep $FILENAME > /dev/null
    then
        #echo 'Server has been ran'
    else
        #echo 'Server starting'
        as_user "cd $MCPATH && screen -dmS $SCREEN $START"
        sleep 7

        if ps ax | grep -v grep | grep -v -i SCREEN | grep $FILENAME > /dev/null
        then
            #echo 'Server is working now'
        else
            #echo 'Sever cannot started now.'
        fi
    fi
}

start;

