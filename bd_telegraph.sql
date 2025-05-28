DROP DATABASE IF EXISTS hotel;
CREATE DATABASE hotel;
USE hotel;

CREATE TABLE categories(

id INT PRIMARY KEY AUTO_INCREMENT,

name VARCHAR(255) UNIQUE NOT NULL

);



INSERT INTO categories(id, name) VALUES

(1, 'Одноместный стандарт'),

(2, 'Одноместный эконом'),

(3, 'Стандарт двухместный с 2 раздельными кроватями'),

(4, 'Эконом двухместный с 2 раздельными кроватями'),

(5, '3-местный бюджет'),

(6, 'Бизнес с 1 или 2 кроватями'),

(7, 'Двухкомнатный двухместный стандарт с 1 или 2 кроватями'),

(8, 'Студия'),

(9, 'Люкс с 2 двуспальными кроватями');



CREATE TABLE rooms_statuses(

id INT PRIMARY KEY AUTO_INCREMENT,

name VARCHAR(255) UNIQUE NOT NULL

);



INSERT INTO rooms_statuses(id, name) VALUES

(1, 'Чистый'),

(2, 'Грязный'),

(3, 'Назначен к уборке');



CREATE TABLE payments_statuses(

id INT PRIMARY KEY AUTO_INCREMENT,

name VARCHAR(255) UNIQUE NOT NULL

);



INSERT INTO payments_statuses(id, name) VALUES

(1, 'Ожидает оплаты'),

(2, 'Оплата отменена'),

(3, 'Оплачено');

CREATE TABLE posts(

id INT PRIMARY KEY AUTO_INCREMENT,

name VARCHAR(255) UNIQUE NOT NULL

);



INSERT INTO posts(id, name) VALUES

(1, 'Уборщик'),

(2, 'Администратор'),

(3, 'Управляющий');

CREATE TABLE guests(

id INT PRIMARY KEY AUTO_INCREMENT,

name VARCHAR(255) NOT NULL

);



CREATE TABLE access_levels(

id INT PRIMARY KEY AUTO_INCREMENT,

name VARCHAR(255) UNIQUE NOT NULL

);



INSERT INTO access_levels(id, name) VALUES

(1, 'Гость'),

(2, 'Уборщик'),

(3, 'Администратор'),

(4, 'Управляющий');



CREATE TABLE users(

id INT PRIMARY KEY AUTO_INCREMENT,

login VARCHAR(255) UNIQUE NOT NULL,

password VARCHAR(255) NOT NULL,

access_level INT NOT NULL,

login_attempts INT NOT NULL DEFAULT 0,

last_login DATE NULL DEFAULT NULL,

FOREIGN KEY (access_level) REFERENCES access_levels(id) ON DELETE CASCADE ON UPDATE CASCADE

);



INSERT INTO users(id, login, password, access_level) VALUES

(1, 'admin', 'super', 3),

(2, 'manager', 'qwerty', 4);



CREATE TABLE rooms(

id INT PRIMARY KEY AUTO_INCREMENT,

floor INT NOT NULL,

number INT NOT NULL,

category INT NOT NULL,

status INT NOT NULL,

FOREIGN KEY (category) REFERENCES categories(id) ON DELETE CASCADE ON UPDATE CASCADE,

FOREIGN KEY (status) REFERENCES rooms_statuses(id) ON DELETE CASCADE ON UPDATE CASCADE

);



INSERT INTO rooms(floor, number, category, status) VALUES

(1, 101, 1, 1),

(1, 102, 1, 1);



CREATE TABLE employees(

id INT PRIMARY KEY AUTO_INCREMENT,

name VARCHAR(255) NOT NULL,

post INT NOT NULL,

FOREIGN KEY (post) REFERENCES posts(id) ON DELETE CASCADE ON UPDATE CASCADE

);



CREATE TABLE cleanings(

id INT PRIMARY KEY AUTO_INCREMENT,

room INT NOT NULL,

employee INT NOT NULL,

date DATE NOT NULL,

FOREIGN KEY (room) REFERENCES rooms(id) ON DELETE CASCADE ON UPDATE CASCADE,

FOREIGN KEY (employee) REFERENCES employees(id) ON DELETE CASCADE ON UPDATE CASCADE
)