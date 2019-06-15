
# Pinger
import os
import platform
from datetime import datetime


print("""

     __             
    |__). _  _  _ _ 
    |   || )(_)(-|  
            _/      

""")

net = input("Enter the Network Address xxx.xxx.xxx ")
net1= net.split('.')
a = '.'
net2 = net1[0]+a+net1[1]+a+net1[2]+a
st1 = int(input("Enter the Starting Node "))
en1 = int(input("Enter the Last Node "))

en1=en1+1
oper = platform.system()
if (oper=="Windows"):
    ping1 = "ping -n 1 "
elif (oper== "Linux"):
    ping1 = "ping -c 1 "
else :
    ping1 = "ping -c 1 "
    
t1= datetime.now()
print("Scanning in Progress")

for ip in range(st1,en1):
    addr = net2+str(ip)
    print("Scanning " + addr,end="\r")
    comm = ping1+addr
    response = os.popen(comm)
    for line in response.readlines():
        if (line.count("TTL")):
            print(addr, "--> Live")
    break
        
        
t2= datetime.now()
total =t2-t1
print("scanning complete in " , total)
