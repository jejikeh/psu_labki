import pygame, sys
import paho.mqtt.publish as publish

pygame.init()
clock = pygame.time.Clock()

screen_width = 640
screen_height = 480

ball_speed_x = 7
ball_speed_y = 7
player_speed = 0

screen = pygame.display.set_mode((screen_width, screen_height))
pygame.display.set_caption('Pong Server')

ball = pygame.Rect(screen_width/2 - 15, screen_height/2 - 15, 30, 30)
player1 = pygame.Rect(screen_width - 40, screen_height/2 - 70, 20, 140)
player2 = pygame.Rect(20, screen_height/2 - 70, 20, 140)

bg_color = pygame.Color('grey12')
light_gray = (200, 200, 200)

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

    ball.x += ball_speed_x
    ball.y += ball_speed_y

    player1.y += player_speed

    if ball.top <= 0 or ball.bottom >= screen_height:
        ball_speed_y *= -1

    if ball.left <= 0 or ball.right >= screen_width:
        ball_speed_x *= -1

    if ball.colliderect(player1) or ball.colliderect(player2):
        ball_speed_x *= -1
    
    publish.single("minor/jejikeh/pong/ball_pos_x", ball.x, hostname="mqtt.eclipseprojects.io")
    publish.single("minor/jejikeh/pong/ball_pos_y", ball.y, hostname="mqtt.eclipseprojects.io")
    publish.single("minor/jejikeh/pong/pl_pos_x", player1.x, hostname="mqtt.eclipseprojects.io")
    publish.single("minor/jejikeh/pong/pl_pos_y", player1.y, hostname="mqtt.eclipseprojects.io")

    screen.fill(bg_color)

    pygame.draw.rect(screen, light_gray, player1)
    pygame.draw.rect(screen, light_gray, player2)
    pygame.draw.ellipse(screen, light_gray, ball)
    
    pygame.draw.aaline(screen, light_gray, (screen_width / 2, 0), (screen_width / 2, screen_height))

    pygame.display.flip()
    clock.tick(16)