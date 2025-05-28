DROP DATABASE IF EXISTS service_center;
CREATE DATABASE service_center;
USE service_center;

CREATE TABLE clients (
  client_id INT AUTO_INCREMENT PRIMARY KEY,
  FullName VARCHAR(100) NOT NULL
);

INSERT INTO clients (FullName) VALUES
('Иванов Андрей Генадьевич'),
('Иванов Иван Генадьевич');

CREATE TABLE cars (
  id_auto INT AUTO_INCREMENT PRIMARY KEY,
  owner INT,
  marka_auto VARCHAR(50) NOT NULL,
  model VARCHAR(50) NOT NULL,
  FOREIGN KEY (owner) REFERENCES clients(client_id)
);

INSERT INTO cars (owner, marka_auto, model) VALUES
(1, 'Land Rover', 'Range Rover'),
(2, 'Volkswagen', 'Polo');

CREATE TABLE employes (
employes_id int primary key auto_increment,
position VARCHAR(50) NOT NULL
);

INSERT INTO employes (employes_id, position) VALUES
(1, 'Менеджер продаж'),
(2, 'Механик');

CREATE TABLE orders (
id int primary key auto_increment,
order_date date,
client_id int, 
car_id int,
status VARCHAR(50) NOT NULL,
foreign key (client_id) references clients (client_id),
foreign key (car_id) references cars (id_auto)
);

INSERT INTO orders (order_date, status, client_id, car_id) VALUES
('2025-05-08', 'Готово', '1', '1'),
('2025-06-09', 'В работе', '2', '2');

SELECT
    orders.id AS id_заказа,
    orders.order_date AS дата_заказа,
    orders.status AS статус_заказа,
    clients.FullName AS имя_клиента,
    cars.marka_auto AS марка_автомобиля,
    cars.model AS модель_автомобиля
FROM orders
JOIN clients ON orders.client_id = clients.client_id
JOIN cars ON orders.car_id = cars.id_auto
ORDER BY orders.order_date DESC;