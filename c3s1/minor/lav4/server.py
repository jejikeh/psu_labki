import asyncio
import threading
from asyncio_mqtt import Client
import pygame, sys
import paho.mqtt.publish as publish
import paho.mqtt.client as mqtt

mqtt_hub = "localhost"

screen_width = 640
screen_height = 480

global ball_speed_x 
ball_speed_x = 7

global ball_speed_y 
ball_speed_y = 7

player_speed = 0
sync_time = 100;

screen = pygame.display.set_mode((screen_width, screen_height))
pygame.display.set_caption('Pong Server')

ball = pygame.Rect(screen_width/2 - 15, screen_height/2 - 15, 30, 30)
player1 = pygame.Rect(screen_width - 40, screen_height/2 - 70, 20, 140)
player2 = pygame.Rect(20, screen_height/2 - 70, 20, 140)

bg_color = pygame.Color('grey12')
light_gray = (200, 200, 200)

pygame.init()
clock = pygame.time.Clock()

iframe = 0

async def send_ball_speed_x(ball_speed_x):
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/ball_speed_x", ball_speed_x)

async def send_ball_pos_x(ball_x):
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/ball_pos_x", ball_x)

async def send_ball_pos_y(ball_y):
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/ball_pos_y", ball_y)

async def send_ball_speed_y(ball_speed_y):
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/ball_speed_y", ball_speed_y)

async def send_player_speed(player_speed):
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/player1_speed", player_speed)

async def send_player_pos(player_pos):
    print("send player pos: " + str(player_pos))
    async with Client(mqtt_hub) as client:
        await client.publish("minor/jejikeh/pong/player1_pos", player_pos)

async def send_all():
    while True:
        print("send all")
        await send_ball_speed_x(ball_speed_x)
        await send_ball_speed_y(ball_speed_y)
        await send_ball_pos_x(ball.x)
        await send_ball_pos_y(ball.y)
        await send_player_speed(player_speed)
        await send_player_pos(player1.y)

thread = threading.Thread(target=asyncio.run, args=(send_all(),))
thread.start()

def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))

    client.subscribe("minor/jejikeh/pong/player2_speed")
    client.subscribe("minor/jejikeh/pong/player2_pos")

def on_message(client, userdata, msg):
    if msg.topic == "minor/jejikeh/pong/player2_speed":
        global player2_speed 
        player2_speed = int(msg.payload)
    if msg.topic == "minor/jejikeh/pong/player2_pos":
        player2.y = int(msg.payload)

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
                # asyncio.run(send_player_speed(player_speed))
            if event.key == pygame.K_UP:
                player_speed -= 7
                # asyncio.run(send_player_speed(player_speed))

        if event.type == pygame.KEYUP:
            if event.key == pygame.K_DOWN:
                player_speed -= 7
                # asyncio.run(send_player_speed(player_speed))

            if event.key == pygame.K_UP:
                player_speed += 7
                # asyncio.run(send_player_speed(player_speed))

    ball.x += ball_speed_x
    ball.y += ball_speed_y

    player1.y += player_speed

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
    
    screen.fill(bg_color)

    pygame.draw.rect(screen, light_gray, player1)
    pygame.draw.rect(screen, light_gray, player2)
    pygame.draw.ellipse(screen, light_gray, ball)
    
    pygame.draw.aaline(screen, light_gray, (screen_width / 2, 0), (screen_width / 2, screen_height))

    pygame.display.flip()
    clock.tick(16)

    if iframe % sync_time == 0:
        print(iframe)
        # await send_ball_pos_y(ball.y)
        # await send_ball_pos_x(ball.x)

    iframe += 1
    print(iframe)

