import io
import paho.mqtt.publish as publish
from PIL import Image

import requests
import shutil

publish.single("minor/jejikeh/lab2", "hello, world", hostname="mqtt.eclipseprojects.io")