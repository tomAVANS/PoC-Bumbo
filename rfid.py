from time import sleep
import sys
import requests
from datetime import datetime
from mfrc522 import SimpleMFRC522
reader = SimpleMFRC522()

apiAddress = "http://192.168.1.201:5000/api/timeentry/add"

try:
    prevCardId = "def"
    timestamp = datetime.now()
    while True:
        print("Hold a tag near the reader")
        cardId = reader.read_id()
        if cardId == prevCardId and (datetime.now()-timestamp).total_seconds() < 10:
            continue

        prevCardId = cardId
        payLoad = {"Id": str(cardId)}
        print("The following card clocked:")
        print(payLoad)
        r = requests.post(apiAddress, json=payLoad)
        print(r.status_code)
        timestamp = datetime.now()
       	sleep(0.2)
except KeyboardInterrupt:
    GPIO.cleanup()
    raise
