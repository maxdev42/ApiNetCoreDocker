# ApiNetCoreDocker

Launch docker container :

docker build -t image_web_api .

docker run -it -d --rm -p 5000:80 image_web_api

http://localhost:5000/weatherforecast