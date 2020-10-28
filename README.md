# ApiNetCoreDocker

LAUNCH DOCKER CONTAINER :

docker build -t image_web_api .

docker run -it -d --rm -p 5000:80 image_web_api

OR

docker-compose up -d

ACCESS BY

http://localhost:5000/swagger