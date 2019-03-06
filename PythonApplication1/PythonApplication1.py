
import socket


serv = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
serv.bind(('', 20000))
serv.listen(5)  # 5 signifie qu'on peut être jusqu'à 5 connexions en "backlog"
print('On a réussi a écouter')

# On accepte une seule connexion
conn, addr = serv.accept()

# Récupérer les informations de la source, les conserver dans un tableau, avec le socket, le user, etc.

# Maintenant, partir un thread qui utilisera exclusivement conn.
print('On a accepté la connexion!')

# On s'attend à avoir un int32 qui contient la version du protocole.  Si non compatible, on arrête la communication


# On envoie la version implantée du protocole dans le serveur, sous forme de int32

# On veut avoir 

msg = 'toto\ntiti\ntutu'
conn.send(msg.encode('utf_16'))
print('Message envoyé!')

x = conn.recv(5)

