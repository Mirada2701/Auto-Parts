docker build -t pd211-asp . 
docker images --all
docker run -it --rm -p 5091:8080 --name pd211_container pd211-asp
docker run -d --restart=always --name pd211_container -p 5091:8080 pd211-asp
docker run -d --restart=always -v d:/volumes/spring/uploading:/app/uploading --name pd211_container -p 5091:8080 pd211-asp
docker run -d --restart=always -v /volumes/spring/uploading:/app/uploading --name pd211_container -p 5091:8080 pd211-asp
docker ps -a
docker stop pd211_container
docker rm pd211_container

docker images --all
docker rmi pd211-asp

docker login
docker tag pd211-asp:latest novakvova/pd211-asp:latest
docker push novakvova/pd211-asp:latest

docker pull novakvova/pd211-asp:latest
docker ps -a
docker run -d --restart=always --name pd211_container -p 5091:8080 novakvova/pd211-asp


docker pull novakvova/pd211-asp:latest
docker images --all
docker ps -a
docker stop pd211_container
docker rm pd211_container
docker run -d --restart=always --name pd211_container -p 5091:8080 novakvova/pd211-asp

---------------/etc/nginx/sites-available/--------------------------

server {
    server_name   slush.itstep.click *.slush.itstep.click;
    location / {
       proxy_pass         http://localhost:5091;
       proxy_http_version 1.1;
       proxy_set_header   Upgrade $http_upgrade;
       proxy_set_header   Connection keep-alive;
       proxy_set_header   Host $host;
       proxy_cache_bypass $http_upgrade;
       proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
       proxy_set_header   X-Forwarded-Proto $scheme;
    }
}

sudo nginx -t
sudo systemctl restart nginx
sudo systemctl status nginx