# Docker and Service Containerization Applied in a Practical Project

This project arose after my participation in a workshop on Docker and application containerization, offered by [Itestra](https://itestra.com/). During the event, I was able to realize the potential of these technologies in software development and decided to apply the knowledge gained in my own project.

Technologies and Architecture
In addition to Docker and Docker Compose, I used two public APIs to obtain:

1. Geographic coordinates (latitude and longitude) of a city or address.

2. Local weather conditions, such as the probability of rain and temperature (to simplify the solution, I focused only on these two indicators).

To optimize performance, I implemented a **Redis service in a container**, which acts as a cache and avoids the overload of repeated API calls. The application model is based on the assumption that the weather forecast does not change until the end of the day, allowing the data to be stored in Redis and reused in subsequent queries.

Additionally, I created a **container with Nginx** to manage the routing of user requests, directing them to the appropriate service:

- Frontend, if the request is related to the interface.

- Backend, if it is an API call.

---

## Why this app ? 
Enable users to check the weather forecast for the day (Temperature and Chance of Rain).

---

## Application:
Chances of rain today 

![image](https://github.com/user-attachments/assets/ac518dda-33be-4a38-95f7-a1d37348660b)

You can check the temperature in your area

![image](https://github.com/user-attachments/assets/79c1ac7b-30bf-434e-9276-fd5254ccf0c6)


You can also use the adress instead of city to get more accuracy ;)

![image](https://github.com/user-attachments/assets/3bc8ef6a-0296-4f37-87fa-e14551bb02c6)


and You can check every city in the world !!

![image](https://github.com/user-attachments/assets/a161db95-fd90-4257-9e4a-22cfa50b4585)

## Advantages of using Docker

-Scalability: Containerization makes service deployment and management easier.

-Efficiency: Redis reduces latency and resource consumption from external APIs (fewer API requests and faster response times).

-Organization: Nginx centralizes routing, simplifying the architecture.


## Technologies Used

- **.NET Core**: Backend framework for building robust and scalable web applications.
- **Blazor Web Assembly**: Frontend framework for managing web UIs using C# instead of JavaScript and Api requests.
- **Syncfusion**: Framework for building Grids, Line Charts and Area Charts for visualizing weather data and metrics.
- **Docker**: Used to containerize the application components, ensuring consistency across different environments and simplifying deployment and scaling.
- **Redis** An in-memory data structure store used as a caching layer to reduce API calls and improve response time.
- **Nginx**  Acts as a reverse proxy and load balancer, managing incoming requests and routing them efficiently to the appropriate service (frontend or backend).

# Arquitetura do Projeto

![image](https://github.com/user-attachments/assets/e3dc7e71-ea87-4eb2-920d-6a49ccd2516d)


## Getting Started

Follow these steps to set up the project locally:

### Clone the Repository

git clone https://github.com/FrotaLucas/WheaterApi.git

### Run the Application

1. cd WheaterApi
2. open Docker Desktop
3. docker-compose up -d --build

### Contact

[LinkedIn](https://www.linkedin.com/in/your-profile/)

# documentation for APIs

[Link Api open-meteo](https://open-meteo.com/en/docs?latitude=48.1374&longitude=11.5755&timezone=Europe%2FBerlin&daily=sunrise,sunset&forecast_days=1)

[Link Api open cage data / describe latitude and longitude ](https://opencagedata.com/api#quickstart)

