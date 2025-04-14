#  Docker e conteinerizacao de Servicos aplicados em um projeto pratico

Este projeto surgiu após minha participação em um workshop sobre Docker e containerização de aplicações, oferecido pela [Itestra](https://itestra.com/). Durante o evento, pude perceber o potencial dessas tecnologias no desenvolvimento de software e decidi aplicar os conhecimentos adquiridos em um projeto próprio.

Tecnologias e Arquitetura
Além do Docker e Docker Compose, utilizei duas APIs públicas para obter:

1.Coordenadas geográficas (latitude e longitude) de uma cidade ou endereço.

2.Condições meteorológicas do local, como probabilidade de chuva e temperatura (para simplificar a solução, foquei apenas nesses dois indicadores).

Para otimizar o desempenho, implementei um **serviço de Redis em um container**, que atua como cache e evita a sobrecarga de chamadas repetidas às APIs. O modelo da aplicação parte do princípio de que a previsão do tempo não se altera até o final do dia, permitindo que os dados sejam armazenados no Redis e reutilizados em consultas subsequentes.

Além disso, criei um **container com Nginx** para gerenciar o roteamento das requisições do usuário, direcionando-as para o serviço adequado:

- Frontend, se a solicitação for relacionada à interface.

- Backend, se for uma chamada à API.

## Advantages
- Escalabilidade: A containerização facilita a implantação e o gerenciamento dos serviços.
- Eficiência: O Redis reduz a latência e o consumo de recursos das APIs externas (menor número de requisições à API e menor tempo de resposta)
- Organização: O Nginx centraliza o roteamento, simplificando a arquitetura.



Este projeto foi uma excelente oportunidade para consolidar meus conhecimentos em tecnologias modernas de desenvolvimento e infraestrutura.

---

## Objetivo do App: 
Possibilitar verificacao da previsao do tempo no dia ( Temperature e Chances de Chuva)

---

## Application:
![image](https://github.com/user-attachments/assets/ac518dda-33be-4a38-95f7-a1d37348660b)

You can check the precipitation
![image](https://github.com/user-attachments/assets/79c1ac7b-30bf-434e-9276-fd5254ccf0c6)

You can check the Temperature
![image](https://github.com/user-attachments/assets/1c519eb8-a186-400c-861a-912cde860f8d)



Image : you can also use the adress instead of city to get more accuracy
![image](https://github.com/user-attachments/assets/3bc8ef6a-0296-4f37-87fa-e14551bb02c6)

Image Temperature: you can also use the adress instead of city to get more accuracy
![image](https://github.com/user-attachments/assets/be1a2f08-76c0-402a-9c24-d03f3737e200)


can even check every city in the world !!
![image](https://github.com/user-attachments/assets/a161db95-fd90-4257-9e4a-22cfa50b4585)

## Technologies Used

- **.NET Core**: Backend framework for building robust and scalable web applications.
- **Blazor**: Frontend framework for managing web UIs using C# instead of JavaScript and Api requests.
- **Syncfusion**: Framework for building Grids, Line Charts and Area Charts for visualizing weather data and metrics.
- **Docker**: Used to containerize the application components, ensuring consistency across different environments and simplifying deployment and scaling.
- **Redis** An in-memory data structure store used as a caching layer to reduce API calls and improve response time.
- **Nginx**  Acts as a reverse proxy and load balancer, managing incoming requests and routing them efficiently to the appropriate service (frontend or backend).


# Project Structure

# Arquitetura do Projeto

Backend Frontend Redis e

Monatar esboco da aquitetura com imagem

# Contextualizando

???
---

# documentation for API

[Link Api open-meteo](https://open-meteo.com/en/docs?latitude=48.1374&longitude=11.5755&timezone=Europe%2FBerlin&daily=sunrise,sunset&forecast_days=1)

[Link Api open cage data / describe latitude and longitude ](https://opencagedata.com/api#quickstart)

