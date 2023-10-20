import paho.mqtt.publish as publish

publish.single("minor/jejikeh/lab2", "hello, minor", hostname="mqtt.eclipseprojects.io")