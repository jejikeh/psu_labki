import threading
import paho.mqtt.client as mqtt
import pygame, sys


pygame.init()
clock = pygame.time.Clock()

screen_width = 640
screen_height = 480

ball_speed_x = 7
ball_speed_y = 7
player_speed = 0

screen = pygame.display.set_mode((screen_width, screen_height))
pygame.display.set_caption('Pong Client')

ball = pygame.Rect(screen_width/2 - 15, screen_height/2 - 15, 30, 30)
player1 = pygame.Rect(screen_width - 40, screen_height/2 - 70, 20, 140)
player2 = pygame.Rect(20, screen_height/2 - 70, 20, 140)

bg_color = pygame.Color('grey12')
light_gray = (200, 200, 200)

def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))

    client.subscribe("minor/jejikeh/pong/ball_pos_x")
    client.subscribe("minor/jejikeh/pong/ball_pos_y")
    client.subscribe("minor/jejikeh/pong/pl_pos_y")
    client.subscribe("minor/jejikeh/pong/pl_pos_y")

def on_message(client, userdata, msg):
    if msg.topic == "minor/jejikeh/pong/ball_pos_x":
        ball.x = int(msg.payload)
    if msg.topic == "minor/jejikeh/pong/ball_pos_y":
        ball.y = int(msg.payload)
    if msg.topic == "minor/jejikeh/pong/pl_pos_x":
        player1.x = int(msg.payload)
    if msg.topic == "minor/jejikeh/pong/pl_pos_y":
        player1.y = int(msg.payload)

client = mqtt.Client()
client.on_connect = on_connect
client.on_message = on_message

client.connect("mqtt.eclipseprojects.io", 1883, 60)
thread = threading.Thread(target=client.loop_forever)
thread.start()

while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            sys.exit()
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_DOWN:
                player_speed += 7
            if event.key == pygame.K_UP:
                player_speed -= 7
        if event.type == pygame.KEYUP:
            if event.key == pygame.K_DOWN:
                player_speed -= 7
            if event.key == pygame.K_UP:
                player_speed += 7

    screen.fill(bg_color)

    pygame.draw.rect(screen, light_gray, player1)
    pygame.draw.rect(screen, light_gray, player2)
    pygame.draw.ellipse(screen, light_gray, ball)
    
    pygame.draw.aaline(screen, light_gray, (screen_width / 2, 0), (screen_width / 2, screen_height))

    pygame.display.flip()
    clock.tick(16)