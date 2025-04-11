# Blazor Ecommerce

Esse projeto eh fruto de uma ideia que tive apos participar em um Workshop sobre Docker e Containerizacao de aplicacoes oferecido pela [Itestra](https://itestra.com/) Durante o Workshop eu percebi o poder da ferramenta no desenvolvimento de software e decidi portantto aplicar o que eu aprendi em um projeto proprio. Alem de usar Docker e Docker Compose tambem precisei usar duas APIs publicas que me permitem primeiro pegar Latitude e Longitude geografica de uma cidade ou endereco, e entao poder encontrar as condicoes de tempo do local. As apis fonecem diversos indicadores metereologicos, mas para simplificar estou somente Probabilidade de chuva e Temperatura do local. Para ganhar performance na chamada das APIs eu estou usando um servico Redis para evitar sobrecarga de chamada das apis. No modelo da minha aplicacao estou partindo do principio que a previsao do tempo nao vai mudar ate o final do dia, portanto podemos deixar o resultado salvo no servico do Redis e ser recuperado para uma nova consulta. 

vantagens:
  Reduz o número de requisições à API

  Evita sobrecarga ou bloqueios na APIs

  Melhora o tempo de resposta da aplicacao



---

# Arquitetura do Projeto

Backend Frontend Redis e

Monatar esboco da aquitetura com imagem

# Contextualizando

This project is a Ecommerce application built for selling E-books, Blue-Ray, Stream, VHS and videgames online, allowing users to purchase items using credit card, PayPal, or direct bank transfer.

---

documentation for API

[Link Api open-meteo](https://open-meteo.com/en/docs?latitude=48.1374&longitude=11.5755&timezone=Europe%2FBerlin&daily=sunrise,sunset&forecast_days=1)

[Link Api open cage data / describe latitude and longitude ](https://opencagedata.com/api#quickstart)


Images:

Temperature

Image 2


Thank you for reading my project
