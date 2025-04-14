# Wheater App

Esse projeto eh fruto de uma ideia que tive apos participar em um Workshop sobre Docker e Containerizacao de aplicacoes oferecido pela [Itestra](https://itestra.com/) Durante o Workshop eu percebi o poder dessa ferramenta no desenvolvimento de software e decidi portantto aplicar o que eu aprendi em um projeto proprio. Alem de usar Docker e Docker Compose tambem precisei usar duas APIs publicas que me permitem primeiro pegar Latitude e Longitude geografica de uma cidade ou endereco, e entao encontrar as condicoes de tempo do local. As APISs fonecem diversos indicadores metereologicos, mas para simplificar a solucaco estou somente usando Probabilidade de chuva e Temperatura do local. Para ganhar mais excelencia no projeto, implementei um servico de Redis dentro de um container para poder trabalhar junto com as APIS. Basicamente o Redis evita a sobrecarga de chamada das apis. No modelo da minha aplicacao estou partindo do principio que a previsao do tempo nao vai mudar ate o final do dia, portanto podemos deixar o resultado salvo no servico do Redis e ser recuperado para uma nova consulta. 

Redis foi pensado para armazenar tabela usando combinacao de latitute e longitude dado que sao valores unicos

vantagens:
  Reduz o número de requisições à API

  Evita sobrecarga ou bloqueios na APIs

  Melhora o tempo de resposta da aplicacao



---

# Arquitetura do Projeto

Backend Frontend Redis e

Monatar esboco da aquitetura com imagem

# Contextualizando

???
---

# documentation for API

[Link Api open-meteo](https://open-meteo.com/en/docs?latitude=48.1374&longitude=11.5755&timezone=Europe%2FBerlin&daily=sunrise,sunset&forecast_days=1)

[Link Api open cage data / describe latitude and longitude ](https://opencagedata.com/api#quickstart)


Images Precipitation:
![image](https://github.com/user-attachments/assets/ac518dda-33be-4a38-95f7-a1d37348660b)

Cheche temperature in Rio
![image](https://github.com/user-attachments/assets/79c1ac7b-30bf-434e-9276-fd5254ccf0c6)

Image Precipitation
![image](https://github.com/user-attachments/assets/1c519eb8-a186-400c-861a-912cde860f8d)



Image : you can also check a adress instead of city
![image](https://github.com/user-attachments/assets/3bc8ef6a-0296-4f37-87fa-e14551bb02c6)

and temperature
![image](https://github.com/user-attachments/assets/be1a2f08-76c0-402a-9c24-d03f3737e200)


most cold city in the world
![image](https://github.com/user-attachments/assets/a161db95-fd90-4257-9e4a-22cfa50b4585)

# Project Structure

/WheaterSolutionFolder/
├── docker-compose.yml
├── WheaterApi/
│   ├── Dockerfile (backend)
│   └── WheaterApi.csproj
├── ChartWheaterApi/
│   ├── Dockerfile (frontend)
│   └── ChartWheaterApi.csproj
├── Wheater.Shared/
│   └── Wheater.Shared.csproj
└── nginx/
    └── nginx-reverse-proxy.conf

Acknowledgments
