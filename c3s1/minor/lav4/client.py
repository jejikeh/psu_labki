import asyncio
import threading
from asyncio_mqtt import Client
import paho.mqtt.client as mqtt
import pygame
import sys

mqtt_hub = "localhost"

pygame.init()
clock = pygame.time.Clock()

screen_width = 640
screen_height = 480

ball_speed_x = 7
ball_speed_y = 7

player_speed = 0
player1_speed = 0

screen = pygame.display.set_mode((screen_width, screen_height))
pygame.display.set_caption('Pong Client')

ball = pygame.Rect(screen_width/2 - 15, screen_height/2 - 15, 30, 30)
player1 = pygame.Rect(screen_width - 40, screen_height/2 - 70, 20, 140)
player2 = pygame.Rect(20, screen_height/2 - 70, 20, 140)

bg_color = pygame.Color('grey12')
light_gray = (200, 200, 200)


async def send_player_speed(player_speed):
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/player2_speed", player_speed)


async def send_player_pos(player_pos):
    print("send player pos: " + str(player_pos))
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/player2_pos", player_pos)


async def send_all():
    while True:
        print("send all")
        await send_player_speed(player_speed)
        await send_player_pos(player2.y)

thread = threading.Thread(target=asyncio.run, args=(send_all(),))
thread.start()


def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))

    client.subscribe("minor/jejikeh/pong/ball_speed_x")
    client.subscribe("minor/jejikeh/pong/ball_speed_y")
    client.subscribe("minor/jejikeh/pong/player1_speed")
    client.subscribe("minor/jejikeh/pong/player1_pos")
    client.subscribe("minor/jejikeh/pong/ball_pos_x")
    client.subscribe("minor/jejikeh/pong/ball_pos_y")


def on_message(client, userdata, msg):
    if msg.topic == "minor/jejikeh/pong/ball_speed_x":
        global ball_speed_x
        ball_speed_x = int(msg.payload)
    if msg.topic == "minor/jejikeh/pong/ball_speed_y":
        global ball_speed_y
        ball_speed_y = int(msg.payload)

    if msg.topic == "minor/jejikeh/pong/ball_pos_x":
        ball.x = int(msg.payload)
    if msg.topic == "minor/jejikeh/pong/ball_pos_y":
        ball.y = int(msg.payload)

    if msg.topic == "minor/jejikeh/pong/player1_speed":
        global player1_speed
        # player1_speed = int(msg.payload)
    if msg.topic == "minor/jejikeh/pong/player1_pos":
        player1.y = int(msg.payload)


client = mqtt.Client()
client.on_connect = on_connect
client.on_message = on_message

client.connect(mqtt_hub, 1883, 60)
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

    ball.x += ball_speed_x
    ball.y += ball_speed_y
    player1.y += player1_speed
    player2.y += player_speed

    if ball.top <= 0 or ball.bottom >= screen_height:
        ball_speed_y *= -1
        # await send_ball_speed_y(ball_speed_y)
        # await send_ball_pos_y(ball.y)
        # await send_ball_pos_x(ball.x)

    if ball.left <= 0 or ball.right >= screen_width:
        ball_speed_x *= -1
        # await send_ball_speed_x(ball_speed_x)
        # await send_ball_pos_y(ball.y)
        # await send_ball_pos_x(ball.x)

    if ball.colliderect(player1) or ball.colliderect(player2):
        ball_speed_x *= -1
        # await send_ball_speed_x(ball_speed_x)
        # await send_ball_pos_y(ball.y)
        # await send_ball_pos_x(ball.x)

    pygame.draw.rect(screen, light_gray, player1)
    pygame.draw.rect(screen, light_gray, player2)
    pygame.draw.ellipse(screen, light_gray, ball)

    pygame.draw.aaline(screen, light_gray, (screen_width / 2,
                       0), (screen_width / 2, screen_height))

    pygame.display.flip()
    clock.tick(16)
