#
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

as_user() {
    if [ "$ME" == "$USERNAME" ]
    then
        bash -c "$1"
    else
        su - $USERNAME -c "$1"
    fi
}

    if ps ax | grep -v grep | grep -v -i SCREEN | grep $FILENAME > /dev/null
    then
        as_user "screen -p 0 -S $SCREEN -X eval 'stuff \"save-all\"\015'"
        sleep 10
        as_user "screen -p 0 -S $SCREEN -X eval 'stuff \"stop\"\015'"
        sleep 20
    else
        echo 'Server not ran.'
    fi



