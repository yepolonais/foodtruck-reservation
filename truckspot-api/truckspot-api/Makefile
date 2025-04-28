# Makefile
CONTAINER_NAME=truckspot_api

# Définir l'alias pour docker-compose en fonction de ce qui est installé
DOCKER_COMPOSE_CMD := $(shell command -v docker-compose >/dev/null 2>&1 && echo docker-compose || (command -v docker >/dev/null 2>&1 && echo "docker compose" || echo ""))

up:
	$(DOCKER_COMPOSE_CMD) up
down:
	$(DOCKER_COMPOSE_CMD) down

container:
	docker exec -it $(CONTAINER_NAME) bash
	
restore:
	docker exec -it $(CONTAINER_NAME) dotnet restore	

build:
	docker exec -it $(CONTAINER_NAME) dotnet build

install:
	docker exec -it $(CONTAINER_NAME) dotnet add package $(p) $(if $(version),--version $(version))

