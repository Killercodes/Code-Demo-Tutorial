# Zip Cracker
#!/usr/bin/python
# -*- coding: utf-8 -*-
import zipfile
from optparse import OptionParser
from threading import Thread


def extractFile(z_File, password):
    try:
        pw_bytes = bytes(password,'utf-8')
        z_File.extractall(pwd=pw_bytes)
        #z_File.open()
        print(("[+] Found password " + password + "\n"))
    except:
        print("pass '"+ password + "' failed",end ="\r")
        pass


def main():
    print("""
    
    ___       __              
    _/ . _   /   _ _  _|  _ _ 
    /__||_)  \__| (_|(_|((-|  
        |                     

    """)
    parser = OptionParser("usage %prog "+ "-f <zipfile> -d <dictionary>")
    parser.add_option('-f', dest='zname', type='string', help='specify zip file')
    parser.add_option('-d', dest='dname', type='string', help='specify dictionary file')
    (options, args) = parser.parse_args()

    options.zname = "egg.zip"
    options.dname = "dictionary.txt" 
    if (options.zname == None) | (options.dname == None):
        print((parser.usage))
        exit(0)
    else:
        zname = options.zname
        dname = options.dname

    zFile = zipfile.ZipFile(zname)
    print((zFile.infolist()))
    passFile = open(dname)

    for line in passFile.readlines():
        password = line.strip('\n')
        extractFile(zFile,password)
        #t = Thread(target=extractFile, args=(zFile, password))
        #t.start()        
        #print(("[*] Trying {"+password+ "} .."),end="\r")


if __name__ == '__main__':
    main()
