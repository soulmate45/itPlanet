using itPlanet.configs;
using itPlanet.handler;
using itPlanet.repository;
using itPlanet.repository.postgres;
using itPlanet.server;
using itPlanet.service;

const string CONFIG_FILE_PATH = "configs/config.json";

// Загрузка конфига
var config = new Config();
config.Load(CONFIG_FILE_PATH);

// Cоединение с базой данных и его проверка
var database = new PostgresDatabase(config);

// Создание слоя для handler, service, repository 
var repository = new Repository(database);
var service = new Service(repository);
var handler = new Handler(service);

var router = handler.GetRouter();
var server = new Server(config, router);

server.Run();
